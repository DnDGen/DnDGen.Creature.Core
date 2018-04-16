﻿using DnDGen.Creature.Core.Abilities;
using DnDGen.Creature.Core.Creatures;
using DnDGen.Creature.Core.Defenses;
using DnDGen.Creature.Core.Feats;
using DnDGen.Creature.Core.Tables;
using DnDGen.Core.Selectors.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.Creature.Core.Generators.Defenses
{
    internal class SavesGenerator : ISavesGenerator
    {
        private readonly ICollectionSelector collectionsSelector;

        public SavesGenerator(ICollectionSelector collectionsSelector)
        {
            this.collectionsSelector = collectionsSelector;
        }

        public Saves GenerateWith(CreatureType creatureType, HitPoints hitPoints, IEnumerable<Feat> feats, Dictionary<string, Ability> abilities)
        {
            var saves = new Saves();

            saves.Constitution = abilities[AbilityConstants.Constitution];
            saves.Dexterity = abilities[AbilityConstants.Dexterity];
            saves.Wisdom = abilities[AbilityConstants.Wisdom];

            saves.FeatFortitudeBonus = GetFeatSavingThrowBonus(feats, SaveConstants.Fortitude);
            saves.FeatReflexBonus = GetFeatSavingThrowBonus(feats, SaveConstants.Reflex);
            saves.FeatWillBonus = GetFeatSavingThrowBonus(feats, SaveConstants.Will);

            saves.RacialFortitudeBonus = GetRacialSavingThrowBonus(creatureType, hitPoints, SaveConstants.Fortitude);
            saves.RacialReflexBonus = GetRacialSavingThrowBonus(creatureType, hitPoints, SaveConstants.Reflex);
            saves.RacialWillBonus = GetRacialSavingThrowBonus(creatureType, hitPoints, SaveConstants.Will);

            saves.CircumstantialBonus = IsBonusCircumstantial(feats);

            return saves;
        }

        private bool IsBonusCircumstantial(IEnumerable<Feat> feats)
        {
            var anySavingThrowFeatNames = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.FeatGroups, GroupConstants.SavingThrows);
            var anySavingThrowFeats = feats.Where(f => anySavingThrowFeatNames.Contains(f.Name));

            var isCircumstantial = anySavingThrowFeats.Any(ft => ft.Foci.Any(f => FocusHasCircumstance(f)));
            return isCircumstantial;
        }

        private bool FocusHasCircumstance(string focus)
        {
            return FocusHasCircumstance(focus, FeatConstants.Foci.All)
                || FocusHasCircumstance(focus, SaveConstants.Fortitude)
                || FocusHasCircumstance(focus, SaveConstants.Reflex)
                || FocusHasCircumstance(focus, SaveConstants.Will);
        }

        private bool FocusHasCircumstance(string focus, string save)
        {
            return focus.StartsWith(save) && focus != save;
        }

        private int GetRacialSavingThrowBonus(CreatureType creatureType, HitPoints hitPoints, string saveName)
        {
            if (hitPoints.HitDiceQuantity == 0)
                return 0;

            var strongSaves = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.CreatureGroups, saveName);

            if (strongSaves.Contains(creatureType.Name))
                return hitPoints.HitDiceQuantity / 2 + 2;

            return hitPoints.HitDiceQuantity / 3;
        }

        private int GetBonus(Feat feat, string savingThrow)
        {
            if (feat.Foci.Contains(FeatConstants.Foci.All) || feat.Foci.Contains(savingThrow))
                return feat.Power;

            return 0;
        }

        private int GetFeatSavingThrowBonus(IEnumerable<Feat> feats, string saveName)
        {
            var saveFeatNames = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.FeatGroups, saveName);
            var saveFeats = feats.Where(f => saveFeatNames.Contains(f.Name));

            var bonus = saveFeats.Sum(f => f.Power);

            var anySavingThrowFeatNames = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.FeatGroups, GroupConstants.SavingThrows);
            var anySavingThrowFeats = feats.Where(f => anySavingThrowFeatNames.Contains(f.Name));

            foreach (var feat in anySavingThrowFeats)
            {
                bonus += GetBonus(feat, saveName);
            }

            return bonus;
        }
    }
}
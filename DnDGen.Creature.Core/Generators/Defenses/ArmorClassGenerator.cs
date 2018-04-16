﻿using DnDGen.Creature.Core.Abilities;
using DnDGen.Creature.Core.Defenses;
using DnDGen.Creature.Core.Feats;
using DnDGen.Creature.Core.Selectors.Collections;
using DnDGen.Creature.Core.Tables;
using DnDGen.Core.Selectors.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.Creature.Core.Generators.Defenses
{
    internal class ArmorClassGenerator : IArmorClassGenerator
    {
        private readonly ICollectionSelector collectionsSelector;
        private readonly IAdjustmentsSelector adjustmentsSelector;

        public ArmorClassGenerator(ICollectionSelector collectionsSelector, IAdjustmentsSelector adjustmentsSelector)
        {
            this.collectionsSelector = collectionsSelector;
            this.adjustmentsSelector = adjustmentsSelector;
        }

        public ArmorClass GenerateWith(Ability dexterity, string size, string creatureName, IEnumerable<Feat> feats)
        {
            var armorClass = new ArmorClass();
            armorClass.Dexterity = dexterity;
            armorClass.DeflectionBonus = adjustmentsSelector.SelectFrom(TableNameConstants.Set.Adjustments.ArmorDeflectionBonuses, creatureName);
            armorClass.NaturalArmorBonus = GetNaturalArmorBonus(feats);
            armorClass.SizeModifier = adjustmentsSelector.SelectFrom(TableNameConstants.Set.Adjustments.SizeModifiers, size);
            armorClass.CircumstantialBonus = IsNaturalArmorBonusCircumstantial(feats);
            armorClass.ArmorBonus = GetArmorBonus(feats);

            return armorClass;
        }

        private bool IsNaturalArmorBonusCircumstantial(IEnumerable<Feat> feats)
        {
            var thingsThatGrantNaturalArmorBonuses = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.ArmorClassModifiers, GroupConstants.NaturalArmor);
            var featsWithNaturalArmorBonuses = feats.Where(f => thingsThatGrantNaturalArmorBonuses.Contains(f.Name));

            return featsWithNaturalArmorBonuses.Any(f => f.Foci.Any());
        }

        private int GetArmorBonus(IEnumerable<Feat> feats)
        {
            var thingsThatGrantArmorBonuses = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.ArmorClassModifiers, GroupConstants.ArmorBonus);
            var featsWithArmorBonuses = feats.Where(f => thingsThatGrantArmorBonuses.Contains(f.Name) && !f.Foci.Any());
            var featArmorBonuses = featsWithArmorBonuses.Select(f => f.Power);
            var featArmorBonus = featArmorBonuses.Sum();

            return featArmorBonus;
        }

        private int GetNaturalArmorBonus(IEnumerable<Feat> feats)
        {
            var thingsThatGrantNaturalArmorBonuses = collectionsSelector.SelectFrom(TableNameConstants.Set.Collection.ArmorClassModifiers, GroupConstants.NaturalArmor);
            var featsWithNaturalArmorBonuses = feats.Where(f => thingsThatGrantNaturalArmorBonuses.Contains(f.Name) && !f.Foci.Any());
            var featNaturalArmorBonuses = featsWithNaturalArmorBonuses.Select(f => f.Power);
            var featNaturalArmorBonus = featNaturalArmorBonuses.Sum();

            return featNaturalArmorBonus;
        }
    }
}
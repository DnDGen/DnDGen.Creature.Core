using DnDGen.Creature.Core.Abilities;
using DnDGen.Creature.Core.Creatures;
using DnDGen.Creature.Core.Defenses;
using DnDGen.Creature.Core.Feats;
using DnDGen.Creature.Core.Selectors.Collections;
using DnDGen.Creature.Core.Tables;
using RollGen;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.Creature.Core.Generators.Defenses
{
    internal class HitPointsGenerator : IHitPointsGenerator
    {
        private readonly Dice dice;
        private readonly IAdjustmentsSelector adjustmentSelector;

        public HitPointsGenerator(Dice dice, IAdjustmentsSelector adjustmentSelector)
        {
            this.dice = dice;
            this.adjustmentSelector = adjustmentSelector;
        }

        public HitPoints GenerateFor(string creatureName, CreatureType creatureType, Ability constitution)
        {
            var hitPoints = new HitPoints();

            hitPoints.HitDiceQuantity = adjustmentSelector.SelectFrom(TableNameConstants.Set.Adjustments.HitDice, creatureName);
            hitPoints.HitDie = adjustmentSelector.SelectFrom(TableNameConstants.Set.Adjustments.HitDice, creatureType.Name);
            hitPoints.Constitution = constitution;

            hitPoints.RollDefault(dice);
            hitPoints.Roll(dice);

            return hitPoints;
        }

        public HitPoints RegenerateWith(HitPoints hitPoints, IEnumerable<Feat> feats)
        {
            hitPoints.Bonus = feats.Where(f => f.Name == FeatConstants.Toughness).Sum(f => f.Power);

            hitPoints.RollDefault(dice);
            hitPoints.Roll(dice);

            return hitPoints;
        }
    }
}
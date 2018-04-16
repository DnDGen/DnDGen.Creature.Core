using DnDGen.Creature.Core.Selectors.Selections;
using DnDGen.Creature.Core.Tables;
using DnDGen.Core.Selectors.Collections;
using System;
using System.Linq;

namespace DnDGen.Creature.Core.Selectors.Collections
{
    internal class SkillSelector : ISkillSelector
    {
        private readonly ICollectionSelector innerSelector;

        public SkillSelector(ICollectionSelector innerSelector)
        {
            this.innerSelector = innerSelector;
        }

        public SkillSelection SelectFor(string skill)
        {
            var data = innerSelector.SelectFrom(TableNameConstants.Set.Collection.SkillData, skill).ToArray();

            var selection = new SkillSelection();
            selection.BaseAbilityName = data[DataIndexConstants.SkillSelectionData.BaseStatName];
            selection.SkillName = data[DataIndexConstants.SkillSelectionData.SkillName];
            selection.RandomFociQuantity = Convert.ToInt32(data[DataIndexConstants.SkillSelectionData.RandomFociQuantity]);
            selection.Focus = data[DataIndexConstants.SkillSelectionData.Focus];

            return selection;
        }
    }
}
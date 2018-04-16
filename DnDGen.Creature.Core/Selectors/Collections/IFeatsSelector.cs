using DnDGen.Creature.Core.Selectors.Selections;
using System.Collections.Generic;

namespace DnDGen.Creature.Core.Selectors.Collections
{
    internal interface IFeatsSelector
    {
        IEnumerable<SpecialQualitySelection> SelectSpecialQualities(string creature);
        IEnumerable<FeatSelection> SelectFeats();
    }
}
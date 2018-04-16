using DnDGen.Creature.Core.Selectors.Selections;

namespace DnDGen.Creature.Core.Selectors.Collections
{
    internal interface IAdvancementSelector
    {
        AdvancementSelection SelectRandomFor(string creature);
        bool IsAdvanced(string creature);
    }
}

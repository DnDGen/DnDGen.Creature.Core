using DnDGen.Creature.Core.Selectors.Selections;

namespace DnDGen.Creature.Core.Selectors.Collections
{
    internal interface ISkillSelector
    {
        SkillSelection SelectFor(string skill);
    }
}
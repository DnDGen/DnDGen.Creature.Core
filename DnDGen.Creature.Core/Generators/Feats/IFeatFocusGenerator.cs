using DnDGen.Creature.Core.Selectors.Selections;
using DnDGen.Creature.Core.Feats;
using DnDGen.Creature.Core.Skills;
using System.Collections.Generic;

namespace DnDGen.Creature.Core.Generators.Feats
{
    internal interface IFeatFocusGenerator
    {
        string GenerateFrom(string feat, string focusType, IEnumerable<Skill> skills, IEnumerable<RequiredFeatSelection> requiredFeats, IEnumerable<Feat> otherFeat);
        string GenerateFrom(string feat, string focusType, IEnumerable<Skill> skills);
        string GenerateAllowingFocusOfAllFrom(string feat, string focusType, IEnumerable<Skill> skills, IEnumerable<RequiredFeatSelection> requiredFeats, IEnumerable<Feat> otherFeat);
        string GenerateAllowingFocusOfAllFrom(string feat, string focusType, IEnumerable<Skill> skills);
    }
}
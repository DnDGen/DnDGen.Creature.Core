using DnDGen.Creature.Core.Abilities;
using DnDGen.Creature.Core.Attacks;
using DnDGen.Creature.Core.Defenses;
using DnDGen.Creature.Core.Feats;
using DnDGen.Creature.Core.Skills;
using System.Collections.Generic;

namespace DnDGen.Creature.Core.Generators.Feats
{
    internal interface IFeatsGenerator
    {
        IEnumerable<Feat> GenerateSpecialQualities(string creatureName, HitPoints hitPoints, string size, Dictionary<string, Ability> abilities, IEnumerable<Skill> skills);
        IEnumerable<Feat> GenerateFeats(HitPoints hitPoints, int baseAttackBonus, Dictionary<string, Ability> abilities, IEnumerable<Skill> skills, IEnumerable<Attack> attacks, IEnumerable<Feat> specialQualities);
    }
}
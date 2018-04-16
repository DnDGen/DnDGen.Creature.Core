using DnDGen.Creature.Core.Abilities;
using DnDGen.Creature.Core.Creatures;
using DnDGen.Creature.Core.Defenses;
using DnDGen.Creature.Core.Feats;
using DnDGen.Creature.Core.Skills;
using System.Collections.Generic;

namespace DnDGen.Creature.Core.Generators.Skills
{
    internal interface ISkillsGenerator
    {
        IEnumerable<Skill> GenerateFor(HitPoints hitPoints, string creatureName, CreatureType creatureType, Dictionary<string, Ability> abilities);
        IEnumerable<Skill> ApplyBonusesFromFeats(IEnumerable<Skill> skills, IEnumerable<Feat> feats);
    }
}
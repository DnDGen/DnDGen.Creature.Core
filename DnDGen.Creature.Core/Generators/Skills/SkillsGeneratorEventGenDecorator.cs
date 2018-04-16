using DnDGen.Creature.Core.Abilities;
using DnDGen.Creature.Core.Creatures;
using DnDGen.Creature.Core.Defenses;
using DnDGen.Creature.Core.Feats;
using DnDGen.Creature.Core.Skills;
using EventGen;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.Creature.Core.Generators.Skills
{
    internal class SkillsGeneratorEventGenDecorator : ISkillsGenerator
    {
        private readonly GenEventQueue eventQueue;
        private readonly ISkillsGenerator innerGenerator;

        public SkillsGeneratorEventGenDecorator(ISkillsGenerator innerGenerator, GenEventQueue eventQueue)
        {
            this.innerGenerator = innerGenerator;
            this.eventQueue = eventQueue;
        }

        public IEnumerable<Skill> ApplyBonusesFromFeats(IEnumerable<Skill> skills, IEnumerable<Feat> feats)
        {
            var updatedSkills = innerGenerator.ApplyBonusesFromFeats(skills, feats);

            return updatedSkills;
        }

        public IEnumerable<Skill> GenerateFor(HitPoints hitPoints, string creatureName, CreatureType creatureType, Dictionary<string, Ability> abilities)
        {
            eventQueue.Enqueue("DnDGen.Creature.Core", $"Generating skills for {creatureName}");
            var skills = innerGenerator.GenerateFor(hitPoints, creatureName, creatureType, abilities);
            eventQueue.Enqueue("DnDGen.Creature.Core", $"Generated {skills.Count()} skills");

            return skills;
        }
    }
}

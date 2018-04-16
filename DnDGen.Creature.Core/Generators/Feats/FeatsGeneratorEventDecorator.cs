using DnDGen.Creature.Core.Abilities;
using DnDGen.Creature.Core.Attacks;
using DnDGen.Creature.Core.Defenses;
using DnDGen.Creature.Core.Feats;
using DnDGen.Creature.Core.Skills;
using EventGen;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.Creature.Core.Generators.Feats
{
    internal class FeatsGeneratorEventDecorator : IFeatsGenerator
    {
        private readonly GenEventQueue eventQueue;
        private readonly IFeatsGenerator innerGenerator;

        public FeatsGeneratorEventDecorator(IFeatsGenerator innerGenerator, GenEventQueue eventQueue)
        {
            this.innerGenerator = innerGenerator;
            this.eventQueue = eventQueue;
        }

        public IEnumerable<Feat> GenerateFeats(HitPoints hitPoints, int baseAttackBonus, Dictionary<string, Ability> abilities, IEnumerable<Skill> skills, IEnumerable<Attack> attacks, IEnumerable<Feat> specialQualities)
        {
            eventQueue.Enqueue("DnDGen.Creature.Core", $"Generating feats");
            var feats = innerGenerator.GenerateFeats(hitPoints, baseAttackBonus, abilities, skills, attacks, specialQualities);
            eventQueue.Enqueue("DnDGen.Creature.Core", $"Generated {feats.Count()} feats");

            return feats;
        }

        public IEnumerable<Feat> GenerateSpecialQualities(string creatureName, HitPoints hitPoints, string size, Dictionary<string, Ability> abilities, IEnumerable<Skill> skills)
        {
            eventQueue.Enqueue("DnDGen.Creature.Core", $"Generating special qualities for {creatureName}");
            var specialQualities = innerGenerator.GenerateSpecialQualities(creatureName, hitPoints, size, abilities, skills);
            eventQueue.Enqueue("DnDGen.Creature.Core", $"Generated {specialQualities.Count()} special qualities");

            return specialQualities;
        }
    }
}

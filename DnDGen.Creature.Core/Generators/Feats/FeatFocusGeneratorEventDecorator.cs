using DnDGen.Creature.Core.Selectors.Selections;
using DnDGen.Creature.Core.Feats;
using DnDGen.Creature.Core.Skills;
using EventGen;
using System.Collections.Generic;

namespace DnDGen.Creature.Core.Generators.Feats
{
    internal class FeatFocusGeneratorEventDecorator : IFeatFocusGenerator
    {
        private readonly GenEventQueue eventQueue;
        private readonly IFeatFocusGenerator innerGenerator;

        public FeatFocusGeneratorEventDecorator(IFeatFocusGenerator innerGenerator, GenEventQueue eventQueue)
        {
            this.innerGenerator = innerGenerator;
            this.eventQueue = eventQueue;
        }

        public string GenerateAllowingFocusOfAllFrom(string feat, string focusType, IEnumerable<Skill> skills)
        {
            LogOpeningEvent(feat);
            var focus = innerGenerator.GenerateAllowingFocusOfAllFrom(feat, focusType, skills);
            LogClosingEvent(feat, focus);

            return focus;
        }

        private void LogOpeningEvent(string feat)
        {
            eventQueue.Enqueue("DnDGen.Creature.Core", $"Generating focus for {feat}");
        }

        private void LogClosingEvent(string feat, string focus)
        {
            if (string.IsNullOrEmpty(focus))
                eventQueue.Enqueue("DnDGen.Creature.Core", $"Generated no focus for {feat}");
            else
                eventQueue.Enqueue("DnDGen.Creature.Core", $"Generated {feat}: {focus}");
        }

        public string GenerateAllowingFocusOfAllFrom(string feat, string focusType, IEnumerable<Skill> skills, IEnumerable<RequiredFeatSelection> requiredFeats, IEnumerable<Feat> otherFeats)
        {
            LogOpeningEvent(feat);
            var focus = innerGenerator.GenerateAllowingFocusOfAllFrom(feat, focusType, skills, requiredFeats, otherFeats);
            LogClosingEvent(feat, focus);

            return focus;
        }

        public string GenerateFrom(string feat, string focusType, IEnumerable<Skill> skills)
        {
            LogOpeningEvent(feat);
            var focus = innerGenerator.GenerateFrom(feat, focusType, skills);
            LogClosingEvent(feat, focus);

            return focus;
        }

        public string GenerateFrom(string feat, string focusType, IEnumerable<Skill> skills, IEnumerable<RequiredFeatSelection> requiredFeats, IEnumerable<Feat> otherFeats)
        {
            LogOpeningEvent(feat);
            var focus = innerGenerator.GenerateFrom(feat, focusType, skills, requiredFeats, otherFeats);
            LogClosingEvent(feat, focus);

            return focus;
        }
    }
}

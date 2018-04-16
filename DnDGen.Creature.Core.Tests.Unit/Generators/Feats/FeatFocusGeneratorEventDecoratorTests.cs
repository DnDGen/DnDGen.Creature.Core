﻿using DnDGen.Creature.Core.Feats;
using DnDGen.Creature.Core.Generators.Feats;
using DnDGen.Creature.Core.Selectors.Selections;
using DnDGen.Creature.Core.Skills;
using EventGen;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DnDGen.Creature.Core.Tests.Unit.Generators.Feats
{
    [TestFixture]
    public class FeatFocusGeneratorEventDecoratorTests
    {
        private IFeatFocusGenerator decorator;
        private Mock<IFeatFocusGenerator> mockInnerGenerator;
        private Mock<GenEventQueue> mockEventQueue;
        private List<Skill> skills;
        private List<RequiredFeatSelection> requiredFeats;
        private List<Feat> otherFeats;

        [SetUp]
        public void Setup()
        {
            mockInnerGenerator = new Mock<IFeatFocusGenerator>();
            mockEventQueue = new Mock<GenEventQueue>();
            decorator = new FeatFocusGeneratorEventDecorator(mockInnerGenerator.Object, mockEventQueue.Object);

            skills = new List<Skill>();
            requiredFeats = new List<RequiredFeatSelection>();
            otherFeats = new List<Feat>();
        }

        [Test]
        public void ReturnInnerFocusAllowingAll()
        {
            mockInnerGenerator.Setup(g => g.GenerateAllowingFocusOfAllFrom("feat", "focus type", skills, requiredFeats, otherFeats)).Returns("focus");

            var focus = decorator.GenerateAllowingFocusOfAllFrom("feat", "focus type", skills, requiredFeats, otherFeats);
            Assert.That(focus, Is.EqualTo("focus"));
        }

        [Test]
        public void LogEventsForFocusGenerationAllowingAll()
        {
            mockInnerGenerator.Setup(g => g.GenerateAllowingFocusOfAllFrom("feat", "focus type", skills, requiredFeats, otherFeats)).Returns("focus");

            var focus = decorator.GenerateAllowingFocusOfAllFrom("feat", "focus type", skills, requiredFeats, otherFeats);
            Assert.That(focus, Is.EqualTo("focus"));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generating focus for feat"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generated feat: focus"), Times.Once);
        }

        [Test]
        public void LogEventsForEmptyFocusGenerationAllowingAll()
        {
            mockInnerGenerator.Setup(g => g.GenerateAllowingFocusOfAllFrom("feat", "focus type", skills, requiredFeats, otherFeats)).Returns(string.Empty);

            var focus = decorator.GenerateAllowingFocusOfAllFrom("feat", "focus type", skills, requiredFeats, otherFeats);
            Assert.That(focus, Is.Empty);
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generating focus for feat"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generated no focus for feat"), Times.Once);
        }

        [Test]
        public void ReturnInnerFocus()
        {
            mockInnerGenerator.Setup(g => g.GenerateFrom("feat", "focus type", skills, requiredFeats, otherFeats)).Returns("focus");

            var focus = decorator.GenerateFrom("feat", "focus type", skills, requiredFeats, otherFeats);
            Assert.That(focus, Is.EqualTo("focus"));
        }

        [Test]
        public void LogEventsForFocusGeneration()
        {
            mockInnerGenerator.Setup(g => g.GenerateFrom("feat", "focus type", skills, requiredFeats, otherFeats)).Returns("focus");

            var focus = decorator.GenerateFrom("feat", "focus type", skills, requiredFeats, otherFeats);
            Assert.That(focus, Is.EqualTo("focus"));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generating focus for feat"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generated feat: focus"), Times.Once);
        }

        [Test]
        public void LogEventsForEmptyFocusGeneration()
        {
            mockInnerGenerator.Setup(g => g.GenerateFrom("feat", "focus type", skills, requiredFeats, otherFeats)).Returns(string.Empty);

            var focus = decorator.GenerateFrom("feat", "focus type", skills, requiredFeats, otherFeats);
            Assert.That(focus, Is.Empty);
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generating focus for feat"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generated no focus for feat"), Times.Once);
        }

        [Test]
        public void ReturnInnerFocusAllowingAllEarly()
        {
            mockInnerGenerator.Setup(g => g.GenerateAllowingFocusOfAllFrom("feat", "focus type", skills)).Returns("focus");

            var focus = decorator.GenerateAllowingFocusOfAllFrom("feat", "focus type", skills);
            Assert.That(focus, Is.EqualTo("focus"));
        }

        [Test]
        public void LogEventsForFocusGenerationAllowingAllEarly()
        {
            mockInnerGenerator.Setup(g => g.GenerateAllowingFocusOfAllFrom("feat", "focus type", skills)).Returns("focus");

            var focus = decorator.GenerateAllowingFocusOfAllFrom("feat", "focus type", skills);
            Assert.That(focus, Is.EqualTo("focus"));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generating focus for feat"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generated feat: focus"), Times.Once);
        }

        [Test]
        public void LogEventsForEmptyFocusGenerationAllowingAllEarly()
        {
            mockInnerGenerator.Setup(g => g.GenerateAllowingFocusOfAllFrom("feat", "focus type", skills)).Returns(string.Empty);

            var focus = decorator.GenerateAllowingFocusOfAllFrom("feat", "focus type", skills);
            Assert.That(focus, Is.Empty);
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generating focus for feat"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generated no focus for feat"), Times.Once);
        }

        [Test]
        public void ReturnInnerFocusEarly()
        {
            mockInnerGenerator.Setup(g => g.GenerateFrom("feat", "focus type", skills)).Returns("focus");

            var focus = decorator.GenerateFrom("feat", "focus type", skills);
            Assert.That(focus, Is.EqualTo("focus"));
        }

        [Test]
        public void LogEventsForFocusGenerationEarly()
        {
            mockInnerGenerator.Setup(g => g.GenerateFrom("feat", "focus type", skills)).Returns("focus");

            var focus = decorator.GenerateFrom("feat", "focus type", skills);
            Assert.That(focus, Is.EqualTo("focus"));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generating focus for feat"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generated feat: focus"), Times.Once);
        }

        [Test]
        public void LogEventsForEmptyFocusGenerationEarly()
        {
            mockInnerGenerator.Setup(g => g.GenerateFrom("feat", "focus type", skills)).Returns(string.Empty);

            var focus = decorator.GenerateFrom("feat", "focus type", skills);
            Assert.That(focus, Is.Empty);
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generating focus for feat"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generated no focus for feat"), Times.Once);
        }
    }
}

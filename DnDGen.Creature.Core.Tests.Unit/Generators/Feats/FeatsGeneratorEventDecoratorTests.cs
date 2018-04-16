﻿using DnDGen.Creature.Core.Abilities;
using DnDGen.Creature.Core.Attacks;
using DnDGen.Creature.Core.Defenses;
using DnDGen.Creature.Core.Feats;
using DnDGen.Creature.Core.Generators.Feats;
using DnDGen.Creature.Core.Skills;
using EventGen;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DnDGen.Creature.Core.Tests.Unit.Generators.Feats
{
    [TestFixture]
    public class FeatsGeneratorEventDecoratorTests
    {
        private IFeatsGenerator decorator;
        private Mock<IFeatsGenerator> mockInnerGenerator;
        private Mock<GenEventQueue> mockEventQueue;
        private Dictionary<string, Ability> abilities;
        private List<Skill> skills;
        private List<Feat> preselectedFeats;
        private HitPoints hitPoints;
        private List<Feat> specialQualities;
        private List<Attack> attacks;

        [SetUp]
        public void Setup()
        {
            mockInnerGenerator = new Mock<IFeatsGenerator>();
            mockEventQueue = new Mock<GenEventQueue>();
            decorator = new FeatsGeneratorEventDecorator(mockInnerGenerator.Object, mockEventQueue.Object);

            abilities = new Dictionary<string, Ability>();
            skills = new List<Skill>();
            preselectedFeats = new List<Feat>();
            hitPoints = new HitPoints();
            specialQualities = new List<Feat>();
            attacks = new List<Attack>();
        }

        [Test]
        public void ReturnInnerFeats()
        {
            var feats = new[]
            {
                new Feat(),
                new Feat(),
            };

            mockInnerGenerator.Setup(g => g.GenerateFeats(hitPoints, 9266, abilities, skills, attacks, specialQualities)).Returns(feats);

            var generatedFeats = decorator.GenerateFeats(hitPoints, 9266, abilities, skills, attacks, specialQualities);
            Assert.That(generatedFeats, Is.EqualTo(feats));
        }

        [Test]
        public void LogEventsForFeatsGeneration()
        {
            var feats = new[]
            {
                new Feat { Name = "feat" },
                new Feat { Name = "other feat" },
            };

            mockInnerGenerator.Setup(g => g.GenerateFeats(hitPoints, 9266, abilities, skills, attacks, specialQualities)).Returns(feats);

            var generatedFeats = decorator.GenerateFeats(hitPoints, 9266, abilities, skills, attacks, specialQualities);
            Assert.That(generatedFeats, Is.EqualTo(feats));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generating feats"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generated 2 feats"), Times.Once);
        }

        [Test]
        public void ReturnInnerSpecialQualities()
        {
            var specialQualities = new[]
            {
                new Feat(),
                new Feat(),
            };

            mockInnerGenerator.Setup(g => g.GenerateSpecialQualities("creature", hitPoints, "size", abilities, skills)).Returns(specialQualities);

            var generatedSpecialQualities = decorator.GenerateSpecialQualities("creature", hitPoints, "size", abilities, skills);
            Assert.That(generatedSpecialQualities, Is.EqualTo(specialQualities));
        }

        [Test]
        public void LogEventsForSpecialQualitiesGeneration()
        {
            var specialQualities = new[]
            {
                new Feat(),
                new Feat(),
            };

            mockInnerGenerator.Setup(g => g.GenerateSpecialQualities("creature", hitPoints, "size", abilities, skills)).Returns(specialQualities);

            var generatedSpecialQualities = decorator.GenerateSpecialQualities("creature", hitPoints, "size", abilities, skills);
            Assert.That(generatedSpecialQualities, Is.EqualTo(specialQualities));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generating special qualities for creature"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generated 2 special qualities"), Times.Once);
        }
    }
}

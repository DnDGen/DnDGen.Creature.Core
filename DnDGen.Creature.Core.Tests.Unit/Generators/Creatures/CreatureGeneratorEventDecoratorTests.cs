using DnDGen.Creature.Core.Creatures;
using DnDGen.Creature.Core.Generators.Creatures;
using EventGen;
using Moq;
using NUnit.Framework;
using System;

namespace DnDGen.Creature.Core.Tests.Unit.Generators.Creatures
{
    [TestFixture]
    public class DnDGen.Creature.CoreeratorEventDecoratorTests
    {
        private IDnDGen.Creature.Coreerator decorator;
        private Mock<IDnDGen.Creature.Coreerator> mockInnerGenerator;
        private Mock<GenEventQueue> mockEventQueue;

        [SetUp]
        public void Setup()
        {
            mockInnerGenerator = new Mock<IDnDGen.Creature.Coreerator>();
            mockEventQueue = new Mock<GenEventQueue>();
            decorator = new DnDGen.Creature.CoreeratorEventDecorator(mockInnerGenerator.Object, mockEventQueue.Object);
        }

        [Test]
        public void ReturnInnerCreature()
        {
            var creature = new Creature();
            creature.Name = Guid.NewGuid().ToString();
            creature.Template = Guid.NewGuid().ToString();

            mockInnerGenerator.Setup(g => g.Generate("creature name", "template name")).Returns(creature);

            var generatedCharacter = decorator.Generate("creature name", "template name");
            Assert.That(generatedCharacter, Is.EqualTo(creature));
        }

        [Test]
        public void LogEventsForDnDGen.Creature.Coreeration()
        {
            var creature = new Creature();
            creature.Name = Guid.NewGuid().ToString();
            creature.Template = Guid.NewGuid().ToString();

            mockInnerGenerator.Setup(g => g.Generate("creature name", "template name")).Returns(creature);

            var generatedCharacter = decorator.Generate("creature name", "template name");
            Assert.That(generatedCharacter, Is.EqualTo(creature));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generating template name creature name"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generated {creature.Summary}"), Times.Once);
        }

        [Test]
        public void LogEventsForDnDGen.Creature.CoreerationWithNoTemplate()
        {
            var creature = new Creature();
            creature.Name = Guid.NewGuid().ToString();

            mockInnerGenerator.Setup(g => g.Generate("creature name", string.Empty)).Returns(creature);

            var generatedCharacter = decorator.Generate("creature name", string.Empty);
            Assert.That(generatedCharacter, Is.EqualTo(creature));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generating creature name"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("DnDGen.Creature.Core", $"Generated {creature.Summary}"), Times.Once);
        }
    }
}

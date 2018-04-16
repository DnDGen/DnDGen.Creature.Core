using DnDGen.Creature.Core.Selectors.Selections;
using NUnit.Framework;

namespace DnDGen.Creature.Core.Tests.Unit.Selectors.Selections
{
    [TestFixture]
    public class AdvancementSelectionTests
    {
        private AdvancementSelection selection;

        [SetUp]
        public void Setup()
        {
            selection = new AdvancementSelection();
        }

        [Test]
        public void AdvancementSelectionIsInitialized()
        {
            Assert.That(selection.AdditionalHitDice, Is.EqualTo(0));
            Assert.That(selection.Reach, Is.EqualTo(0));
            Assert.That(selection.Size, Is.Empty);
            Assert.That(selection.Space, Is.EqualTo(0));
        }
    }
}

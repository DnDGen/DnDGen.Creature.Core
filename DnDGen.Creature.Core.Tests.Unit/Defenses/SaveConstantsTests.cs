using DnDGen.Creature.Core.Defenses;
using NUnit.Framework;

namespace DnDGen.Creature.Core.Tests.Unit.Defenses
{
    [TestFixture]
    public class SaveConstantsTests
    {
        [TestCase(SaveConstants.Fortitude, "Fortitude")]
        [TestCase(SaveConstants.Reflex, "Reflex")]
        [TestCase(SaveConstants.Will, "Will")]
        public void SaveConstant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}

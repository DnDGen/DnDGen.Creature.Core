using DnDGen.Creature.Core.Creatures;
using NUnit.Framework;

namespace DnDGen.Creature.Core.Tests.Unit.Creatures
{
    [TestFixture]
    public class SpeedConstantsTests
    {
        [TestCase(SpeedConstants.Fly, "Fly")]
        [TestCase(SpeedConstants.Burrow, "Burrow")]
        [TestCase(SpeedConstants.Climb, "Climb")]
        [TestCase(SpeedConstants.Land, "Land")]
        [TestCase(SpeedConstants.Swim, "Swim")]
        public void SpeedConstant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}

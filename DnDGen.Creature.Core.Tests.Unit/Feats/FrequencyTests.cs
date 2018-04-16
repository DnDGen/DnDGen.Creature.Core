﻿using DnDGen.Creature.Core.Feats;
using NUnit.Framework;

namespace DnDGen.Creature.Core.Tests.Unit.Feats
{
    [TestFixture]
    public class FrequencyTests
    {
        private Frequency frequency;

        [SetUp]
        public void Setup()
        {
            frequency = new Frequency();
        }

        [Test]
        public void FrequencyInitialized()
        {
            Assert.That(frequency.Quantity, Is.EqualTo(0));
            Assert.That(frequency.TimePeriod, Is.Empty);
        }
    }
}
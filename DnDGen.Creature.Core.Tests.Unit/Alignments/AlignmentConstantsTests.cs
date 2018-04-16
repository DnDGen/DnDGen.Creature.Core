﻿using DnDGen.Creature.Core.Alignments;
using NUnit.Framework;

namespace DnDGen.Creature.Core.Tests.Unit.Alignments
{
    [TestFixture]
    public class AlignmentConstantsTests
    {
        [TestCase(AlignmentConstants.Neutral, "Neutral")]
        [TestCase(AlignmentConstants.Chaotic, "Chaotic")]
        [TestCase(AlignmentConstants.Good, "Good")]
        [TestCase(AlignmentConstants.Evil, "Evil")]
        [TestCase(AlignmentConstants.Lawful, "Lawful")]
        [TestCase(AlignmentConstants.TrueNeutral, "True Neutral")]
        [TestCase(AlignmentConstants.Modifiers.Always, "Always")]
        [TestCase(AlignmentConstants.Modifiers.Usually, "Usually")]
        [TestCase(AlignmentConstants.Modifiers.Often, "Often")]
        public void AlignmentConstant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [TestCase(AlignmentConstants.LawfulGood, AlignmentConstants.Lawful, AlignmentConstants.Good)]
        [TestCase(AlignmentConstants.LawfulNeutral, AlignmentConstants.Lawful, AlignmentConstants.Neutral)]
        [TestCase(AlignmentConstants.LawfulEvil, AlignmentConstants.Lawful, AlignmentConstants.Evil)]
        [TestCase(AlignmentConstants.ChaoticGood, AlignmentConstants.Chaotic, AlignmentConstants.Good)]
        [TestCase(AlignmentConstants.ChaoticNeutral, AlignmentConstants.Chaotic, AlignmentConstants.Neutral)]
        [TestCase(AlignmentConstants.ChaoticEvil, AlignmentConstants.Chaotic, AlignmentConstants.Evil)]
        [TestCase(AlignmentConstants.NeutralGood, AlignmentConstants.Neutral, AlignmentConstants.Good)]
        [TestCase(AlignmentConstants.NeutralEvil, AlignmentConstants.Neutral, AlignmentConstants.Evil)]
        public void AlignmentConstant(string constant, string lawfulness, string goodness)
        {
            Assert.That(constant, Is.EqualTo($"{lawfulness} {goodness}"));
        }
    }
}
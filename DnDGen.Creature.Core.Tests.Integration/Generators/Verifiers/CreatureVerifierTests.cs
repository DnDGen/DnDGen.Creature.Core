﻿using DnDGen.Creature.Core.Creatures;
using DnDGen.Creature.Core.Verifiers;
using EventGen;
using Ninject;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace DnDGen.Creature.Core.Tests.Integration.Generators.Verifiers
{
    [TestFixture]
    public class CreatureVerifierTests : IntegrationTests
    {
        [Inject]
        public ICreatureVerifier CreatureVerifier { get; set; }
        [Inject]
        public Stopwatch Stopwatch { get; set; }
        [Inject]
        public ClientIDManager ClientIdManager { get; set; }

        private TimeSpan timeLimit;

        [SetUp]
        public void Setup()
        {
            var clientId = Guid.NewGuid();
            ClientIdManager.SetClientID(clientId);

            Stopwatch.Reset();
            timeLimit = new TimeSpan(TimeSpan.TicksPerSecond);
        }

        [TestCase(CreatureConstants.Bison, CreatureConstants.Templates.Ghost, true)]
        [TestCase(CreatureConstants.Djinni, CreatureConstants.Templates.Ghost, false)]
        [TestCase(CreatureConstants.Djinni, CreatureConstants.Templates.None, true)]
        [TestCase(CreatureConstants.Djinni_Noble, CreatureConstants.Templates.Ghost, false)]
        [TestCase(CreatureConstants.Djinni_Noble, CreatureConstants.Templates.None, true)]
        [TestCase(CreatureConstants.Efreeti, CreatureConstants.Templates.Ghost, false)]
        [TestCase(CreatureConstants.Efreeti, CreatureConstants.Templates.None, true)]
        [TestCase(CreatureConstants.Janni, CreatureConstants.Templates.Ghost, false)]
        [TestCase(CreatureConstants.Janni, CreatureConstants.Templates.None, true)]
        [TestCase(CreatureConstants.Human, CreatureConstants.Templates.Ghost, true)]
        [TestCase(CreatureConstants.Human, CreatureConstants.Templates.None, true)]
        [TestCase(CreatureConstants.Human, CreatureConstants.Templates.Vampire, true)]
        public void CreatureVerificationIsFast(string creatureName, string templateName, bool isValid)
        {
            Stopwatch.Restart();
            var verified = CreatureVerifier.VerifyCompatibility(creatureName, templateName);
            Stopwatch.Stop();

            Assert.That(verified, Is.EqualTo(isValid));
            Assert.That(Stopwatch.Elapsed, Is.LessThan(timeLimit));
        }
    }
}

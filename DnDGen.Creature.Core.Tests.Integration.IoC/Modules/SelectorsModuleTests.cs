﻿using DnDGen.Creature.Core.Selectors.Collections;
using NUnit.Framework;

namespace DnDGen.Creature.Core.Tests.Integration.IoC.Modules
{
    [TestFixture]
    public class SelectorsModuleTests : IoCTests
    {
        [Test]
        public void AdjustmentsSelectorsAreNotGeneratedAsSingletons()
        {
            AssertNotSingleton<IAdjustmentsSelector>();
        }

        [Test]
        public void SkillSelectorsAreNotGeneratedAsSingletons()
        {
            AssertNotSingleton<ISkillSelector>();
        }

        [Test]
        public void FeatsSelectorsAreNotGeneratedAsSingletons()
        {
            AssertNotSingleton<IFeatsSelector>();
        }

        [Test]
        public void TypeAndAmountSelectorIsInjected()
        {
            AssertNotSingleton<ITypeAndAmountSelector>();
        }

        [Test]
        public void CreatureDataSelectorIsInjected()
        {
            AssertNotSingleton<ICreatureDataSelector>();
        }

        [Test]
        public void AttackSelectorIsInjected()
        {
            AssertNotSingleton<IAttackSelector>();
        }

        [Test]
        public void AdvancementSelectorIsInjected()
        {
            AssertNotSingleton<IAdvancementSelector>();
        }
    }
}
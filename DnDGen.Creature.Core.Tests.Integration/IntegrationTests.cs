﻿using DnDGen.Creature.Core.IoC;
using DnDGen.Core.IoC;
using EventGen.IoC;
using Ninject;
using NUnit.Framework;
using RollGen.Domain.IoC;

namespace DnDGen.Creature.Core.Tests.Integration
{
    [TestFixture]
    public abstract class IntegrationTests
    {
        protected IKernel kernel;

        [OneTimeSetUp]
        public void IntegrationTestsFixtureSetup()
        {
            kernel = new StandardKernel(new NinjectSettings() { InjectNonPublic = true });

            var rollGenLoader = new RollGenModuleLoader();
            rollGenLoader.LoadModules(kernel);

            var eventGenLoader = new EventGenModuleLoader();
            eventGenLoader.LoadModules(kernel);

            var coreLoader = new CoreModuleLoader();
            coreLoader.LoadModules(kernel);

            var DnDGen.Creature.CoreLoader = new DnDGen.Creature.CoreModuleLoader();
            DnDGen.Creature.CoreLoader.LoadModules(kernel);
        }

        [SetUp]
        public void IntegrationTestsSetup()
        {
            kernel.Inject(this);
        }

        protected T GetNewInstanceOf<T>()
        {
            return kernel.Get<T>();
        }

        protected T GetNewInstanceOf<T>(string name)
        {
            return kernel.Get<T>(name);
        }
    }
}
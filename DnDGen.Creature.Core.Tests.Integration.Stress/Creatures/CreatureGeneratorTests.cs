using DnDGen.Creature.Core.Creatures;
using DnDGen.Creature.Core.Generators.Creatures;
using DnDGen.Core.Selectors.Collections;
using Ninject;
using NUnit.Framework;

namespace DnDGen.Creature.Core.Tests.Integration.Stress.Creatures
{
    [TestFixture]
    public class DnDGen.Creature.CoreeratorTests : StressTests
    {
        [Inject]
        public CreatureAsserter CreatureAsserter { get; set; }
        [Inject]
        public ICollectionSelector CollectionSelector { get; set; }
        [Inject]
        public IDnDGen.Creature.Coreerator DnDGen.Creature.Coreerator { get; set; }

        [Test]
        public void StressCreature()
        {
            stressor.Stress(GenerateAndAssertCreature);
        }

        private void GenerateAndAssertCreature()
        {
            var randomCreatureName = CollectionSelector.SelectRandomFrom(allCreatures);

            var creature = DnDGen.Creature.Coreerator.Generate(randomCreatureName, CreatureConstants.Templates.None);

            CreatureAsserter.AssertCreature(creature);
        }

        [Test]
        public void StressCreatureWithTemplate()
        {
            stressor.Stress(GenerateAndAssertCreatureWithTemplate);
        }

        private void GenerateAndAssertCreatureWithTemplate()
        {
            var randomCreatureName = CollectionSelector.SelectRandomFrom(allCreatures);
            var randomTemplate = CollectionSelector.SelectRandomFrom(allTemplates);

            var creature = DnDGen.Creature.Coreerator.Generate(randomCreatureName, randomTemplate);

            CreatureAsserter.AssertCreature(creature);
        }
    }
}
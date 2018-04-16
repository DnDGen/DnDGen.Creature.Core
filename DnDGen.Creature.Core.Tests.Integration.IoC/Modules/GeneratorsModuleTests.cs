using DnDGen.Creature.Core.Creatures;
using DnDGen.Creature.Core.Generators.Abilities;
using DnDGen.Creature.Core.Generators.Alignments;
using DnDGen.Creature.Core.Generators.Creatures;
using DnDGen.Creature.Core.Generators.Defenses;
using DnDGen.Creature.Core.Generators.Feats;
using DnDGen.Creature.Core.Generators.Skills;
using DnDGen.Creature.Core.Verifiers;
using NUnit.Framework;
using RollGen;

namespace DnDGen.Creature.Core.Tests.Integration.IoC.Modules
{
    [TestFixture]
    public class GeneratorsModuleTests : IoCTests
    {
        [Test]
        public void AlignmentGeneratorIsNotBuiltAsSingleton()
        {
            AssertNotSingleton<IAlignmentGenerator>();
        }

        [Test]
        public void AlignmentGeneratorIsDecorated()
        {
            AssertIsInstanceOf<IAlignmentGenerator, AlignmentGeneratorEventDecorator>();
        }

        [Test]
        public void DnDGen.Creature.CoreeratorIsNotBuiltAsSingleton()
        {
            AssertNotSingleton<IDnDGen.Creature.Coreerator>();
        }

        [Test]
        public void DnDGen.Creature.CoreeratorIsDecorated()
        {
            AssertIsInstanceOf<IDnDGen.Creature.Coreerator, DnDGen.Creature.CoreeratorEventDecorator>();
        }

        [Test]
        public void HitPointsGeneratorIsNotBuiltAsSingleton()
        {
            AssertNotSingleton<IHitPointsGenerator>();
        }

        [Test]
        public void RandomizerVerifierIsNotBuiltAsSingleton()
        {
            AssertNotSingleton<ICreatureVerifier>();
        }

        [Test]
        public void AbilitiesGeneratorIsNotBuiltAsSingleton()
        {
            AssertNotSingleton<IAbilitiesGenerator>();
        }

        [Test]
        public void AbilitiesGeneratorIsDecorated()
        {
            AssertIsInstanceOf<IAbilitiesGenerator, AbilitiesGeneratorEventDecorator>();
        }

        [Test]
        public void SkillsGeneratorIsNotBuiltAsSingleton()
        {
            AssertNotSingleton<ISkillsGenerator>();
        }

        [Test]
        public void SkillsGeneratorIsDecorated()
        {
            AssertIsInstanceOf<ISkillsGenerator, SkillsGeneratorEventGenDecorator>();
        }

        [Test]
        public void FeatsGeneratorIsNotBuiltAsSingleton()
        {
            AssertNotSingleton<IFeatsGenerator>();
        }

        [Test]
        public void FeatsGeneratorIsDecorated()
        {
            AssertIsInstanceOf<IFeatsGenerator, FeatsGeneratorEventDecorator>();
        }

        [Test]
        public void SavesGeneratorIsNotASingleton()
        {
            AssertNotSingleton<ISavesGenerator>();
        }

        [Test]
        public void FeatFocusGeneratorIsNotASingleton()
        {
            AssertNotSingleton<IFeatFocusGenerator>();
        }

        [Test]
        public void FeatFocusGeneratorIsDecorated()
        {
            AssertIsInstanceOf<IFeatFocusGenerator, FeatFocusGeneratorEventDecorator>();
        }

        [Test]
        public void EXTERNAL_DiceIsInjected()
        {
            AssertNotSingleton<Dice>();
        }
    }
}
using DnDGen.Creature.Core.Generators.Abilities;
using DnDGen.Creature.Core.Generators.Alignments;
using DnDGen.Creature.Core.Generators.Creatures;
using DnDGen.Creature.Core.Generators.Defenses;
using DnDGen.Creature.Core.Generators.Feats;
using DnDGen.Creature.Core.Generators.Skills;
using DnDGen.Creature.Core.Verifiers;
using Ninject.Modules;

namespace DnDGen.Creature.Core.IoC.Modules
{
    internal class GeneratorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICreatureVerifier>().To<CreatureVerifier>();

            Bind<IHitPointsGenerator>().To<HitPointsGenerator>();
            Bind<IArmorClassGenerator>().To<ArmorClassGenerator>();
            Bind<ISavesGenerator>().To<SavesGenerator>();

            BindDecoratedGenerators();
        }

        private void BindDecoratedGenerators()
        {
            Bind<IDnDGen.Creature.Coreerator>().To<DnDGen.Creature.Coreerator>().WhenInjectedInto<DnDGen.Creature.CoreeratorEventDecorator>();
            Bind<IDnDGen.Creature.Coreerator>().To<DnDGen.Creature.CoreeratorEventDecorator>();

            Bind<IAlignmentGenerator>().To<AlignmentGenerator>().WhenInjectedInto<AlignmentGeneratorEventDecorator>();
            Bind<IAlignmentGenerator>().To<AlignmentGeneratorEventDecorator>();

            Bind<IAbilitiesGenerator>().To<AbilitiesGenerator>().WhenInjectedInto<AbilitiesGeneratorEventDecorator>();
            Bind<IAbilitiesGenerator>().To<AbilitiesGeneratorEventDecorator>();

            Bind<ISkillsGenerator>().To<SkillsGenerator>().WhenInjectedInto<SkillsGeneratorEventGenDecorator>();
            Bind<ISkillsGenerator>().To<SkillsGeneratorEventGenDecorator>();

            Bind<IFeatsGenerator>().To<FeatsGenerator>().WhenInjectedInto<FeatsGeneratorEventDecorator>();
            Bind<IFeatsGenerator>().To<FeatsGeneratorEventDecorator>();

            Bind<IFeatFocusGenerator>().To<FeatFocusGenerator>().WhenInjectedInto<FeatFocusGeneratorEventDecorator>();
            Bind<IFeatFocusGenerator>().To<FeatFocusGeneratorEventDecorator>();
        }
    }
}
using DnDGen.Creature.Core.Selectors.Collections;
using Ninject.Modules;

namespace DnDGen.Creature.Core.IoC.Modules
{
    internal class SelectorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAdjustmentsSelector>().To<AdjustmentsSelector>();
            Bind<ISkillSelector>().To<SkillSelector>();
            Bind<IFeatsSelector>().To<FeatsSelector>();
            Bind<ITypeAndAmountSelector>().To<TypeAndAmountSelector>();
            Bind<ICreatureDataSelector>().To<CreatureDataSelector>();
            Bind<IAttackSelector>().To<AttackSelector>();
            Bind<IAdvancementSelector>().To<AdvancementSelector>();
        }
    }
}
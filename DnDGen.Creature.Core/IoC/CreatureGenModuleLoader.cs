using DnDGen.Creature.Core.IoC.Modules;
using Ninject;

namespace DnDGen.Creature.Core.IoC
{
    public class DnDGen.Creature.CoreModuleLoader
    {
        public void LoadModules(IKernel kernel)
        {
            kernel.Load<GeneratorsModule>();
            kernel.Load<SelectorsModule>();
        }
    }
}
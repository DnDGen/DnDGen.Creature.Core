using DnDGen.Creature.Core.Tables;
using DnDGen.Core.Tables;
using System.Reflection;

namespace DnDGen.Creature.Core.Tests.Integration.Tables
{
    public class DnDGen.Creature.CoreAssemblyLoader : AssemblyLoader
    {
        public Assembly GetRunningAssembly()
        {
            var type = typeof(TableNameConstants);
            return type.Assembly;
        }
    }
}

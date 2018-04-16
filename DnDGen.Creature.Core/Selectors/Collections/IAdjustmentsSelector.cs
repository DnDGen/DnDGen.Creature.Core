using System.Collections.Generic;

namespace DnDGen.Creature.Core.Selectors.Collections
{
    internal interface IAdjustmentsSelector
    {
        Dictionary<string, int> SelectAllFrom(string tableName);
        int SelectFrom(string tableName, string name);
    }
}
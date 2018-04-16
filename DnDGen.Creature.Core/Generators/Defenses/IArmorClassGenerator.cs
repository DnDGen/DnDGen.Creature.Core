using DnDGen.Creature.Core.Abilities;
using DnDGen.Creature.Core.Defenses;
using DnDGen.Creature.Core.Feats;
using System.Collections.Generic;

namespace DnDGen.Creature.Core.Generators.Defenses
{
    internal interface IArmorClassGenerator
    {
        ArmorClass GenerateWith(Ability dexterity, string size, string creatureName, IEnumerable<Feat> feats);
    }
}
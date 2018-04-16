using DnDGen.Creature.Core.Abilities;
using DnDGen.Creature.Core.Creatures;
using DnDGen.Creature.Core.Defenses;
using DnDGen.Creature.Core.Feats;
using System.Collections.Generic;

namespace DnDGen.Creature.Core.Generators.Defenses
{
    internal interface ISavesGenerator
    {
        Saves GenerateWith(CreatureType creatureType, HitPoints hitPoints, IEnumerable<Feat> feats, Dictionary<string, Ability> abilities);
    }
}
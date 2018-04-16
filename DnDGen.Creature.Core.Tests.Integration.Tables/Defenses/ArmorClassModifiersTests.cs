﻿using DnDGen.Creature.Core.Feats;
using DnDGen.Creature.Core.Tables;
using NUnit.Framework;

namespace DnDGen.Creature.Core.Tests.Integration.Tables.Combats
{
    [TestFixture]
    public class ArmorClassModifiersTests : CollectionTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Set.Collection.ArmorClassModifiers; }
        }

        [Test]
        public void CollectionNames()
        {
            var names = new[]
            {
                GroupConstants.Deflection,
                GroupConstants.NaturalArmor,
                GroupConstants.DodgeBonus,
                GroupConstants.ArmorBonus
            };

            AssertCollectionNames(names);
        }

        [TestCase(GroupConstants.Deflection)]
        [TestCase(GroupConstants.NaturalArmor)]
        [TestCase(GroupConstants.DodgeBonus,
            FeatConstants.SpecialQualities.DodgeBonus,
            FeatConstants.Dodge)]
        [TestCase(GroupConstants.ArmorBonus,
            FeatConstants.SpecialQualities.InertialArmor)]
        public void ArmorClassModifier(string name, params string[] collection)
        {
            base.DistinctCollection(name, collection);
        }
    }
}

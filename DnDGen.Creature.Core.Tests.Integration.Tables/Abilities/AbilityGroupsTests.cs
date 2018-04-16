using DnDGen.Creature.Core.Abilities;
using DnDGen.Creature.Core.Tables;
using NUnit.Framework;

namespace DnDGen.Creature.Core.Tests.Integration.Tables.Abilities
{
    [TestFixture]
    public class AbilityGroupsTests : CollectionTests
    {
        protected override string tableName
        {
            get
            {
                return TableNameConstants.Set.Collection.AbilityGroups;
            }
        }

        [Test]
        public void CollectionNames()
        {
            var names = new[]
            {
                GroupConstants.All
            };

            AssertCollectionNames(names);
        }

        [TestCase(GroupConstants.All,
            AbilityConstants.Charisma,
            AbilityConstants.Constitution,
            AbilityConstants.Dexterity,
            AbilityConstants.Intelligence,
            AbilityConstants.Strength,
            AbilityConstants.Wisdom)]
        public void AbilityGroup(string name, params string[] abilities)
        {
            base.Collection(name, abilities);
        }
    }
}

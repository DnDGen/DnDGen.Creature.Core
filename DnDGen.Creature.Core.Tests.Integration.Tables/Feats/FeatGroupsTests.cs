﻿using DnDGen.Creature.Core.Defenses;
using DnDGen.Creature.Core.Feats;
using DnDGen.Creature.Core.Tables;
using NUnit.Framework;

namespace DnDGen.Creature.Core.Tests.Integration.Tables.Feats
{
    [TestFixture]
    public class FeatGroupsTests : CollectionTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Set.Collection.FeatGroups; }
        }

        [Test]
        public void CollectionNames()
        {
            var names = new[]
            {
                GroupConstants.AddHitDiceToPower,
                GroupConstants.AttackBonus,
                GroupConstants.Initiative,
                GroupConstants.SavingThrows,
                GroupConstants.SkillBonus,
                GroupConstants.TakenMultipleTimes,
                GroupConstants.WeaponProficiency,
                SaveConstants.Fortitude,
                SaveConstants.Reflex,
                SaveConstants.Will,
            };

            AssertCollectionNames(names);
        }

        [TestCase(GroupConstants.AttackBonus,
            FeatConstants.SpecialQualities.AttackBonus)]
        [TestCase(GroupConstants.AddHitDiceToPower,
            FeatConstants.SpecialQualities.SpellResistance)]
        [TestCase(GroupConstants.Initiative,
            FeatConstants.Initiative_Improved)]
        [TestCase(GroupConstants.SkillBonus,
            FeatConstants.SpecialQualities.SkillBonus,
            FeatConstants.Acrobatic,
            FeatConstants.Agile,
            FeatConstants.Alertness,
            FeatConstants.AnimalAffinity,
            FeatConstants.Athletic,
            FeatConstants.Deceitful,
            FeatConstants.DeftHands,
            FeatConstants.Diligent,
            FeatConstants.Investigator,
            FeatConstants.MagicalAptitude,
            FeatConstants.Negotiator,
            FeatConstants.NimbleFingers,
            FeatConstants.Persuasive,
            FeatConstants.SelfSufficient,
            FeatConstants.SkillFocus,
            FeatConstants.Stealthy)]
        [TestCase(GroupConstants.SavingThrows,
            FeatConstants.SpecialQualities.SaveBonus)]
        [TestCase(GroupConstants.TakenMultipleTimes,
            FeatConstants.SpecialQualities.AttackBonus,
            FeatConstants.SpellMastery,
            FeatConstants.Toughness,
            FeatConstants.SpecialQualities.SkillBonus,
            FeatConstants.SpecialQualities.DodgeBonus,
            FeatConstants.SpecialQualities.SaveBonus,
            FeatConstants.Monster.NaturalArmor_Improved,
            FeatConstants.Turning_Extra)]
        [TestCase(GroupConstants.WeaponProficiency,
            FeatConstants.WeaponProficiency_Exotic,
            FeatConstants.WeaponProficiency_Martial,
            FeatConstants.WeaponProficiency_Simple)]
        [TestCase(SaveConstants.Fortitude,
            FeatConstants.GreatFortitude)]
        [TestCase(SaveConstants.Reflex,
            FeatConstants.LightningReflexes)]
        [TestCase(SaveConstants.Will,
            FeatConstants.IronWill)]
        public void FeatGroup(string name, params string[] collection)
        {
            DistinctCollection(name, collection);
        }
    }
}
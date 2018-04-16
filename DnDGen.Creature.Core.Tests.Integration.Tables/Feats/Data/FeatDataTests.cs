﻿using DnDGen.Creature.Core.Feats;
using DnDGen.Creature.Core.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.Creature.Core.Tests.Integration.Tables.Feats.Data
{
    [TestFixture]
    public class FeatDataTests : DataTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Set.Collection.FeatData; }
        }

        protected override void PopulateIndices(IEnumerable<string> collection)
        {
            indices[DataIndexConstants.FeatData.BaseAttackRequirementIndex] = "Base Attack Requirement";
            indices[DataIndexConstants.FeatData.FocusTypeIndex] = "Focus Type";
            indices[DataIndexConstants.FeatData.FrequencyQuantityIndex] = "Frequency Quantity";
            indices[DataIndexConstants.FeatData.FrequencyTimePeriodIndex] = "Frequency Time Period";
            indices[DataIndexConstants.FeatData.PowerIndex] = "Power";
        }

        [Test]
        public void CollectionNames()
        {
            var feats = FeatConstants.All();
            var monsterFeats = FeatConstants.Monster.All();
            var craftFeats = FeatConstants.MagicItemCreation.All();
            var metamagicFeats = FeatConstants.Metamagic.All();

            var names = feats.Union(monsterFeats).Union(craftFeats).Union(metamagicFeats);

            AssertCollectionNames(names);
        }

        [TestCase(FeatConstants.Acrobatic, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.Agile, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.Alertness, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.AnimalAffinity, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.ArmorProficiency_Heavy, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.ArmorProficiency_Light, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.ArmorProficiency_Medium, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.Athletic, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.AugmentSummoning, 0, "", 0, "", 4, 0)]
        [TestCase(FeatConstants.BlindFight, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.BullRush_Improved, 0, "", 0, "", 4, 0)]
        [TestCase(FeatConstants.Cleave, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.Cleave_Great, 4, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.CombatCasting, 0, "", 0, "", 4, 0)]
        [TestCase(FeatConstants.CombatExpertise, 0, "", 0, "", 4, 0)]
        [TestCase(FeatConstants.CombatReflexes, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.Counterspell_Improved, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.Critical_Improved, 8, FeatConstants.Foci.Weapon, 0, "", 0, 0)]
        [TestCase(FeatConstants.Deceitful, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.DeflectArrows, 0, "", 1, FeatConstants.Frequencies.Round, 0, 0)]
        [TestCase(FeatConstants.DeftHands, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.Diehard, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.Diligent, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.Disarm_Improved, 0, "", 0, "", 4, 0)]
        [TestCase(FeatConstants.Dodge, 0, "", 0, "", 1, 0)]
        [TestCase(FeatConstants.Endurance, 0, "", 0, "", 4, 0)]
        [TestCase(FeatConstants.EschewMaterials, 0, "", 0, "", 0, 0)]
        //INFO: Creatures cannot get familiars without being a character class
        //[TestCase(FeatConstants.Familiar_Improved, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.FarShot, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.Feint_Improved, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.Grapple_Improved, 0, "", 0, "", 4, 0)]
        [TestCase(FeatConstants.GreatFortitude, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.Initiative_Improved, 0, "", 0, "", 4, 0)]
        [TestCase(FeatConstants.Investigator, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.IronWill, 0, "", 0, "", 2, 0)]
        //INFO: Requires character level 6
        //[TestCase(FeatConstants.Leadership, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.LightningReflexes, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.MagicalAptitude, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.Manyshot, 6, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.Mobility, 0, "", 0, "", 4, 0)]
        [TestCase(FeatConstants.MountedArchery, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.MountedCombat, 0, "", 0, "", 0, 0)]
        //INFO: Wild Shape, a prerequisite, is only had by Druid classes
        //[TestCase(FeatConstants.NaturalSpell, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.Negotiator, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.NimbleFingers, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.Overrun_Improved, 0, "", 0, "", 4, 0)]
        [TestCase(FeatConstants.Persuasive, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.PointBlankShot, 0, "", 0, "", 1, 0)]
        [TestCase(FeatConstants.PowerAttack, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.PreciseShot, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.PreciseShot_Improved, 11, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.QuickDraw, 1, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.RapidReload, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.RapidShot, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.RideByAttack, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.Run, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.SelfSufficient, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.ShotOnTheRun, 4, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.SkillFocus, 0, GroupConstants.Skills, 0, "", 3, 0)]
        [TestCase(FeatConstants.SnatchArrows, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.SpellFocus, 0, FeatConstants.Foci.School, 0, "", 1, 0)]
        [TestCase(FeatConstants.SpellFocus_Greater, 0, FeatConstants.Foci.School, 0, "", 1, 0)]
        [TestCase(FeatConstants.SpellMastery, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.SpellPenetration, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.SpellPenetration_Greater, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.SpiritedCharge, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.SpringAttack, 4, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.Stealthy, 0, "", 0, "", 2, 0)]
        [TestCase(FeatConstants.StunningFist, 8, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.Sunder_Improved, 0, "", 0, "", 4, 0)]
        [TestCase(FeatConstants.Toughness, 0, "", 0, "", 3, 0)]
        [TestCase(FeatConstants.Track, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.Trample, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.Trip_Improved, 0, "", 0, "", 4, 0)]
        //INFO: No monsters can natively turn or rebuke
        //[TestCase(FeatConstants.Turning_Extra, 0, "", 0, "", 4, 0)]
        //[TestCase(FeatConstants.Turning_Improved, 0, "", 0, "", 4, 0)]
        [TestCase(FeatConstants.TwoWeaponFighting_Greater, 11, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.TwoWeaponFighting_Improved, 6, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.TwoWeaponDefense, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.TwoWeaponFighting, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.UnarmedStrike_Improved, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.WeaponFinesse, 1, "", 0, "", 0, 0)]
        //INFO: Being a Fighter is a requirement for these feats
        //[TestCase(FeatConstants.WeaponFocus, 0, FeatConstants.Foci.Weapon, 0, "", 0, 0)]
        //[TestCase(FeatConstants.WeaponFocus_Greater, 0, FeatConstants.Foci.Weapon, 0, "", 0, 0)]
        [TestCase(FeatConstants.WeaponProficiency_Exotic, 0, FeatConstants.WeaponProficiency_Exotic, 0, "", 0, 0)]
        [TestCase(FeatConstants.WeaponProficiency_Martial, 0, FeatConstants.WeaponProficiency_Martial, 0, "", 0, 0)]
        [TestCase(FeatConstants.WeaponProficiency_Simple, 0, FeatConstants.WeaponProficiency_Simple, 0, "", 0, 0)]
        //INFO: Being a Fighter is a requirement for these feats
        //[TestCase(FeatConstants.WeaponSpecialization, 0, FeatConstants.Foci.Weapon, 0, "", 0, 0)]
        //[TestCase(FeatConstants.WeaponSpecialization_Greater, 0, FeatConstants.Foci.Weapon, 0, "", 0, 0)]
        [TestCase(FeatConstants.WhirlwindAttack, 4, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.MagicItemCreation.BrewPotion, 0, "", 0, "", 0, 3)]
        [TestCase(FeatConstants.MagicItemCreation.CraftMagicArmsAndArmor, 0, "", 0, "", 0, 5)]
        [TestCase(FeatConstants.MagicItemCreation.CraftRod, 0, "", 0, "", 0, 9)]
        [TestCase(FeatConstants.MagicItemCreation.CraftStaff, 0, "", 0, "", 0, 12)]
        [TestCase(FeatConstants.MagicItemCreation.CraftWand, 0, "", 0, "", 0, 5)]
        [TestCase(FeatConstants.MagicItemCreation.CraftWondrousItem, 0, "", 0, "", 0, 3)]
        [TestCase(FeatConstants.MagicItemCreation.ForgeRing, 0, "", 0, "", 0, 12)]
        [TestCase(FeatConstants.MagicItemCreation.ScribeScroll, 0, "", 0, "", 0, 0)]
        [TestCase(FeatConstants.Metamagic.EmpowerSpell, 0, "", 0, "", 0, 1)]
        [TestCase(FeatConstants.Metamagic.EnlargeSpell, 0, "", 0, "", 0, 1)]
        [TestCase(FeatConstants.Metamagic.ExtendSpell, 0, "", 0, "", 0, 1)]
        [TestCase(FeatConstants.Metamagic.HeightenSpell, 0, "", 0, "", 0, 1)]
        [TestCase(FeatConstants.Metamagic.MaximizeSpell, 0, "", 0, "", 0, 1)]
        [TestCase(FeatConstants.Metamagic.QuickenSpell, 0, "", 0, "", 0, 1)]
        [TestCase(FeatConstants.Metamagic.SilentSpell, 0, "", 0, "", 0, 1)]
        [TestCase(FeatConstants.Metamagic.StillSpell, 0, "", 0, "", 0, 1)]
        [TestCase(FeatConstants.Metamagic.WidenSpell, 0, "", 0, "", 0, 1)]
        public void FeatData(string name, int baseAttackRequirement, string focusType, int frequencyQuantity, string frequencyTimePeriod, int power, int casterLevel)
        {
            var data = new List<string>();
            for (var i = 0; i < 6; i++)
                data.Add(string.Empty);

            data[DataIndexConstants.FeatData.BaseAttackRequirementIndex] = Convert.ToString(baseAttackRequirement);
            data[DataIndexConstants.FeatData.CasterLevelIndex] = Convert.ToString(casterLevel);
            data[DataIndexConstants.FeatData.FocusTypeIndex] = focusType;
            data[DataIndexConstants.FeatData.FrequencyQuantityIndex] = Convert.ToString(frequencyQuantity);
            data[DataIndexConstants.FeatData.FrequencyTimePeriodIndex] = frequencyTimePeriod;
            data[DataIndexConstants.FeatData.PowerIndex] = Convert.ToString(power);

            Data(name, data);

            Assert.Fail("Review data/requirements for all currently-listed feats");
        }
    }
}
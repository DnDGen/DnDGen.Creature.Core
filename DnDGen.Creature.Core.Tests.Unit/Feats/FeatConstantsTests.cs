﻿using DnDGen.Creature.Core.Feats;
using NUnit.Framework;
using System.Linq;
using System.Reflection;

namespace DnDGen.Creature.Core.Tests.Unit.Feats
{
    [TestFixture]
    public class FeatConstantsTests
    {
        [TestCase(FeatConstants.Acrobatic, "Acrobatic")]
        [TestCase(FeatConstants.Agile, "Agile")]
        [TestCase(FeatConstants.Alertness, "Alertness")]
        [TestCase(FeatConstants.AnimalAffinity, "Animal Affinity")]
        [TestCase(FeatConstants.ArmorProficiency_Heavy, "Armor Proficiency (Heavy)")]
        [TestCase(FeatConstants.ArmorProficiency_Light, "Armor Proficiency (Light)")]
        [TestCase(FeatConstants.ArmorProficiency_Medium, "Armor Proficiency (Medium)")]
        [TestCase(FeatConstants.Athletic, "Athletic")]
        [TestCase(FeatConstants.AugmentSummoning, "Augment Summoning")]
        [TestCase(FeatConstants.BlindFight, "Blind-Fight")]
        [TestCase(FeatConstants.BullRush_Improved, "Improved Bull Rush")]
        [TestCase(FeatConstants.Cleave, "Cleave")]
        [TestCase(FeatConstants.Cleave_Great, "Great Cleave")]
        [TestCase(FeatConstants.CombatCasting, "Combat Casting")]
        [TestCase(FeatConstants.CombatExpertise, "Combat Expertise")]
        [TestCase(FeatConstants.CombatReflexes, "Combat Reflexes")]
        [TestCase(FeatConstants.Counterspell_Improved, "Improved Counterspell")]
        [TestCase(FeatConstants.Critical_Improved, "Improved Critical")]
        [TestCase(FeatConstants.Deceitful, "Deceitful")]
        [TestCase(FeatConstants.DeflectArrows, "Deflect Arrows")]
        [TestCase(FeatConstants.DeftHands, "Deft Hands")]
        [TestCase(FeatConstants.Diehard, "Diehard")]
        [TestCase(FeatConstants.Diligent, "Diligent")]
        [TestCase(FeatConstants.Disarm_Improved, "Improved Disarm")]
        [TestCase(FeatConstants.Dodge, "Dodge")]
        [TestCase(FeatConstants.Endurance, "Endurance")]
        [TestCase(FeatConstants.EschewMaterials, "Eschew Materials")]
        [TestCase(FeatConstants.Familiar_Improved, "Improved Familiar")]
        [TestCase(FeatConstants.FarShot, "Far Shot")]
        [TestCase(FeatConstants.Feint_Improved, "Improved Feint")]
        [TestCase(FeatConstants.Grapple_Improved, "Improved Grapple")]
        [TestCase(FeatConstants.GreatFortitude, "Great Fortitude")]
        [TestCase(FeatConstants.Initiative_Improved, "Improved Initiative")]
        [TestCase(FeatConstants.Investigator, "Investigator")]
        [TestCase(FeatConstants.IronWill, "Iron Will")]
        [TestCase(FeatConstants.Leadership, "Leadership")]
        [TestCase(FeatConstants.LightningReflexes, "Lightning Reflexes")]
        [TestCase(FeatConstants.MagicalAptitude, "Magical Aptitude")]
        [TestCase(FeatConstants.Manyshot, "Manyshot")]
        [TestCase(FeatConstants.Mobility, "Mobility")]
        [TestCase(FeatConstants.MountedArchery, "Mounted Archery")]
        [TestCase(FeatConstants.MountedCombat, "Mounted Combat")]
        [TestCase(FeatConstants.NaturalSpell, "Natural Spell")]
        [TestCase(FeatConstants.Negotiator, "Negotiator")]
        [TestCase(FeatConstants.NimbleFingers, "Nimble Fingers")]
        [TestCase(FeatConstants.Overrun_Improved, "Improved Overrun")]
        [TestCase(FeatConstants.Persuasive, "Persuasive")]
        [TestCase(FeatConstants.PointBlankShot, "Point Blank Shot")]
        [TestCase(FeatConstants.PowerAttack, "Power Attack")]
        [TestCase(FeatConstants.PreciseShot, "Precise Shot")]
        [TestCase(FeatConstants.PreciseShot_Improved, "Improved Precise Shot")]
        [TestCase(FeatConstants.QuickDraw, "Quick Draw")]
        [TestCase(FeatConstants.RapidReload, "Rapid Reload")]
        [TestCase(FeatConstants.RapidShot, "Rapid Shot")]
        [TestCase(FeatConstants.RideByAttack, "Ride-By Attack")]
        [TestCase(FeatConstants.Run, "Run")]
        [TestCase(FeatConstants.SelfSufficient, "Self-Sufficient")]
        [TestCase(FeatConstants.ShieldProficiency, "Shield Proficiency")]
        [TestCase(FeatConstants.ShieldBash_Improved, "Improved Shield Bash")]
        [TestCase(FeatConstants.ShieldProficiency_Tower, "Tower Shield Proficiency")]
        [TestCase(FeatConstants.ShotOnTheRun, "Shot On The Run")]
        [TestCase(FeatConstants.SkillFocus, "Skill Focus")]
        [TestCase(FeatConstants.SnatchArrows, "Snatch Arrows")]
        [TestCase(FeatConstants.SpellFocus, "Spell Focus")]
        [TestCase(FeatConstants.SpellFocus_Greater, "Greater Spell Focus")]
        [TestCase(FeatConstants.SpellMastery, "Spell Mastery")]
        [TestCase(FeatConstants.SpellPenetration, "Spell Penetration")]
        [TestCase(FeatConstants.SpellPenetration_Greater, "Greater Spell Penetration")]
        [TestCase(FeatConstants.SpiritedCharge, "Spirited Charge")]
        [TestCase(FeatConstants.SpringAttack, "Spring Attack")]
        [TestCase(FeatConstants.Stealthy, "Stealthy")]
        [TestCase(FeatConstants.StunningFist, "Stunning Fist")]
        [TestCase(FeatConstants.Sunder_Improved, "Improved Sunder")]
        [TestCase(FeatConstants.Toughness, "Toughness")]
        [TestCase(FeatConstants.Track, "Track")]
        [TestCase(FeatConstants.Trample, "Trample")]
        [TestCase(FeatConstants.Trip_Improved, "Improved Trip")]
        [TestCase(FeatConstants.Turning_Extra, "Extra Turning")]
        [TestCase(FeatConstants.Turning_Improved, "Improved Turning")]
        [TestCase(FeatConstants.TwoWeaponDefense, "Two-Weapon Defense")]
        [TestCase(FeatConstants.TwoWeaponFighting, "Two-Weapon Fighting")]
        [TestCase(FeatConstants.TwoWeaponFighting_Greater, "Greater Two-Weapon Fighting")]
        [TestCase(FeatConstants.TwoWeaponFighting_Improved, "Improved Two-Weapon Fighting")]
        [TestCase(FeatConstants.UnarmedStrike_Improved, "Improved Unarmed Strike")]
        [TestCase(FeatConstants.WeaponFinesse, "Weapon Finesse")]
        [TestCase(FeatConstants.WeaponFocus, "Weapon Focus")]
        [TestCase(FeatConstants.WeaponFocus_Greater, "Greater Weapon Focus")]
        [TestCase(FeatConstants.WeaponProficiency_Exotic, "Exotic Weapon Proficiency")]
        [TestCase(FeatConstants.WeaponProficiency_Martial, "Martial Weapon Proficiency")]
        [TestCase(FeatConstants.WeaponProficiency_Simple, "Simple Weapon Proficiency")]
        [TestCase(FeatConstants.WeaponSpecialization, "Weapon Specialization")]
        [TestCase(FeatConstants.WeaponSpecialization_Greater, "Greater Weapon Specialization")]
        [TestCase(FeatConstants.WhirlwindAttack, "Whirlwind Attack")]
        public void FeatConstant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void AllFeatConstants()
        {
            var creatures = FeatConstants.All();
            var creatureConstants = typeof(FeatConstants);
            var fields = creatureConstants.GetFields(BindingFlags.Public | BindingFlags.Static);
            var constantFields = fields.Where(f => f.IsLiteral && !f.IsInitOnly);
            var constants = constantFields.Select(f => f.GetValue(null) as string);

            Assert.That(creatures, Is.EquivalentTo(constants));
        }

        [TestCase(FeatConstants.MagicItemCreation.BrewPotion, "Brew Potion")]
        [TestCase(FeatConstants.MagicItemCreation.CraftMagicArmsAndArmor, "Craft Magic Arms and Armor")]
        [TestCase(FeatConstants.MagicItemCreation.CraftRod, "Craft Rod")]
        [TestCase(FeatConstants.MagicItemCreation.CraftStaff, "Craft Staff")]
        [TestCase(FeatConstants.MagicItemCreation.CraftWand, "Craft Wand")]
        [TestCase(FeatConstants.MagicItemCreation.CraftWondrousItem, "Craft Wondrous Item")]
        [TestCase(FeatConstants.MagicItemCreation.ForgeRing, "Forge Ring")]
        [TestCase(FeatConstants.MagicItemCreation.ScribeScroll, "Scribe Scroll")]
        public void MagicItemCreationFeatConstant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void AllMagicItemCreationFeatConstants()
        {
            var creatures = FeatConstants.MagicItemCreation.All();
            var creatureConstants = typeof(FeatConstants.MagicItemCreation);
            var fields = creatureConstants.GetFields(BindingFlags.Public | BindingFlags.Static);
            var constantFields = fields.Where(f => f.IsLiteral && !f.IsInitOnly);
            var constants = constantFields.Select(f => f.GetValue(null) as string);

            Assert.That(creatures, Is.EquivalentTo(constants));
        }

        [TestCase(FeatConstants.Metamagic.EmpowerSpell, "Empower Spell")]
        [TestCase(FeatConstants.Metamagic.EnlargeSpell, "Enlarge Spell")]
        [TestCase(FeatConstants.Metamagic.ExtendSpell, "Extend Spell")]
        [TestCase(FeatConstants.Metamagic.HeightenSpell, "Heighten Spell")]
        [TestCase(FeatConstants.Metamagic.MaximizeSpell, "Maximize Spell")]
        [TestCase(FeatConstants.Metamagic.QuickenSpell, "Quicken Spell")]
        [TestCase(FeatConstants.Metamagic.SilentSpell, "Silent Spell")]
        [TestCase(FeatConstants.Metamagic.StillSpell, "Still Spell")]
        [TestCase(FeatConstants.Metamagic.WidenSpell, "Widen Spell")]
        public void MetamagicFeatConstant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void AllMetamagicFeatConstants()
        {
            var creatures = FeatConstants.Metamagic.All();
            var creatureConstants = typeof(FeatConstants.Metamagic);
            var fields = creatureConstants.GetFields(BindingFlags.Public | BindingFlags.Static);
            var constantFields = fields.Where(f => f.IsLiteral && !f.IsInitOnly);
            var constants = constantFields.Select(f => f.GetValue(null) as string);

            Assert.That(creatures, Is.EquivalentTo(constants));
        }

        [TestCase(FeatConstants.Monster.AbilityFocus, "Ability Focus")]
        [TestCase(FeatConstants.Monster.AwesomeBlow, "Awesome Blow")]
        [TestCase(FeatConstants.Monster.CraftConstruct, "Craft Construct")]
        [TestCase(FeatConstants.Monster.EmpowerSpellLikeAbility, "Empower Spell-Like Ability")]
        [TestCase(FeatConstants.Monster.FlybyAttack, "Flyby Attack")]
        [TestCase(FeatConstants.Monster.FlybyAttack_Improved, "Improved Flyby Attack")]
        [TestCase(FeatConstants.Monster.Hover, "Hover")]
        [TestCase(FeatConstants.Monster.Multiattack, "Multiattack")]
        [TestCase(FeatConstants.Monster.Multiattack_Improved, "Improved Multiattack")]
        [TestCase(FeatConstants.Monster.NaturalArmor_Improved, "Improved Natural Armor")]
        [TestCase(FeatConstants.Monster.NaturalAttack_Improved, "Improved Natural Attack")]
        [TestCase(FeatConstants.Monster.MultiweaponFighting, "Multiweapon Fighting")]
        [TestCase(FeatConstants.Monster.MultiweaponFighting_Improved, "Improved Multiweapon Fighting")]
        [TestCase(FeatConstants.Monster.MultiweaponFighting_Greater, "Greater Multiweapon Fighting")]
        [TestCase(FeatConstants.Monster.QuickenSpellLikeAbility, "Quicken Spell-Like Ability")]
        [TestCase(FeatConstants.Monster.Snatch, "Snatch")]
        [TestCase(FeatConstants.Monster.Wingover, "Wingover")]
        public void MonsterFeatConstant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void AllMonsterFeatConstants()
        {
            var creatures = FeatConstants.Monster.All();
            var creatureConstants = typeof(FeatConstants.Monster);
            var fields = creatureConstants.GetFields(BindingFlags.Public | BindingFlags.Static);
            var constantFields = fields.Where(f => f.IsLiteral && !f.IsInitOnly);
            var constants = constantFields.Select(f => f.GetValue(null) as string);

            Assert.That(creatures, Is.EquivalentTo(constants));
        }

        [TestCase(FeatConstants.SpecialQualities.AttackBonus, "Attack Bonus")]
        [TestCase(FeatConstants.SpecialQualities.DodgeBonus, "Dodge Bonus")]
        [TestCase(FeatConstants.SpecialQualities.DodgeBonus, "Dodge Bonus")]
        [TestCase(FeatConstants.SpecialQualities.InertialArmor, "Inertial Armor")]
        [TestCase(FeatConstants.SpecialQualities.SaveBonus, "Save Bonus")]
        [TestCase(FeatConstants.SpecialQualities.SkillBonus, "Skill Bonus")]
        [TestCase(FeatConstants.SpecialQualities.SpellResistance, "Spell Resistance")]
        [TestCase(FeatConstants.SpecialQualities.WeaponFamiliarity, "Weapon Familiarity")]
        public void SpecialQualityTests(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void AllSpecialQualityConstants()
        {
            var creatures = FeatConstants.SpecialQualities.All();
            var creatureConstants = typeof(FeatConstants.SpecialQualities);
            var fields = creatureConstants.GetFields(BindingFlags.Public | BindingFlags.Static);
            var constantFields = fields.Where(f => f.IsLiteral && !f.IsInitOnly);
            var constants = constantFields.Select(f => f.GetValue(null) as string);

            Assert.That(creatures, Is.EquivalentTo(constants));
        }

        [TestCase(FeatConstants.Frequencies.AtWill, "At Will")]
        [TestCase(FeatConstants.Frequencies.Constant, "Constant")]
        [TestCase(FeatConstants.Frequencies.Day, "Day")]
        [TestCase(FeatConstants.Frequencies.Hit, "Hit")]
        [TestCase(FeatConstants.Frequencies.Round, "Round")]
        [TestCase(FeatConstants.Frequencies.Turn, "Turn")]
        [TestCase(FeatConstants.Frequencies.Week, "Week")]
        public void FeatFrequencyConstant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [TestCase(FeatConstants.Foci.All, "All")]
        [TestCase(FeatConstants.Foci.Element, "Element")]
        [TestCase(FeatConstants.Foci.School, "School")]
        [TestCase(FeatConstants.Foci.Weapon, "Weapon")]
        [TestCase(FeatConstants.Foci.Elements.Acid, "Acid")]
        [TestCase(FeatConstants.Foci.Elements.Cold, "Cold")]
        [TestCase(FeatConstants.Foci.Elements.Electricity, "Electricity")]
        [TestCase(FeatConstants.Foci.Elements.Fire, "Fire")]
        [TestCase(FeatConstants.Foci.Elements.Sonic, "Sonic")]
        [TestCase(FeatConstants.Foci.Schools.Abjuration, "Abjuration")]
        [TestCase(FeatConstants.Foci.Schools.Conjuration, "Conjuration")]
        [TestCase(FeatConstants.Foci.Schools.Divination, "Divination")]
        [TestCase(FeatConstants.Foci.Schools.Enchantment, "Enchantment")]
        [TestCase(FeatConstants.Foci.Schools.Evocation, "Evocation")]
        [TestCase(FeatConstants.Foci.Schools.Illusion, "Illusion")]
        [TestCase(FeatConstants.Foci.Schools.Necromancy, "Necromancy")]
        [TestCase(FeatConstants.Foci.Schools.Transmutation, "Transmutation")]
        public void FeatFocusConstant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
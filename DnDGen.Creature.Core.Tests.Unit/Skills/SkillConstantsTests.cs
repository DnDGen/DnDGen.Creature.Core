﻿using DnDGen.Creature.Core.Skills;
using NUnit.Framework;

namespace DnDGen.Creature.Core.Tests.Unit.Skills
{
    [TestFixture]
    public class SkillConstantsTests
    {
        [TestCase(SkillConstants.Appraise, "Appraise")]
        [TestCase(SkillConstants.Balance, "Balance")]
        [TestCase(SkillConstants.Bluff, "Bluff")]
        [TestCase(SkillConstants.Climb, "Climb")]
        [TestCase(SkillConstants.Concentration, "Concentration")]
        [TestCase(SkillConstants.Craft, "Craft")]
        [TestCase(SkillConstants.DecipherScript, "Decipher Script")]
        [TestCase(SkillConstants.Diplomacy, "Diplomacy")]
        [TestCase(SkillConstants.DisableDevice, "Disable Device")]
        [TestCase(SkillConstants.Disguise, "Disguise")]
        [TestCase(SkillConstants.EscapeArtist, "Escape Artist")]
        [TestCase(SkillConstants.Forgery, "Forgery")]
        [TestCase(SkillConstants.GatherInformation, "Gather Information")]
        [TestCase(SkillConstants.HandleAnimal, "Handle Animal")]
        [TestCase(SkillConstants.Heal, "Heal")]
        [TestCase(SkillConstants.Hide, "Hide")]
        [TestCase(SkillConstants.Intimidate, "Intimidate")]
        [TestCase(SkillConstants.Jump, "Jump")]
        [TestCase(SkillConstants.Knowledge, "Knowledge")]
        [TestCase(SkillConstants.Listen, "Listen")]
        [TestCase(SkillConstants.MoveSilently, "Move Silently")]
        [TestCase(SkillConstants.OpenLock, "Open Lock")]
        [TestCase(SkillConstants.Perform, "Perform")]
        [TestCase(SkillConstants.Profession, "Profession")]
        [TestCase(SkillConstants.Ride, "Ride")]
        [TestCase(SkillConstants.Search, "Search")]
        [TestCase(SkillConstants.SenseMotive, "Sense Motive")]
        [TestCase(SkillConstants.SleightOfHand, "Sleight of Hand")]
        [TestCase(SkillConstants.Spellcraft, "Spellcraft")]
        [TestCase(SkillConstants.Spot, "Spot")]
        [TestCase(SkillConstants.Survival, "Survival")]
        [TestCase(SkillConstants.Swim, "Swim")]
        [TestCase(SkillConstants.Tumble, "Tumble")]
        [TestCase(SkillConstants.UseMagicDevice, "Use Magic Device")]
        [TestCase(SkillConstants.UseRope, "Use Rope")]
        [TestCase(SkillConstants.Foci.Craft.Alchemy, "Alchemy")]
        [TestCase(SkillConstants.Foci.Craft.Armorsmithing, "Armorsmithing")]
        [TestCase(SkillConstants.Foci.Craft.Blacksmithing, "Blacksmithing")]
        [TestCase(SkillConstants.Foci.Craft.Bookbinding, "Bookbinding")]
        [TestCase(SkillConstants.Foci.Craft.Bowmaking, "Bowmaking")]
        [TestCase(SkillConstants.Foci.Craft.Brassmaking, "Brassmaking")]
        [TestCase(SkillConstants.Foci.Craft.Brewing, "Brewing")]
        [TestCase(SkillConstants.Foci.Craft.Candlemaking, "Candlemaking")]
        [TestCase(SkillConstants.Foci.Craft.Cloth, "Cloth")]
        [TestCase(SkillConstants.Foci.Craft.Coppersmithing, "Coppersmithing")]
        [TestCase(SkillConstants.Foci.Craft.Dyemaking, "Dyemaking")]
        [TestCase(SkillConstants.Foci.Craft.Gemcutting, "Gemcutting")]
        [TestCase(SkillConstants.Foci.Craft.Glass, "Glass")]
        [TestCase(SkillConstants.Foci.Craft.Goldsmithing, "Goldsmithing")]
        [TestCase(SkillConstants.Foci.Craft.Hatmaking, "Hatmaking")]
        [TestCase(SkillConstants.Foci.Craft.Hornworking, "Hornworking")]
        [TestCase(SkillConstants.Foci.Craft.Jewelmaking, "Jewelmaking")]
        [TestCase(SkillConstants.Foci.Craft.Leather, "Leather")]
        [TestCase(SkillConstants.Foci.Craft.Locksmithing, "Locksmithing")]
        [TestCase(SkillConstants.Foci.Craft.Mapmaking, "Mapmaking")]
        [TestCase(SkillConstants.Foci.Craft.Milling, "Milling")]
        [TestCase(SkillConstants.Foci.Craft.Painting, "Painting")]
        [TestCase(SkillConstants.Foci.Craft.Parchmentmaking, "Parchmentmaking")]
        [TestCase(SkillConstants.Foci.Craft.Pewtermaking, "Pewtermaking")]
        [TestCase(SkillConstants.Foci.Craft.Potterymaking, "Potterymaking")]
        [TestCase(SkillConstants.Foci.Craft.Sculpting, "Sculpting")]
        [TestCase(SkillConstants.Foci.Craft.Shipmaking, "Shipmaking")]
        [TestCase(SkillConstants.Foci.Craft.Shoemaking, "Shoemaking")]
        [TestCase(SkillConstants.Foci.Craft.Silversmithing, "Silversmithing")]
        [TestCase(SkillConstants.Foci.Craft.Skinning, "Skinning")]
        [TestCase(SkillConstants.Foci.Craft.Soapmaking, "Soapmaking")]
        [TestCase(SkillConstants.Foci.Craft.Stonemasonry, "Stonemasonry")]
        [TestCase(SkillConstants.Foci.Craft.Tanning, "Tanning")]
        [TestCase(SkillConstants.Foci.Craft.Trapmaking, "Trapmaking")]
        [TestCase(SkillConstants.Foci.Craft.Weaponsmithing, "Weaponsmithing")]
        [TestCase(SkillConstants.Foci.Craft.Weaving, "Weaving")]
        [TestCase(SkillConstants.Foci.Craft.Wheelmaking, "Wheelmaking")]
        [TestCase(SkillConstants.Foci.Craft.Winemaking, "Winemaking")]
        [TestCase(SkillConstants.Foci.Craft.Woodworking, "Woodworking")]
        [TestCase(SkillConstants.Foci.Knowledge.Arcana, "Arcana")]
        [TestCase(SkillConstants.Foci.Knowledge.ArchitectureAndEngineering, "Architecture and Engineering")]
        [TestCase(SkillConstants.Foci.Knowledge.Dungeoneering, "Dungeoneering")]
        [TestCase(SkillConstants.Foci.Knowledge.Geography, "Geography")]
        [TestCase(SkillConstants.Foci.Knowledge.History, "History")]
        [TestCase(SkillConstants.Foci.Knowledge.Local, "Local")]
        [TestCase(SkillConstants.Foci.Knowledge.Nature, "Nature")]
        [TestCase(SkillConstants.Foci.Knowledge.NobilityAndRoyalty, "Nobility and Royalty")]
        [TestCase(SkillConstants.Foci.Knowledge.Religion, "Religion")]
        [TestCase(SkillConstants.Foci.Knowledge.ThePlanes, "The Planes")]
        [TestCase(SkillConstants.Foci.Perform.Act, "Act")]
        [TestCase(SkillConstants.Foci.Perform.Comedy, "Comedy")]
        [TestCase(SkillConstants.Foci.Perform.Dance, "Dance")]
        [TestCase(SkillConstants.Foci.Perform.KeyboardInstruments, "Keyboard instruments")]
        [TestCase(SkillConstants.Foci.Perform.Oratory, "Oratory")]
        [TestCase(SkillConstants.Foci.Perform.PercussionInstruments, "Percussion instruments")]
        [TestCase(SkillConstants.Foci.Perform.StringInstruments, "String instruments")]
        [TestCase(SkillConstants.Foci.Perform.WindInstruments, "Wind instruments")]
        [TestCase(SkillConstants.Foci.Perform.Sing, "Sing")]
        [TestCase(SkillConstants.Foci.Profession.Adviser, "Adviser")]
        [TestCase(SkillConstants.Foci.Profession.Alchemist, "Alchemist")]
        [TestCase(SkillConstants.Foci.Profession.AnimalGroomer, "Animal Groomer")]
        [TestCase(SkillConstants.Foci.Profession.AnimalTrainer, "Animal Trainer")]
        [TestCase(SkillConstants.Foci.Profession.ExoticAnimalTrainer, "Exotic Animal Trainer")]
        [TestCase(SkillConstants.Foci.Profession.Apothecary, "Apothecary")]
        [TestCase(SkillConstants.Foci.Profession.Appraiser, "Appraiser")]
        [TestCase(SkillConstants.Foci.Profession.Architect, "Architect")]
        [TestCase(SkillConstants.Foci.Profession.Armorer, "Armorer")]
        [TestCase(SkillConstants.Foci.Profession.Barrister, "Barrister")]
        [TestCase(SkillConstants.Foci.Profession.Blacksmith, "Blacksmith")]
        [TestCase(SkillConstants.Foci.Profession.Bookbinder, "Bookbinder")]
        [TestCase(SkillConstants.Foci.Profession.Bowyer, "Bowyer")]
        [TestCase(SkillConstants.Foci.Profession.Brazier, "Brazier")]
        [TestCase(SkillConstants.Foci.Profession.Brewer, "Brewer")]
        [TestCase(SkillConstants.Foci.Profession.Butler, "Butler")]
        [TestCase(SkillConstants.Foci.Profession.Carpenter, "Carpenter")]
        [TestCase(SkillConstants.Foci.Profession.Cartographer, "Cartographer")]
        [TestCase(SkillConstants.Foci.Profession.Cartwright, "Cartwright")]
        [TestCase(SkillConstants.Foci.Profession.Chandler, "Chandler")]
        [TestCase(SkillConstants.Foci.Profession.Clerk, "Clerk")]
        [TestCase(SkillConstants.Foci.Profession.Cobbler, "Cobbler")]
        [TestCase(SkillConstants.Foci.Profession.Coiffeur, "Coiffeur")]
        [TestCase(SkillConstants.Foci.Profession.Coffinmaker, "Coffinmaker")]
        [TestCase(SkillConstants.Foci.Profession.Cook, "Cook")]
        [TestCase(SkillConstants.Foci.Profession.LocalCourier, "Local Courier")]
        [TestCase(SkillConstants.Foci.Profession.OutOfTownCourier, "Out-of-Town Courier")]
        [TestCase(SkillConstants.Foci.Profession.Coppersmith, "Coppersmith")]
        [TestCase(SkillConstants.Foci.Profession.Dowser, "Dowser")]
        [TestCase(SkillConstants.Foci.Profession.Dyer, "Dyer")]
        [TestCase(SkillConstants.Foci.Profession.Embalmer, "Embalmer")]
        [TestCase(SkillConstants.Foci.Profession.Engineer, "Engineer")]
        [TestCase(SkillConstants.Foci.Profession.Entertainer, "Entertainer")]
        [TestCase(SkillConstants.Foci.Profession.Farmer, "Farmer")]
        [TestCase(SkillConstants.Foci.Profession.Fletcher, "Fletcher")]
        [TestCase(SkillConstants.Foci.Profession.Footman, "Footman")]
        [TestCase(SkillConstants.Foci.Profession.Gemcutter, "Gemcutter")]
        [TestCase(SkillConstants.Foci.Profession.Goldsmith, "Goldsmith")]
        [TestCase(SkillConstants.Foci.Profession.Governess, "Governess")]
        [TestCase(SkillConstants.Foci.Profession.WildernessGuide, "Wilderness Guide")]
        [TestCase(SkillConstants.Foci.Profession.CityGuide, "City Guide")]
        [TestCase(SkillConstants.Foci.Profession.Haberdasher, "Haberdasher")]
        [TestCase(SkillConstants.Foci.Profession.Healer, "Healer")]
        [TestCase(SkillConstants.Foci.Profession.Horner, "Horner")]
        [TestCase(SkillConstants.Foci.Profession.Hunter, "Hunter")]
        [TestCase(SkillConstants.Foci.Profession.Interpreter, "Interpreter")]
        [TestCase(SkillConstants.Foci.Profession.Jeweler, "Jeweler")]
        [TestCase(SkillConstants.Foci.Profession.Laborer, "Laborer")]
        [TestCase(SkillConstants.Foci.Profession.Craftsman, "Craftsman")]
        [TestCase(SkillConstants.Foci.Profession.Launderer, "Launderer")]
        [TestCase(SkillConstants.Foci.Profession.Limner, "Limner")]
        [TestCase(SkillConstants.Foci.Profession.Locksmith, "Locksmith")]
        [TestCase(SkillConstants.Foci.Profession.Maid, "Maid")]
        [TestCase(SkillConstants.Foci.Profession.Masseuse, "Masseuse")]
        [TestCase(SkillConstants.Foci.Profession.Matchmaker, "Matchmaker")]
        [TestCase(SkillConstants.Foci.Profession.Midwife, "Midwife")]
        [TestCase(SkillConstants.Foci.Profession.Miller, "Miller")]
        [TestCase(SkillConstants.Foci.Profession.Navigator, "Navigator")]
        [TestCase(SkillConstants.Foci.Profession.Nursemaid, "Nursemaid")]
        [TestCase(SkillConstants.Foci.Profession.Painter, "Painter")]
        [TestCase(SkillConstants.Foci.Profession.Parchmentmaker, "Parchmentmaker")]
        [TestCase(SkillConstants.Foci.Profession.Pewterer, "Pewterer")]
        [TestCase(SkillConstants.Foci.Profession.Polisher, "Polisher")]
        [TestCase(SkillConstants.Foci.Profession.Porter, "Porter")]
        [TestCase(SkillConstants.Foci.Profession.Potter, "Potter")]
        [TestCase(SkillConstants.Foci.Profession.Sage, "Sage")]
        [TestCase(SkillConstants.Foci.Profession.SailorCrewmember, "Sailor Crewmember")]
        [TestCase(SkillConstants.Foci.Profession.SailorMate, "Sailor Mate")]
        [TestCase(SkillConstants.Foci.Profession.Scribe, "Scribe")]
        [TestCase(SkillConstants.Foci.Profession.Sculptor, "Sculptor")]
        [TestCase(SkillConstants.Foci.Profession.Shepherd, "Shepherd")]
        [TestCase(SkillConstants.Foci.Profession.Shipwright, "Shipwright")]
        [TestCase(SkillConstants.Foci.Profession.Silversmith, "Silversmith")]
        [TestCase(SkillConstants.Foci.Profession.Skinner, "Skinner")]
        [TestCase(SkillConstants.Foci.Profession.Soapmaker, "Soapmaker")]
        [TestCase(SkillConstants.Foci.Profession.Soothsayer, "Soothsayer")]
        [TestCase(SkillConstants.Foci.Profession.Tanner, "Tanner")]
        [TestCase(SkillConstants.Foci.Profession.Teacher, "Teacher")]
        [TestCase(SkillConstants.Foci.Profession.Teamster, "Teamster")]
        [TestCase(SkillConstants.Foci.Profession.Trader, "Trader")]
        [TestCase(SkillConstants.Foci.Profession.Valet, "Valet")]
        [TestCase(SkillConstants.Foci.Profession.Vintner, "Vintner")]
        [TestCase(SkillConstants.Foci.Profession.Weaponsmith, "Weaponsmith")]
        [TestCase(SkillConstants.Foci.Profession.Weaver, "Weaver")]
        [TestCase(SkillConstants.Foci.Profession.Wheelwright, "Wheelwright")]
        public void SkillConstant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [TestCase(SkillConstants.Foci.QuantityOfAll, int.MaxValue)]
        public void SkillConstant(int constant, int value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
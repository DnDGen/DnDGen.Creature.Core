﻿using DnDGen.Creature.Core.Abilities;
using DnDGen.Creature.Core.Defenses;
using DnDGen.Creature.Core.Feats;
using DnDGen.Creature.Core.Generators.Defenses;
using DnDGen.Creature.Core.Selectors.Collections;
using DnDGen.Creature.Core.Tables;
using DnDGen.Core.Selectors.Collections;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.Creature.Core.Tests.Unit.Generators.Defenses
{
    [TestFixture]
    public class ArmorClassGeneratorTests
    {
        private IArmorClassGenerator armorClassGenerator;
        private List<Feat> feats;
        private Mock<ICollectionSelector> mockCollectionsSelector;
        private Mock<IAdjustmentsSelector> mockAdjustmentsSelector;
        private Ability dexterity;

        [SetUp]
        public void Setup()
        {
            mockAdjustmentsSelector = new Mock<IAdjustmentsSelector>();
            mockCollectionsSelector = new Mock<ICollectionSelector>();
            armorClassGenerator = new ArmorClassGenerator(mockCollectionsSelector.Object, mockAdjustmentsSelector.Object);
            feats = new List<Feat>();
            dexterity = new Ability(AbilityConstants.Dexterity);

            mockAdjustmentsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Adjustments.SizeModifiers, "size")).Returns(0);
            mockAdjustmentsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Adjustments.ArmorDeflectionBonuses, "creature")).Returns(0);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.ArmorClassModifiers, GroupConstants.NaturalArmor)).Returns(Enumerable.Empty<string>());
        }

        [Test]
        public void ArmorClassesStartsAtBase()
        {
            GenerateAndAssertArmorClass();
        }

        private ArmorClass GenerateAndAssertArmorClass(int full = ArmorClass.BaseArmorClass, int flatFooted = ArmorClass.BaseArmorClass, int touch = ArmorClass.BaseArmorClass, bool circumstantial = false)
        {
            var armorClass = armorClassGenerator.GenerateWith(dexterity, "size", "creature", feats);
            Assert.That(armorClass.TotalBonus, Is.EqualTo(full), "full");
            Assert.That(armorClass.FlatFootedBonus, Is.EqualTo(flatFooted), "flat-footed");
            Assert.That(armorClass.TouchBonus, Is.EqualTo(touch), "touch");
            Assert.That(armorClass.CircumstantialBonus, Is.EqualTo(circumstantial));

            return armorClass;
        }

        //INFO: Example here is Githzerai's Inertial Armor
        [Test]
        public void AddArmorBonusFromFeats()
        {
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.ArmorClassModifiers, GroupConstants.ArmorBonus))
                .Returns(new[] { "bracers", "other item", "feat", "wrong feat" });

            feats.Add(new Feat());
            feats.Add(new Feat());
            feats[0].Name = "feat";
            feats[0].Power = 1;
            feats[1].Name = "other feat";
            feats[1].Power = -1;

            var armorClass = GenerateAndAssertArmorClass(11, 11);
            Assert.That(armorClass.ArmorBonus, Is.EqualTo(1));
        }

        [Test]
        public void DexterityBonusApplied()
        {
            dexterity.BaseScore = 12;
            var armorClass = GenerateAndAssertArmorClass(11, touch: 11);
        }

        [Test]
        public void NegativeDexterityBonusApplied()
        {
            dexterity.BaseScore = 9;
            var armorClass = GenerateAndAssertArmorClass(9, touch: 9);
        }

        [Test]
        public void DeflectionBonusApplied()
        {
            mockAdjustmentsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Adjustments.ArmorDeflectionBonuses, "creature")).Returns(1);

            var armorClass = GenerateAndAssertArmorClass(11, 11, 11);
            Assert.That(armorClass.DeflectionBonus, Is.EqualTo(1));
        }

        [Test]
        public void TotalNaturalArmorBonusFromFeatApplied()
        {
            feats.Add(new Feat());
            feats.Add(new Feat());
            feats[0].Name = "feat 1";
            feats[0].Power = 1;
            feats[1].Name = "feat 2";
            feats[1].Power = 1;

            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.ArmorClassModifiers, GroupConstants.NaturalArmor))
                .Returns(new[] { "feat 1", "feat 2", "other feat" });

            var armorClass = GenerateAndAssertArmorClass(12, 12);
            Assert.That(armorClass.NaturalArmorBonus, Is.EqualTo(2));
        }

        [Test]
        public void IfNaturalArmorHasCircumstantialArmorBonus_MarkCircumstantialBonus()
        {
            feats.Add(new Feat());
            feats.Add(new Feat());
            feats[0].Name = "feat 1";
            feats[0].Power = 1;
            feats[1].Name = "feat 2";
            feats[1].Foci = new[] { "focus" };
            feats[1].Power = 1;

            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.ArmorClassModifiers, GroupConstants.NaturalArmor))
                .Returns(new[] { "feat 1", "feat 2", "other feat" });

            var armorClass = GenerateAndAssertArmorClass(11, 11, circumstantial: true);
            Assert.That(armorClass.NaturalArmorBonus, Is.EqualTo(1));
        }

        [Test]
        public void DoNotOverwriteCircumstantialBonus()
        {
            feats.Add(new Feat());
            feats.Add(new Feat());
            feats[0].Name = "feat 1";
            feats[0].Foci = new[] { "focus" };
            feats[0].Power = 1;
            feats[1].Name = "feat 2";
            feats[1].Power = 1;

            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.ArmorClassModifiers, GroupConstants.NaturalArmor))
                .Returns(new[] { "feat 1", "feat 2", "other feat" });

            var armorClass = GenerateAndAssertArmorClass(11, 11, circumstantial: true);
            Assert.That(armorClass.NaturalArmorBonus, Is.EqualTo(1));
        }

        [Test]
        public void SizeModifiesArmorClass()
        {
            mockAdjustmentsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Adjustments.SizeModifiers, "size")).Returns(9266);

            var armorClass = GenerateAndAssertArmorClass(9276, 9276, 9276);
            Assert.That(armorClass.SizeModifier, Is.EqualTo(9266));
        }

        [Test]
        public void SizeModifiesArmorClassNegatively()
        {
            mockAdjustmentsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Adjustments.SizeModifiers, "size")).Returns(-4);

            var armorClass = GenerateAndAssertArmorClass(6, 6, 6);
            Assert.That(armorClass.SizeModifier, Is.EqualTo(-4));
        }

        [Test]
        public void ArmorClassesAreSummed()
        {
            dexterity.BaseScore = 12;

            var feat = new Feat();
            feat.Name = "feat 1";
            feat.Power = 1;
            feats.Add(feat);

            var otherFeat = new Feat();
            otherFeat.Name = "feat 2";
            otherFeat.Power = 1;
            feats.Add(otherFeat);

            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.ArmorClassModifiers, GroupConstants.NaturalArmor))
                .Returns(new[] { "feat 1" });

            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Collection.ArmorClassModifiers, GroupConstants.ArmorBonus))
                .Returns(new[] { "feat 1" });

            mockAdjustmentsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Adjustments.SizeModifiers, "size")).Returns(1);
            mockAdjustmentsSelector.Setup(s => s.SelectFrom(TableNameConstants.Set.Adjustments.ArmorDeflectionBonuses, "creature")).Returns(1);

            var armorClass = GenerateAndAssertArmorClass(15, 14, 13);
            Assert.That(armorClass.ArmorBonus, Is.EqualTo(1));
            Assert.That(armorClass.DeflectionBonus, Is.EqualTo(1));
            Assert.That(armorClass.NaturalArmorBonus, Is.EqualTo(1));
            Assert.That(armorClass.ShieldBonus, Is.EqualTo(0));
            Assert.That(armorClass.SizeModifier, Is.EqualTo(1));
            Assert.That(armorClass.Dexterity.Modifier, Is.EqualTo(1));
        }
    }
}
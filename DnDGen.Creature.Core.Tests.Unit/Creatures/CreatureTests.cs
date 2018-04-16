﻿using DnDGen.Creature.Core.Attacks;
using DnDGen.Creature.Core.Creatures;
using NUnit.Framework;
using System;
using System.Linq;

namespace DnDGen.Creature.Core.Tests.Unit.Creatures
{
    [TestFixture]
    public class CreatureTests
    {
        private Creature creature;

        [SetUp]
        public void Setup()
        {
            creature = new Creature();
        }

        [Test]
        public void CreatureInitialized()
        {
            Assert.That(creature.Abilities, Is.Empty);
            Assert.That(creature.Alignment, Is.Not.Null);
            Assert.That(creature.ArmorClass, Is.Not.Null);
            Assert.That(creature.Attacks, Is.Empty);
            Assert.That(creature.BaseAttackBonus, Is.Zero);
            Assert.That(creature.CanUseEquipment, Is.False);
            Assert.That(creature.ChallengeRating, Is.Empty);
            Assert.That(creature.Feats, Is.Empty);
            Assert.That(creature.FullMeleeAttack, Is.Empty);
            Assert.That(creature.FullRangedAttack, Is.Empty);
            Assert.That(creature.GrappleBonus, Is.Null);
            Assert.That(creature.HitPoints, Is.Not.Null);
            Assert.That(creature.InitiativeBonus, Is.Zero);
            Assert.That(creature.LevelAdjustment, Is.Null);
            Assert.That(creature.MeleeAttack, Is.Null);
            Assert.That(creature.Name, Is.Empty);
            Assert.That(creature.RangedAttack, Is.Null);
            Assert.That(creature.Reach, Is.Not.Null);
            Assert.That(creature.Reach.Unit, Is.EqualTo("feet"));
            Assert.That(creature.Saves, Is.Not.Null);
            Assert.That(creature.Size, Is.Empty);
            Assert.That(creature.Skills, Is.Empty);
            Assert.That(creature.Space, Is.Not.Null);
            Assert.That(creature.Space.Unit, Is.EqualTo("feet"));
            Assert.That(creature.SpecialAttacks, Is.Empty);
            Assert.That(creature.SpecialQualities, Is.Empty);
            Assert.That(creature.Speeds, Is.Empty);
            Assert.That(creature.Summary, Is.Empty);
            Assert.That(creature.Template, Is.Empty);
            Assert.That(creature.Type, Is.Not.Null);
        }

        [Test]
        public void MeleeAttackIsFirstPrimaryMeleeAttack()
        {
            creature.Attacks = new[]
            {
                new Attack { IsPrimary = false, IsMelee = false, IsSpecial = true, Name = "secondary ranged special attack" },
                new Attack { IsPrimary = false, IsMelee = false, IsSpecial = false, Name = "secondary ranged attack" },
                new Attack { IsPrimary = false, IsMelee = true, IsSpecial = true, Name = "secondary melee special attack" },
                new Attack { IsPrimary = false, IsMelee = true, IsSpecial = false, Name = "secondary melee attack" },
                new Attack { IsPrimary = true, IsMelee = false, IsSpecial = true, Name = "primary ranged special attack" },
                new Attack { IsPrimary = true, IsMelee = false, IsSpecial = false, Name = "primary ranged attack" },
                new Attack { IsPrimary = true, IsMelee = true, IsSpecial = true, Name = "primary melee special attack" },
                new Attack { IsPrimary = true, IsMelee = true, IsSpecial = false, Name = "primary melee attack" },
                new Attack { IsPrimary = true, IsMelee = true, IsSpecial = false, Name = "other primary melee attack" },
            };

            var attack = creature.MeleeAttack;
            Assert.That(attack.Name, Is.EqualTo("primary melee attack"));
        }

        [Test]
        public void MeleeAttackIsNotFirstPrimaryMeleeAttack()
        {
            creature.Attacks = new[]
            {
                new Attack { IsPrimary = false, IsMelee = false, IsSpecial = true, Name = "secondary ranged special attack" },
                new Attack { IsPrimary = false, IsMelee = false, IsSpecial = false, Name = "secondary ranged attack" },
                new Attack { IsPrimary = false, IsMelee = true, IsSpecial = true, Name = "secondary melee special attack" },
                new Attack { IsPrimary = false, IsMelee = true, IsSpecial = false, Name = "secondary melee attack" },
                new Attack { IsPrimary = true, IsMelee = false, IsSpecial = true, Name = "primary ranged special attack" },
                new Attack { IsPrimary = true, IsMelee = false, IsSpecial = false, Name = "primary ranged attack" },
                new Attack { IsPrimary = true, IsMelee = true, IsSpecial = true, Name = "primary melee special attack" },
            };

            var attack = creature.MeleeAttack;
            Assert.That(attack, Is.Null);
        }

        [Test]
        public void RangedAttackIsFirstPrimaryRangedAttack()
        {
            creature.Attacks = new[]
            {
                new Attack { IsPrimary = false, IsMelee = false, IsSpecial = true, Name = "secondary ranged special attack" },
                new Attack { IsPrimary = false, IsMelee = false, IsSpecial = false, Name = "secondary ranged attack" },
                new Attack { IsPrimary = false, IsMelee = true, IsSpecial = true, Name = "secondary melee special attack" },
                new Attack { IsPrimary = false, IsMelee = true, IsSpecial = false, Name = "secondary melee attack" },
                new Attack { IsPrimary = true, IsMelee = false, IsSpecial = true, Name = "primary ranged special attack" },
                new Attack { IsPrimary = true, IsMelee = true, IsSpecial = true, Name = "primary melee special attack" },
                new Attack { IsPrimary = true, IsMelee = true, IsSpecial = false, Name = "primary melee attack" },
                new Attack { IsPrimary = true, IsMelee = false, IsSpecial = false, Name = "primary ranged attack" },
                new Attack { IsPrimary = true, IsMelee = false, IsSpecial = false, Name = "other primary ranged attack" },
            };

            var attack = creature.RangedAttack;
            Assert.That(attack.Name, Is.EqualTo("primary ranged attack"));
        }

        [Test]
        public void RangedAttackIsNotFirstPrimaryRangedAttack()
        {
            creature.Attacks = new[]
            {
                new Attack { IsPrimary = false, IsMelee = false, IsSpecial = true, Name = "secondary ranged special attack" },
                new Attack { IsPrimary = false, IsMelee = false, IsSpecial = false, Name = "secondary ranged attack" },
                new Attack { IsPrimary = false, IsMelee = true, IsSpecial = true, Name = "secondary melee special attack" },
                new Attack { IsPrimary = false, IsMelee = true, IsSpecial = false, Name = "secondary melee attack" },
                new Attack { IsPrimary = true, IsMelee = false, IsSpecial = true, Name = "primary ranged special attack" },
                new Attack { IsPrimary = true, IsMelee = true, IsSpecial = true, Name = "primary melee special attack" },
                new Attack { IsPrimary = true, IsMelee = true, IsSpecial = false, Name = "primary melee attack" },
            };

            var attack = creature.RangedAttack;
            Assert.That(attack, Is.Null);
        }

        [Test]
        public void FullMeleeAttackIsAllMeleeAttacks()
        {
            creature.Attacks = new[]
            {
                new Attack { IsPrimary = false, IsMelee = false, IsSpecial = true, Name = "secondary ranged special attack" },
                new Attack { IsPrimary = false, IsMelee = false, IsSpecial = false, Name = "secondary ranged attack" },
                new Attack { IsPrimary = false, IsMelee = true, IsSpecial = true, Name = "secondary melee special attack" },
                new Attack { IsPrimary = false, IsMelee = true, IsSpecial = false, Name = "secondary melee attack" },
                new Attack { IsPrimary = true, IsMelee = false, IsSpecial = true, Name = "primary ranged special attack" },
                new Attack { IsPrimary = true, IsMelee = false, IsSpecial = false, Name = "primary ranged attack" },
                new Attack { IsPrimary = true, IsMelee = true, IsSpecial = true, Name = "primary melee special attack" },
                new Attack { IsPrimary = true, IsMelee = true, IsSpecial = false, Name = "primary melee attack" },
                new Attack { IsPrimary = true, IsMelee = true, IsSpecial = false, Name = "other primary melee attack" },
            };

            var attacks = creature.FullMeleeAttack.ToArray();
            Assert.That(attacks[0].Name, Is.EqualTo("primary melee attack"));
            Assert.That(attacks[1].Name, Is.EqualTo("other primary melee attack"));
            Assert.That(attacks[2].Name, Is.EqualTo("secondary melee attack"));
            Assert.That(attacks.Length, Is.EqualTo(3));
        }

        [Test]
        public void FullMeleeAttackIsEmpty()
        {
            creature.Attacks = new[]
            {
                new Attack { IsPrimary = false, IsMelee = false, IsSpecial = true, Name = "secondary ranged special attack" },
                new Attack { IsPrimary = false, IsMelee = false, IsSpecial = false, Name = "secondary ranged attack" },
                new Attack { IsPrimary = false, IsMelee = true, IsSpecial = true, Name = "secondary melee special attack" },
                new Attack { IsPrimary = true, IsMelee = false, IsSpecial = true, Name = "primary ranged special attack" },
                new Attack { IsPrimary = true, IsMelee = false, IsSpecial = false, Name = "primary ranged attack" },
                new Attack { IsPrimary = true, IsMelee = true, IsSpecial = true, Name = "primary melee special attack" },
            };

            var attacks = creature.FullMeleeAttack;
            Assert.That(attacks, Is.Empty);
        }

        [Test]
        public void FullRangedAttackIsAllRangedAttacks()
        {
            creature.Attacks = new[]
            {
                new Attack { IsPrimary = false, IsMelee = false, IsSpecial = true, Name = "secondary ranged special attack" },
                new Attack { IsPrimary = false, IsMelee = false, IsSpecial = false, Name = "secondary ranged attack" },
                new Attack { IsPrimary = false, IsMelee = true, IsSpecial = true, Name = "secondary melee special attack" },
                new Attack { IsPrimary = false, IsMelee = true, IsSpecial = false, Name = "secondary melee attack" },
                new Attack { IsPrimary = true, IsMelee = false, IsSpecial = true, Name = "primary ranged special attack" },
                new Attack { IsPrimary = true, IsMelee = true, IsSpecial = true, Name = "primary melee special attack" },
                new Attack { IsPrimary = true, IsMelee = true, IsSpecial = false, Name = "primary melee attack" },
                new Attack { IsPrimary = true, IsMelee = false, IsSpecial = false, Name = "primary ranged attack" },
                new Attack { IsPrimary = true, IsMelee = false, IsSpecial = false, Name = "other primary ranged attack" },
            };

            var attacks = creature.FullRangedAttack.ToArray();
            Assert.That(attacks[0].Name, Is.EqualTo("primary ranged attack"));
            Assert.That(attacks[1].Name, Is.EqualTo("other primary ranged attack"));
            Assert.That(attacks[2].Name, Is.EqualTo("secondary ranged attack"));
            Assert.That(attacks.Length, Is.EqualTo(3));
        }

        [Test]
        public void FullRangedAttackIsEmpty()
        {
            creature.Attacks = new[]
            {
                new Attack { IsPrimary = false, IsMelee = false, IsSpecial = true, Name = "secondary ranged special attack" },
                new Attack { IsPrimary = false, IsMelee = true, IsSpecial = true, Name = "secondary melee special attack" },
                new Attack { IsPrimary = false, IsMelee = true, IsSpecial = false, Name = "secondary melee attack" },
                new Attack { IsPrimary = true, IsMelee = false, IsSpecial = true, Name = "primary ranged special attack" },
                new Attack { IsPrimary = true, IsMelee = true, IsSpecial = true, Name = "primary melee special attack" },
                new Attack { IsPrimary = true, IsMelee = true, IsSpecial = false, Name = "primary melee attack" },
            };

            var attacks = creature.FullRangedAttack;
            Assert.That(attacks, Is.Empty);
        }

        [Test]
        public void SpecialAttacksAreSpecial()
        {
            creature.Attacks = new[]
            {
                new Attack { IsPrimary = false, IsMelee = false, IsSpecial = true, Name = "secondary ranged special attack" },
                new Attack { IsPrimary = false, IsMelee = false, IsSpecial = false, Name = "secondary ranged attack" },
                new Attack { IsPrimary = false, IsMelee = true, IsSpecial = true, Name = "secondary melee special attack" },
                new Attack { IsPrimary = false, IsMelee = true, IsSpecial = false, Name = "secondary melee attack" },
                new Attack { IsPrimary = true, IsMelee = false, IsSpecial = true, Name = "primary ranged special attack" },
                new Attack { IsPrimary = true, IsMelee = false, IsSpecial = false, Name = "primary ranged attack" },
                new Attack { IsPrimary = true, IsMelee = true, IsSpecial = true, Name = "primary melee special attack" },
                new Attack { IsPrimary = true, IsMelee = true, IsSpecial = false, Name = "primary melee attack" },
            };

            var attacks = creature.SpecialAttacks.ToArray();
            Assert.That(attacks[0].Name, Is.EqualTo("primary melee special attack"));
            Assert.That(attacks[1].Name, Is.EqualTo("primary ranged special attack"));
            Assert.That(attacks[2].Name, Is.EqualTo("secondary melee special attack"));
            Assert.That(attacks[3].Name, Is.EqualTo("secondary ranged special attack"));
            Assert.That(attacks.Length, Is.EqualTo(4));
        }

        [Test]
        public void SpecialAttacksIsEmpty()
        {
            creature.Attacks = new[]
            {
                new Attack { IsPrimary = false, IsMelee = false, IsSpecial = false, Name = "secondary ranged attack" },
                new Attack { IsPrimary = false, IsMelee = true, IsSpecial = false, Name = "secondary melee attack" },
                new Attack { IsPrimary = true, IsMelee = false, IsSpecial = false, Name = "primary ranged attack" },
                new Attack { IsPrimary = true, IsMelee = true, IsSpecial = false, Name = "primary melee attack" },
            };

            var attacks = creature.SpecialAttacks;
            Assert.That(attacks, Is.Empty);
        }

        [Test]
        public void CreatureSummary()
        {
            creature.Name = Guid.NewGuid().ToString();
            Assert.That(creature.Summary, Is.EqualTo(creature.Name));
        }

        [Test]
        public void CreatureSummaryWithTemplate()
        {
            creature.Name = Guid.NewGuid().ToString();
            creature.Template = Guid.NewGuid().ToString();
            Assert.That(creature.Summary, Is.EqualTo($"{creature.Template} {creature.Name}"));
        }
    }
}
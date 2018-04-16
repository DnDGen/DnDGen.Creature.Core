﻿using NUnit.Framework;
using System;
using System.Linq;

namespace DnDGen.Creature.Core.Tests.Integration.Tables
{
    [TestFixture]
    public abstract class AdjustmentsTests : CollectionTests
    {
        protected const string TrueString = "True";
        protected const string FalseString = "False";

        public virtual void Adjustment(string name, int adjustment)
        {
            Assert.That(table.Keys, Contains.Item(name), tableName);

            var actualAdjustment = GetAdjustment(name);
            Assert.That(actualAdjustment, Is.EqualTo(adjustment));
        }

        protected int GetAdjustment(string name)
        {
            var adjustment = table[name].Single();
            return Convert.ToInt32(adjustment);
        }
    }
}
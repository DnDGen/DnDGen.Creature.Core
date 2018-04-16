﻿using System;

namespace DnDGen.Creature.Core.Tests.Integration.Tables
{
    public abstract class BooleanPercentileTests : PercentileTests
    {
        public virtual void BooleanPercentile(int lower, int upper, bool isTrue)
        {
            var content = Convert.ToString(isTrue);
            base.Percentile(lower, upper, content);
        }
    }
}
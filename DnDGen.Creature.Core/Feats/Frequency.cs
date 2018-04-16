﻿namespace DnDGen.Creature.Core.Feats
{
    public class Frequency
    {
        public int Quantity { get; set; }
        public string TimePeriod { get; set; }

        public Frequency()
        {
            TimePeriod = string.Empty;
        }
    }
}
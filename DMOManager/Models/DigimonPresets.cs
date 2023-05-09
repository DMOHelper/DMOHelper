﻿using DMOManager.Enums;
using SQLite;

namespace DMOManager.Models
{
    [Table("DigimonPresets")]
    public class DigimonPresets
    {
        [PrimaryKey]
        public string Name { get; set; }
        public string Rank { get; set; }
        public Evolution Evolution { get; set; }
        public string Type { get; set; }
        public int BaseHP { get; set; }
        public int BaseDS { get; set; }
        public int BaseAT { get; set; }
        public int AS { get; set; }
        public int BaseCT { get; set; }
        public int HT { get; set; }
        public int BaseDE { get; set; }
        public int EV { get; set; }
    }
}

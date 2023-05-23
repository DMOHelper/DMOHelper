using DMOHelper.Enums;
using DMOHelper.Helper;
using SQLite;
using System;
using System.Collections.Generic;

namespace DMOHelper.Models
{
    [Table("Accessory")]
    public class Accessory : AbstractPropertyChanged
    {
        [PrimaryKey]
        public AccessoryType AccessoryType { get; set; }
        private AccessoryOptions option1;
        private AccessoryOptions option2;
        private AccessoryOptions option3;
        private AccessoryOptions option4;
        private AccessoryOptions option5;
        private double value1;
        private double value2;
        private double value3;
        private double value4;
        private double value5;

        public string Name { get; set; }
        internal static List<AccessoryOptions> AllowedOptions { get; }
        public AccessoryOptions Option1
        {
            get { return option1; }
            set
            {
                option1 = value;
                OnPropertyChanged();
            }
        }
        public AccessoryOptions Option2
        {
            get { return option2; }
            set
            {
                option2 = value;
                OnPropertyChanged();
            }
        }
        public AccessoryOptions Option3
        {
            get { return option3; }
            set
            {
                option3 = value;
                OnPropertyChanged();
            }
        }
        public AccessoryOptions Option4
        {
            get { return option4; }
            set
            {
                option4 = value;
                OnPropertyChanged();
            }
        }
        public AccessoryOptions Option5
        {
            get { return option5; }
            set
            {
                option5 = value;
                OnPropertyChanged();
            }
        }
        public double Value1
        {
            get { return value1; }
            set
            {
                value1 = value;
                OnPropertyChanged();
            }
        }
        public double Value2
        {
            get { return value2; }
            set
            {
                value2 = value;
                OnPropertyChanged();
            }
        }
        public double Value3
        {
            get { return value3; }
            set
            {
                value3 = value;
                OnPropertyChanged();
            }
        }
        public double Value4
        {
            get { return value4; }
            set
            {
                value4 = value;
                OnPropertyChanged();
            }
        }
        public double Value5
        {
            get { return value5; }
            set
            {
                value5 = value;
                OnPropertyChanged();
            }
        }

        public Accessory() { }
    }
    [Table("Accessory")]
    public class Ring : Accessory
    {
        public Ring()
        {
            AccessoryType = AccessoryType.Ring;
        }
        public static new List<AccessoryOptions> AllowedOptions { get; } = new List<AccessoryOptions>()
        {
            { AccessoryOptions.None},
            { AccessoryOptions.HP},
            { AccessoryOptions.DS},
            { AccessoryOptions.Attack },
            { AccessoryOptions.Defense },
            { AccessoryOptions.Critical },
            { AccessoryOptions.Skill },
            { AccessoryOptions.Attribute }
        };
    }
    [Table("Accessory")]
    public class Necklace : Accessory
    {
        public Necklace()
        {
            AccessoryType = AccessoryType.Necklace;
        }
        public static new List<AccessoryOptions> AllowedOptions { get; } = new List<AccessoryOptions>()
        {
            { AccessoryOptions.None},
            { AccessoryOptions.HP },
            { AccessoryOptions.DS },
            { AccessoryOptions.Attack },
            { AccessoryOptions.Defense },
            { AccessoryOptions.Critical },
            { AccessoryOptions.Skill},
            { AccessoryOptions.Attribute },
            { AccessoryOptions.CriticalDamage },
            { AccessoryOptions.AttackSpeed }
        };
    }
    [Table("Accessory")]
    public class Earrings : Accessory
    {
        public Earrings()
        {
            AccessoryType = AccessoryType.Earrings;
        }
        public static new List<AccessoryOptions> AllowedOptions { get; } = new List<AccessoryOptions>()
        {
            { AccessoryOptions.None },
            { AccessoryOptions.HP },
            { AccessoryOptions.DS },
            { AccessoryOptions.Defense },
            { AccessoryOptions.Critical },
            { AccessoryOptions.Skill },
            { AccessoryOptions.Attribute },
            { AccessoryOptions.CriticalDamage },
            { AccessoryOptions.HitRate },
            { AccessoryOptions.Evade },
            { AccessoryOptions.Block }
        };
    }
    [Table("Accessory")]
    public class Bracelet : Accessory
    {
        public Bracelet()
        {
            AccessoryType = AccessoryType.Bracelet;
        }
        public static new List<AccessoryOptions> AllowedOptions { get; } = new List<AccessoryOptions>()
        {
            { AccessoryOptions.None },
            { AccessoryOptions.HP },
            { AccessoryOptions.DS },
            { AccessoryOptions.Attack },
            { AccessoryOptions.Defense },
            { AccessoryOptions.Critical },
            { AccessoryOptions.Skill },
            { AccessoryOptions.CriticalDamage },
            { AccessoryOptions.HitRate },
            { AccessoryOptions.Evade },
        };
    }


    [Table("AccessoryPresets")]
    public class AccessoryPresetsDatabase : Accessory
    {
        [PrimaryKey]
        public new string Name { get; set; }
        public new AccessoryType AccessoryType { get; set; }

        public AccessoryPresetsDatabase()
        {
            
        }
    }
}

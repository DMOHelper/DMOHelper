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

        internal double HP
        {
            get
            {
                double output = 0.0;
                if(Option1 == AccessoryOptions.HP)
                {
                    output += Value1;
                }
                if (Option2 == AccessoryOptions.HP)
                {
                    output += Value2;
                }
                if (Option3 == AccessoryOptions.HP)
                {
                    output += Value3;
                }
                if (Option4 == AccessoryOptions.HP)
                {
                    output += Value4;
                }
                if (Option5 == AccessoryOptions.HP)
                {
                    output += Value5;
                }
                return output;
            }
        }
        internal double DS
        {
            get
            {
                double output = 0.0;
                if (Option1 == AccessoryOptions.DS)
                {
                    output += Value1;
                }
                if (Option2 == AccessoryOptions.DS)
                {
                    output += Value2;
                }
                if (Option3 == AccessoryOptions.DS)
                {
                    output += Value3;
                }
                if (Option4 == AccessoryOptions.DS)
                {
                    output += Value4;
                }
                if (Option5 == AccessoryOptions.DS)
                {
                    output += Value5;
                }
                return output;
            }
        }
        internal double Attack
        {
            get
            {
                double output = 0.0;
                if (Option1 == AccessoryOptions.Attack)
                {
                    output += Value1;
                }
                if (Option2 == AccessoryOptions.Attack)
                {
                    output += Value2;
                }
                if (Option3 == AccessoryOptions.Attack)
                {
                    output += Value3;
                }
                if (Option4 == AccessoryOptions.Attack)
                {
                    output += Value4;
                }
                if (Option5 == AccessoryOptions.Attack)
                {
                    output += Value5;
                }
                return output;
            }
        }
        internal double Defense
        {
            get
            {
                double output = 0.0;
                if (Option1 == AccessoryOptions.Defense)
                {
                    output += Value1;
                }
                if (Option2 == AccessoryOptions.Defense)
                {
                    output += Value2;
                }
                if (Option3 == AccessoryOptions.Defense)
                {
                    output += Value3;
                }
                if (Option4 == AccessoryOptions.Defense)
                {
                    output += Value4;
                }
                if (Option5 == AccessoryOptions.Defense)
                {
                    output += Value5;
                }
                return output;
            }
        }
        internal double Critical
        {
            get
            {
                double output = 0.0;
                if (Option1 == AccessoryOptions.Critical)
                {
                    output += Value1;
                }
                if (Option2 == AccessoryOptions.Critical)
                {
                    output += Value2;
                }
                if (Option3 == AccessoryOptions.Critical)
                {
                    output += Value3;
                }
                if (Option4 == AccessoryOptions.Critical)
                {
                    output += Value4;
                }
                if (Option5 == AccessoryOptions.Critical)
                {
                    output += Value5;
                }
                return output;
            }
        }
        internal double Skill
        {
            get
            {
                double output = 0.0;
                if (Option1 == AccessoryOptions.Skill)
                {
                    output += Value1;
                }
                if (Option2 == AccessoryOptions.Skill)
                {
                    output += Value2;
                }
                if (Option3 == AccessoryOptions.Skill)
                {
                    output += Value3;
                }
                if (Option4 == AccessoryOptions.Skill)
                {
                    output += Value4;
                }
                if (Option5 == AccessoryOptions.Skill)
                {
                    output += Value5;
                }
                return output;
            }
        }
        internal double Attribute
        {
            get
            {
                double output = 0.0;
                if (Option1 == AccessoryOptions.Attribute)
                {
                    output += Value1;
                }
                if (Option2 == AccessoryOptions.Attribute)
                {
                    output += Value2;
                }
                if (Option3 == AccessoryOptions.Attribute)
                {
                    output += Value3;
                }
                if (Option4 == AccessoryOptions.Attribute)
                {
                    output += Value4;
                }
                if (Option5 == AccessoryOptions.Attribute)
                {
                    output += Value5;
                }
                return output;
            }
        }
        internal double AttackSpeed
        {
            get
            {
                double output = 0.0;
                if (Option1 == AccessoryOptions.AttackSpeed)
                {
                    output += Value1;
                }
                if (Option2 == AccessoryOptions.AttackSpeed)
                {
                    output += Value2;
                }
                if (Option3 == AccessoryOptions.AttackSpeed)
                {
                    output += Value3;
                }
                if (Option4 == AccessoryOptions.AttackSpeed)
                {
                    output += Value4;
                }
                if (Option5 == AccessoryOptions.AttackSpeed)
                {
                    output += Value5;
                }
                return output;
            }
        }
        internal double CriticalDamage
        {
            get
            {
                double output = 0.0;
                if (Option1 == AccessoryOptions.CriticalDamage)
                {
                    output += Value1;
                }
                if (Option2 == AccessoryOptions.CriticalDamage)
                {
                    output += Value2;
                }
                if (Option3 == AccessoryOptions.CriticalDamage)
                {
                    output += Value3;
                }
                if (Option4 == AccessoryOptions.CriticalDamage)
                {
                    output += Value4;
                }
                if (Option5 == AccessoryOptions.CriticalDamage)
                {
                    output += Value5;
                }
                return output;
            }
        }
        internal double HitRate
        {
            get
            {
                double output = 0.0;
                if (Option1 == AccessoryOptions.HitRate)
                {
                    output += Value1;
                }
                if (Option2 == AccessoryOptions.HitRate)
                {
                    output += Value2;
                }
                if (Option3 == AccessoryOptions.HitRate)
                {
                    output += Value3;
                }
                if (Option4 == AccessoryOptions.HitRate)
                {
                    output += Value4;
                }
                if (Option5 == AccessoryOptions.HitRate)
                {
                    output += Value5;
                }
                return output;
            }
        }
        internal double Evade
        {
            get
            {
                double output = 0.0;
                if (Option1 == AccessoryOptions.Evade)
                {
                    output += Value1;
                }
                if (Option2 == AccessoryOptions.Evade)
                {
                    output += Value2;
                }
                if (Option3 == AccessoryOptions.Evade)
                {
                    output += Value3;
                }
                if (Option4 == AccessoryOptions.Evade)
                {
                    output += Value4;
                }
                if (Option5 == AccessoryOptions.Evade)
                {
                    output += Value5;
                }
                return output;
            }
        }
        internal double Block
        {
            get
            {
                double output = 0.0;
                if (Option1 == AccessoryOptions.Block)
                {
                    output += Value1;
                }
                if (Option2 == AccessoryOptions.Block)
                {
                    output += Value2;
                }
                if (Option3 == AccessoryOptions.Block)
                {
                    output += Value3;
                }
                if (Option4 == AccessoryOptions.Block)
                {
                    output += Value4;
                }
                if (Option5 == AccessoryOptions.Block)
                {
                    output += Value5;
                }
                return output;
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

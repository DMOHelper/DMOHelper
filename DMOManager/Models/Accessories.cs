using DMOManager.Enums;
using DMOManager.Helper;
using System.Collections.Generic;

namespace DMOManager.Models
{
    public abstract class Accessory : AbstractPropertyChanged
    {
        public AccessoryType AccessoryType { get; internal set; }
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
        public int OptionsCount { get; set; }
        public static List<AccessoryOptions> AllowedOptions { get; }
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

    public class Ring : Accessory
    {
        public Ring()
        {
            AccessoryType = AccessoryType.Ring;
        }
        public static new List<AccessoryOptions> AllowedOptions { get; } = new List<AccessoryOptions>()
        {
            { AccessoryOptions.HP},
            { AccessoryOptions.DS},
            { AccessoryOptions.Attack },
            { AccessoryOptions.Defense },
            { AccessoryOptions.Critical },
            { AccessoryOptions.Skill },
            { AccessoryOptions.Attribute }
        };
    }

    public class Necklace : Accessory
    {
        public Necklace()
        {
            AccessoryType = AccessoryType.Necklace;
        }
        public static new List<AccessoryOptions> AllowedOptions { get; } = new List<AccessoryOptions>()
        {
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

    public class Earrings : Accessory
    {
        public Earrings()
        {
            AccessoryType = AccessoryType.Earrings;
        }
        public static new List<AccessoryOptions> AllowedOptions { get; } = new List<AccessoryOptions>()
        {
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

    public class Bracelet : Accessory
    {
        public Bracelet()
        {
            AccessoryType = AccessoryType.Bracelet;
        }
        public static new List<AccessoryOptions> AllowedOptions { get; } = new List<AccessoryOptions>()
        {
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

    public static class AccessoryPresets
    {
        public static List<Accessory> Presets = new List<Accessory>()
        {
        #region Rings
        new Ring()
        {
            Name = "Radiant Holy Beast Ring / AT AT Att Att",
            OptionsCount = 4,
            Option1 = AccessoryOptions.Attack,
            Option2 = AccessoryOptions.Attack,
            Option3 = AccessoryOptions.Attribute,
            Option4 = AccessoryOptions.Attribute,
            Value1 = 780.0,
            Value2 = 780.0,
            Value3 = 14.0,
            Value4 = 14.0
        },
        new Ring()
        {
            Name = "Zero Unit Ring / AT AT Att Att CT",
            OptionsCount = 5,
            Option1 = AccessoryOptions.Attack,
            Option2 = AccessoryOptions.Attack,
            Option3 = AccessoryOptions.Attribute,
            Option4 = AccessoryOptions.Attribute,
            Option5 = AccessoryOptions.Critical,
            Value1 = 720.0,
            Value2 = 720.0,
            Value3 = 12.0,
            Value4 = 12.0,
            Value5 = 12.0
        },
        new Ring()
        {
            Name = "Zero Unit Ring / AT AT Att Att HP",
            OptionsCount = 5,
            Option1 = AccessoryOptions.Attack,
            Option2 = AccessoryOptions.Attack,
            Option3 = AccessoryOptions.Attribute,
            Option4 = AccessoryOptions.Attribute,
            Option5 = AccessoryOptions.HP,
            Value1 = 720.0,
            Value2 = 720.0,
            Value3 = 12.0,
            Value4 = 12.0,
            Value5 = 1920.0
        },
        #endregion
        #region Necklaces
        new Necklace()
        {
            Name = "Radiant Holy Beast Necklace/ AS CD Att Att",
            OptionsCount = 4,
            Option1 = AccessoryOptions.AttackSpeed,
            Option2 = AccessoryOptions.CriticalDamage,
            Option3 = AccessoryOptions.Attribute,
            Option4 = AccessoryOptions.Attribute,
            Value1 = 30.0,
            Value2 = 52.0,
            Value3 = 14.0,
            Value4 = 14.0
        },
        new Necklace()
        {
            Name = "Radiant Holy Beast Necklace/ AS CD AT Att",
            OptionsCount = 4,
            Option1 = AccessoryOptions.AttackSpeed,
            Option2 = AccessoryOptions.CriticalDamage,
            Option3 = AccessoryOptions.Attack,
            Option4 = AccessoryOptions.Attribute,
            Value1 = 30.0,
            Value2 = 52.0,
            Value3 = 520.0,
            Value4 = 14.0
        },
        new Necklace()
        {
            Name = "Zero Unit Necklace/ AS CD Att Att CT",
            OptionsCount = 5,
            Option1 = AccessoryOptions.AttackSpeed,
            Option2 = AccessoryOptions.CriticalDamage,
            Option3 = AccessoryOptions.Attribute,
            Option4 = AccessoryOptions.Attribute,
            Option5 = AccessoryOptions.Critical,
            Value1 = 30.0,
            Value2 = 48.0,
            Value3 = 12.0,
            Value4 = 12.0,
            Value5 = 12.0
        },
        new Necklace()
        {
            Name = "Zero Unit Necklace/ AS CD AT Att CT",
            OptionsCount = 5,
            Option1 = AccessoryOptions.AttackSpeed,
            Option2 = AccessoryOptions.CriticalDamage,
            Option3 = AccessoryOptions.Attack,
            Option4 = AccessoryOptions.Attribute,
            Option5 = AccessoryOptions.Critical,
            Value1 = 30.0,
            Value2 = 48.0,
            Value3 = 480.0,
            Value4 = 12.0,
            Value5 = 12.0
        },
        new Necklace()
        {
            Name = "Zero Unit Necklace/ AS CD AT Att HP",
            OptionsCount = 5,
            Option1 = AccessoryOptions.AttackSpeed,
            Option2 = AccessoryOptions.CriticalDamage,
            Option3 = AccessoryOptions.Attack,
            Option4 = AccessoryOptions.Attribute,
            Option5 = AccessoryOptions.HP,
            Value1 = 30.0,
            Value2 = 48.0,
            Value3 = 480.0,
            Value4 = 12.0,
            Value5 = 1920.0
        },
        new Necklace()
        {
            Name = "Zero Unit Necklace/ AS CD Att Att HP",
            OptionsCount = 5,
            Option1 = AccessoryOptions.AttackSpeed,
            Option2 = AccessoryOptions.CriticalDamage,
            Option3 = AccessoryOptions.Attribute,
            Option4 = AccessoryOptions.Attribute,
            Option5 = AccessoryOptions.HP,
            Value1 = 30.0,
            Value2 = 48.0,
            Value3 = 12.0,
            Value4 = 12.0,
            Value5 = 1920.0
        },
        #endregion
        #region Earrings
        new Earrings()
        {
            Name = "Radiant Holy Beast Earrings / CD CD Att Att",
            OptionsCount = 4,
            Option1 = AccessoryOptions.CriticalDamage,
            Option2 = AccessoryOptions.CriticalDamage,
            Option3 = AccessoryOptions.Attribute,
            Option4 = AccessoryOptions.Attribute,
            Value1 = 52.0,
            Value2 = 52.0,
            Value3 = 20.0,
            Value4 = 20.0
        },
        new Earrings()
        {
            Name = "Radiant Holy Beast Earrings / CD CD Att HT",
            OptionsCount = 4,
            Option1 = AccessoryOptions.CriticalDamage,
            Option2 = AccessoryOptions.CriticalDamage,
            Option3 = AccessoryOptions.Attribute,
            Option4 = AccessoryOptions.HitRate,
            Value1 = 52.0,
            Value2 = 52.0,
            Value3 = 20.0,
            Value4 = 1300.0
        },
         new Earrings()
        {
            Name = "Zero Unit Earrings / CD CD Att Att CT",
            OptionsCount = 5,
            Option1 = AccessoryOptions.CriticalDamage,
            Option2 = AccessoryOptions.CriticalDamage,
            Option3 = AccessoryOptions.Attribute,
            Option4 = AccessoryOptions.Attribute,
            Option5 = AccessoryOptions.Critical,
            Value1 = 48.0,
            Value2 = 48.0,
            Value3 = 18.0,
            Value4 = 18.0,
            Value5 = 18.0
        },
        new Earrings()
        {
            Name = "Zero Unit Earrings / CD CD Att Att HT",
            OptionsCount = 5,
            Option1 = AccessoryOptions.CriticalDamage,
            Option2 = AccessoryOptions.CriticalDamage,
            Option3 = AccessoryOptions.Attribute,
            Option4 = AccessoryOptions.Attribute,
            Option5 = AccessoryOptions.HitRate,
            Value1 = 48.0,
            Value2 = 48.0,
            Value3 = 18.0,
            Value4 = 18.0,
            Value5 = 1200.0
        },
        new Earrings()
        {
            Name = "Zero Unit Earrings / CD CD Att CT HT",
            OptionsCount = 5,
            Option1 = AccessoryOptions.CriticalDamage,
            Option2 = AccessoryOptions.CriticalDamage,
            Option3 = AccessoryOptions.Attribute,
            Option4 = AccessoryOptions.Critical,
            Option5 = AccessoryOptions.HitRate,
            Value1 = 48.0,
            Value2 = 48.0,
            Value3 = 18.0,
            Value4 = 18.0,
            Value5 = 1200.0
        },
        new Earrings()
        {
            Name = "Boundless Advanced Earrings / CD CD HT HT",
            OptionsCount = 4,
            Option1 = AccessoryOptions.CriticalDamage,
            Option2 = AccessoryOptions.CriticalDamage,
            Option3 = AccessoryOptions.HitRate,
            Option4 = AccessoryOptions.HitRate,
            Value1 = 40.0,
            Value2 = 40.0,
            Value3 = 1000.0,
            Value4 = 1000.0
        },
        #endregion
        #region Bracelets
        new Bracelet()
        {
            Name = "Royal: X-Knight's Bracelet / AT HT HT CD CD",
            OptionsCount = 5,
            Option1 = AccessoryOptions.Attack,
            Option2 = AccessoryOptions.HitRate,
            Option3 = AccessoryOptions.HitRate,
            Option4 = AccessoryOptions.CriticalDamage,
            Option5 = AccessoryOptions.CriticalDamage,
            Value1 = 960.0,
            Value2 = 1200.0,
            Value3 = 1200.0,
            Value4 = 48.0,
            Value5 = 48.0
        },
        new Bracelet()
        {
            Name = "Zero Unit Bracelet / AT HT HT CD CD",
            OptionsCount = 5,
            Option1 = AccessoryOptions.Attack,
            Option2 = AccessoryOptions.HitRate,
            Option3 = AccessoryOptions.HitRate,
            Option4 = AccessoryOptions.CriticalDamage,
            Option5 = AccessoryOptions.CriticalDamage,
            Value1 = 1440.0,
            Value2 = 1800.0,
            Value3 = 1800.0,
            Value4 = 72.0,
            Value5 = 72.0
        },
        new Bracelet()
        {
            Name = "Miracle Bracelet Special / AT HT HT CD CD",
            OptionsCount = 5,
            Option1 = AccessoryOptions.Attack,
            Option2 = AccessoryOptions.HitRate,
            Option3 = AccessoryOptions.HitRate,
            Option4 = AccessoryOptions.CriticalDamage,
            Option5 = AccessoryOptions.CriticalDamage,
            Value1 = 1200.0,
            Value2 = 1500.0,
            Value3 = 1500.0,
            Value4 = 60.0,
            Value5 = 60.0
        }
        #endregion
        };
    }
}

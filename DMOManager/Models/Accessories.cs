using DMOManager.Enums;
using DMOManager.Helper;
using SQLite;
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

        public static List<Accessory> Presets
        {
            get
            {
                List<Accessory> output = new List<Accessory>();
                var presets = SQLiteDatabaseManager.Database.Table<AccessoryPresetsDatabase>().ToListAsync().Result;
                foreach(AccessoryPresetsDatabase preset in presets)
                {
                    switch(preset.Type)
                    {
                        case "Ring":
                            output.Add(new Ring()
                            {
                                AccessoryType = AccessoryType.Ring,
                                Name = preset.Name,
                                Option1 = preset.Option1,
                                Option2 = preset.Option2,
                                Option3 = preset.Option3,
                                Option4 = preset.Option4,
                                Option5 = preset.Option5,
                                Value1 = preset.Value1,
                                Value2 = preset.Value2,
                                Value3 = preset.Value3,
                                Value4 = preset.Value4,
                                Value5 = preset.Value5
                            });
                            break;
                        case "Necklace":
                            output.Add(new Necklace()
                            {
                                AccessoryType = AccessoryType.Necklace,
                                Name = preset.Name,
                                Option1 = preset.Option1,
                                Option2 = preset.Option2,
                                Option3 = preset.Option3,
                                Option4 = preset.Option4,
                                Option5 = preset.Option5,
                                Value1 = preset.Value1,
                                Value2 = preset.Value2,
                                Value3 = preset.Value3,
                                Value4 = preset.Value4,
                                Value5 = preset.Value5
                            });
                            break;
                        case "Earrings":
                            output.Add(new Earrings()
                            {
                                AccessoryType = AccessoryType.Earrings,
                                Name = preset.Name,
                                Option1 = preset.Option1,
                                Option2 = preset.Option2,
                                Option3 = preset.Option3,
                                Option4 = preset.Option4,
                                Option5 = preset.Option5,
                                Value1 = preset.Value1,
                                Value2 = preset.Value2,
                                Value3 = preset.Value3,
                                Value4 = preset.Value4,
                                Value5 = preset.Value5
                            });
                            break;
                        case "Bracelet":
                            output.Add(new Bracelet()
                            {
                                AccessoryType = AccessoryType.Bracelet,
                                Name = preset.Name,
                                Option1 = preset.Option1,
                                Option2 = preset.Option2,
                                Option3 = preset.Option3,
                                Option4 = preset.Option4,
                                Option5 = preset.Option5,
                                Value1 = preset.Value1,
                                Value2 = preset.Value2,
                                Value3 = preset.Value3,
                                Value4 = preset.Value4,
                                Value5 = preset.Value5
                            });
                            break;
                    }
                }
                return output;
            }
        }
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


    [Table("AccessoryPresets")]
    public class AccessoryPresetsDatabase
    {
        public string Type { get; set; }
        [PrimaryKey]
        public string Name { get; set; }
        public AccessoryOptions Option1 { get; set; }
        public AccessoryOptions Option2 { get; set; }
        public AccessoryOptions Option3 { get; set; }
        public AccessoryOptions Option4 { get; set; }
        public AccessoryOptions Option5 { get; set; }
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public int Value3 { get; set; }
        public int Value4 { get; set; }
        public int Value5 { get; set; }
    }
}

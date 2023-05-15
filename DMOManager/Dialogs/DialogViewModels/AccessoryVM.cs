using DMOManager.Enums;
using DMOManager.Helper;
using DMOManager.Models;
using System.Collections.Generic;

namespace DMOManager.Dialogs.DialogViewModels
{
    public class AccessoryVM : AbstractPropertyChanged
    {
        public static string Title { get; } = "Accessory Presets";
        public bool StatEnabled { get; set; }

        public static List<Accessory> Presets
        {
            get
            {
                List<Accessory> output = new List<Accessory>();
                var presets = SQLiteDatabaseManager.Database.Table<AccessoryPresetsDatabase>().ToListAsync().Result;
                foreach (AccessoryPresetsDatabase preset in presets)
                {
                    switch (preset.AccessoryType)
                    {
                        case AccessoryType.Ring:
                            output.Add(new Ring()
                            {
                                AccessoryType = AccessoryType.Ring,
                                Name = preset.Name,
                                Option1 = preset.Option1,
                                Option2 = preset.Option2,
                                Option3 = preset.Option3,
                                Option4 = preset.Option4,
                                Option5 = preset.Option5,
                                Value1 = (preset.Value1 / 100.0),
                                Value2 = (preset.Value2 / 100.0),
                                Value3 = (preset.Value3 / 100.0),
                                Value4 = (preset.Value4 / 100.0),
                                Value5 = (preset.Value5 / 100.0)
                            });
                            break;
                        case AccessoryType.Necklace:
                            output.Add(new Necklace()
                            {
                                AccessoryType = AccessoryType.Necklace,
                                Name = preset.Name,
                                Option1 = preset.Option1,
                                Option2 = preset.Option2,
                                Option3 = preset.Option3,
                                Option4 = preset.Option4,
                                Option5 = preset.Option5,
                                Value1 = (preset.Value1 / 100.0),
                                Value2 = (preset.Value2 / 100.0),
                                Value3 = (preset.Value3 / 100.0),
                                Value4 = (preset.Value4 / 100.0),
                                Value5 = (preset.Value5 / 100.0)
                            });
                            break;
                        case AccessoryType.Earrings:
                            output.Add(new Earrings()
                            {
                                AccessoryType = AccessoryType.Earrings,
                                Name = preset.Name,
                                Option1 = preset.Option1,
                                Option2 = preset.Option2,
                                Option3 = preset.Option3,
                                Option4 = preset.Option4,
                                Option5 = preset.Option5,
                                Value1 = (preset.Value1 / 100.0),
                                Value2 = (preset.Value2 / 100.0),
                                Value3 = (preset.Value3 / 100.0),
                                Value4 = (preset.Value4 / 100.0),
                                Value5 = (preset.Value5 / 100.0)
                            });
                            break;
                        case AccessoryType.Bracelet:
                            output.Add(new Bracelet()
                            {
                                AccessoryType = AccessoryType.Bracelet,
                                Name = preset.Name,
                                Option1 = preset.Option1,
                                Option2 = preset.Option2,
                                Option3 = preset.Option3,
                                Option4 = preset.Option4,
                                Option5 = preset.Option5,
                                Value1 = (preset.Value1 / 100.0),
                                Value2 = (preset.Value2 / 100.0),
                                Value3 = (preset.Value3 / 100.0),
                                Value4 = (preset.Value4 / 100.0),
                                Value5 = (preset.Value5 / 100.0)
                            });
                            break;
                    }
                }
                return output;
            }
        }

        public static List<AccessoryOptions> Ring
        {
            get
            {
                return Models.Ring.AllowedOptions;
            }
        }
        public static List<AccessoryOptions> Necklace
        {
            get
            {
                return Models.Necklace.AllowedOptions;
            }
        }
        public static List<AccessoryOptions> Earrings
        {
            get
            {
                return Models.Earrings.AllowedOptions;
            }
        }
        public static List<AccessoryOptions> Bracelet
        {
            get
            {
                return Models.Bracelet.AllowedOptions;
            }
        }

        private Ring currentRing;
        public Ring CurrentRing
        {
            get { return currentRing; }
            set
            {
                currentRing = value;
                OnPropertyChanged();
            }
        }
        private Necklace currentNecklace;
        public Necklace CurrentNecklace
        {
            get { return currentNecklace; }
            set
            {
                currentNecklace = value;
                OnPropertyChanged();
            }
        }
        private Earrings currentEarrings;
        public Earrings CurrentEarrings
        {
            get { return currentEarrings; }
            set
            {
                currentEarrings = value;
                OnPropertyChanged();
            }
        }
        private Bracelet currentBracelet;
        public Bracelet CurrentBracelet
        {
            get { return currentBracelet; }
            set
            {
                currentBracelet = value;
                OnPropertyChanged();
            }
        }

        public AccessoryVM()
        {
            currentRing = new Ring();
            currentNecklace = new Necklace();
            currentBracelet = new Bracelet();
            currentEarrings = new Earrings();
            StatEnabled = true;
        }

        public AccessoryVM(Ring cRing, Necklace cNeck, Earrings cEars, Bracelet cBrace, bool presetsEnabled)
        {
            currentRing = cRing;
            currentNecklace = cNeck;
            currentEarrings = cEars;
            currentBracelet = cBrace;
            StatEnabled = presetsEnabled;
        }
    }
}

using CsvHelper;
using DMOHelper.Dialogs.DialogViewModels;
using DMOHelper.Dialogs;
using DMOHelper.Enums;
using DMOHelper.Helper;
using DMOHelper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;

namespace DMOHelper
{
    public sealed class VMMain : AbstractPropertyChanged
    {
        private static readonly Lazy<VMMain> lazy = new Lazy<VMMain>(() => new VMMain());

        private Account selected;
        public Account SelectedAccount
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Account> Accounts { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        public List<ItemStack> ItemStacks { get; set; }
        public List<Digivice> Digivices { get; set; }
        public List<EnumDropdownHelper> ViceTypes { get; set; }
        public List<ViceResources> Resources { get; set; }
        public static List<DigimonAttribute> DigimonAttributes
        {
            get
            {
                return new List<DigimonAttribute>() {
                    DigimonAttribute.None,
                    DigimonAttribute.Vaccine,
                    DigimonAttribute.Data,
                    DigimonAttribute.Virus,
                    DigimonAttribute.Unknown
                };
            }
        }
        public static List<ElementalAttribute> ElementalAttributes
        {
            get
            {
                return new List<ElementalAttribute> {
                    ElementalAttribute.Neutral,
                    ElementalAttribute.Fire,
                    ElementalAttribute.Ice,
                    ElementalAttribute.Land,
                    ElementalAttribute.Light,
                    ElementalAttribute.PitchBlack,
                    ElementalAttribute.Steel,
                    ElementalAttribute.Thunder,
                    ElementalAttribute.Water,
                    ElementalAttribute.Wind,
                    ElementalAttribute.Wood
                };
            }
        }
        public static List<Evolution> EvolutionStages
        {
            get
            {
                return new List<Evolution> {
                    Evolution.Rookie,
                    Evolution.RookieX,
                    Evolution.Champion,
                    Evolution.ChampionX,
                    Evolution.Ultimate,
                    Evolution.UltimateX,
                    Evolution.Mega,
                    Evolution.MegaX,
                    Evolution.BurstMode,
                    Evolution.BurstModeX,
                    Evolution.Jogress,
                    Evolution.JogressX,
                    Evolution.Armor,
                    Evolution.Variant,
                    Evolution.Spirit
                };
            }
        }
        public static List<AttackerType> AttackerTypes
        {
            get
            {
                return new List<AttackerType> {
                    AttackerType.ShortAttacker,
                    AttackerType.QuickAttacker,
                    AttackerType.NearAttacker,
                    AttackerType.Defender
                };
            }
        }
        public static List<MemorySkillLevel> MemoryRatesJog
        {
            get
            {
                return new List<MemorySkillLevel>
                {
                    MemorySkillLevel.None,
                    MemorySkillLevel.Lv1,
                    MemorySkillLevel.Lv2,
                    MemorySkillLevel.Lv3
                };
            }
        }
        public static List<MemorySkillLevel> MemoryRatesBM
        {
            get
            {
                return new List<MemorySkillLevel> {
                    MemorySkillLevel.None,
                    MemorySkillLevel.Low,
                    MemorySkillLevel.Mid,
                    MemorySkillLevel.High,
                    MemorySkillLevel.Highest
                };
            }
        }
        public static List<MemorySkillLevel> MemoryRates
        {
            get
            {
                return new List<MemorySkillLevel> {
                    MemorySkillLevel.None,
                    MemorySkillLevel.Low,
                    MemorySkillLevel.Mid,
                    MemorySkillLevel.High,
                    MemorySkillLevel.Highest,
                    MemorySkillLevel.Lv1,
                    MemorySkillLevel.Lv2,
                    MemorySkillLevel.Lv3
                };
            }
        }
        public static List<string> Decks
        {
            get
            {
                List<string> output = new List<string>();
                var decks = SQLiteDatabaseManager.Database.Table<Deck>().ToListAsync().Result;
                foreach(Deck deck in decks)
                {
                    output.Add(deck.Name);
                }
                return output;
            }
        }
        public static List<string> Titles
        {
            get
            {
                List<string> output = new List<string>();
                var titles = SQLiteDatabaseManager.Database.Table<Title>().ToListAsync().Result;
                foreach(Title title in titles)
                {
                    output.Add(title.Name);
                }
                return output;
            }
        }
        public static List<string> Tamers
        {
            get
            {
                List<string> output = new List<string>();
                var tamers = SQLiteDatabaseManager.Database.Table<Tamer>().ToListAsync().Result;
                foreach(Tamer tamer in tamers)
                { 
                    output.Add(tamer.Name);
                }
                return output;
            }
        }
        public static List<string> TamerSkills
        {
            get
            {
                List<string> output = new List<string>() ;
                var skills = SQLiteDatabaseManager.Database.Table<TamerSkill>().ToListAsync().Result;
                foreach (TamerSkill skill in skills)
                {
                    if (skill.EnhancedCooldown > 0 || skill.UltimateCooldown > 0) //Filters Tamer Skills that are not available as Enhanced/Ultimate
                    {
                        output.Add(skill.Name);
                    }
                }
                return output;
            }
        }

        public ObservableCollection<ItemStack> SelectedAccountStacks { get; set; }
        public ObservableCollection<Digivice> SelectedAccountVices { get; set; }
        public StatInformation StatInformation { get; set; }

        private ViceResources? _selectedResources;
        public ViceResources? SelectedResources
        {
            get
            {
                return _selectedResources;
            }
            set
            {
                _selectedResources = value;
                OnPropertyChanged();
            }
        }
        public long TotalAll
        {
            get
            {
                Suspicious = false;
                try
                {
                    long total = 0;
                    foreach (Account acc in Accounts)
                    {
                        total += acc.TotalValue;
                    }
                    if (total > 9999999999999)
                    {
                        Suspicious = true;
                        return -1;
                    }
                    else return total;
                }
                catch (Exception)
                {
                    Suspicious = true;
                    return -3;
                }
            }
        }

        private string source;
        public string Source
        {
            get
            {
                return source;
            }
            set
            {
                source = value;
                OnPropertyChanged();
            }
        }
        private int accIndex;
        public int AccIndex
        {
            get
            {
                return accIndex;
            }
            set
            {
                accIndex = value;
                OnPropertyChanged();
            }
        }
        internal bool beer = true;
        private bool suspicious = false;
        public bool Suspicious
        {
            get
            {
                return suspicious; ;
            }
            set
            {
                suspicious = value;
                OnPropertyChanged();
            }
        }
        public bool StatEnabled { get; set; }
        private static Version appVersion
        {
            get
            {
                return Assembly.GetEntryAssembly().GetName().Version;
            }
        }
        public static string AppVersion
        {
            get
            {
                return appVersion.ToString(4);
            }
        }


        public VMMain()
        {
            StatEnabled = true;
            StatInformation = StatInformation.LoadFromDatabase();
            if (DateTime.UtcNow - StatInformation.LastPresetUpdate > new TimeSpan(1, 0, 0, 0))
            {
                bool failed = Task.Run(UpdatePresets).Result;
                if (failed)
                {
                    MessageBoxResult result = MessageBox.Show("Unable to load presets from web resource https://github.com/DMOHelper/DMOHelper/tree/master/csvResources" + Environment.NewLine + "Without presets, StatCalculator isn't working. For full feature set, please connect to internet and restart app." + Environment.NewLine + Environment.NewLine + "Do you want to continue without StatCalculator?",
                                          "Error",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Error);
                    if (result == MessageBoxResult.No)
                    {
                        Application.Current.Shutdown();
                    }
                    if (result == MessageBoxResult.Yes)
                    {
                        StatEnabled = false;
                    }
                }
            }
            Source = "/Images/Beer.png";
            Accounts = SQLiteDatabaseManager.Database.Table<Account>().ToListAsync().Result.ToCollection();
            Items = SQLiteDatabaseManager.Database.Table<Item>().ToListAsync().Result.ToCollection();
            ItemStacks = SQLiteDatabaseManager.Database.Table<ItemStack>().ToListAsync().Result;
            Digivices = SQLiteDatabaseManager.Database.Table<Digivice>().ToListAsync().Result;
            Resources = SQLiteDatabaseManager.Database.Table<ViceResources>().ToListAsync().Result;
            SelectedAccountStacks = new ObservableCollection<ItemStack>();
            SelectedAccountVices = new ObservableCollection<Digivice>();
            ViceTypes = new List<EnumDropdownHelper>();
            foreach (ViceType type in Enum.GetValues(typeof(ViceType)))
            {
                if (type == ViceType.None) { }
                else ViceTypes.Add(new EnumDropdownHelper(type.GetAttributeOfType<DescriptionAttribute>().Description, (int)type));
            }
            bool.TryParse(Environment.GetEnvironmentVariable("ClickOnce_IsNetworkDeployed"), out bool isNetworkDeployed);
            bool.TryParse(Environment.GetEnvironmentVariable("ClickOnce_IsFirstRun"), out bool isFirstRun);
            if (isNetworkDeployed && isFirstRun)
            {
                string markdown = string.Empty;
                Task.Run(async () =>
                {
                    try
                    {
                        using (HttpClient client = new HttpClient())
                        {

                            using (HttpResponseMessage response = await client.GetAsync("https://raw.githubusercontent.com/DMOHelper/DMOHelper/master/Changelog.MD"))
                            using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                            {
                                StreamReader reader = new StreamReader(streamToReadFrom);
                                markdown = await reader.ReadToEndAsync();
                            }
                        }
                    }
                    catch { }
                }).Wait();
                if (!string.IsNullOrWhiteSpace(markdown))
                {
                    ChangelogDialog changelogDialog = new ChangelogDialog(markdown);
                    changelogDialog.ShowDialog();
                }
            }
        }

        public static VMMain GetInstance()
        {
            return lazy.Value;
        }
        public void AccountSelected(string name)
        {
            SelectedAccountStacks.Clear();
            SelectedAccountVices.Clear();
            ItemStacks.Where(stack => stack.Account == name).ForEach(SelectedAccountStacks.Add);
            Digivices.Where(vice => vice.Account == name).ForEach(SelectedAccountVices.Add);
            try
            {
                SelectedResources = Resources.First(x => x.Account == name);
            }
            catch (InvalidOperationException) { SelectedResources = null; };
        }

        public void Refresh()
        {
            OnPropertyChanged(nameof(TotalAll));
        }

        public async Task<bool> UpdatePresets()
        {
            bool failed = false;
            using (HttpClient client = new HttpClient())
            {
                StreamReader reader;
                List<StatFormula> formulas = new List<StatFormula>();
                List<DigimonPresetsDatabase> digiPresets = new List<DigimonPresetsDatabase>();
                List<AccessoryPresetsDatabase> accPresets = new List<AccessoryPresetsDatabase>();
                List<Tamer> tamers = new List<Tamer>();
                List<TamerSkill> skills = new List<TamerSkill>();
                List<Title> titles = new List<Title>();
                List<Deck> decks = new List<Deck>();
                //Stat Formula
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync("https://raw.githubusercontent.com/DMOHelper/DMOHelper/master/csvResources/statformula.csv"))
                    using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                    {
                        reader = new StreamReader(streamToReadFrom);
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            csv.Read();
                            csv.ReadHeader();
                            while (csv.Read())
                            {
                                var record = new StatFormula
                                {
                                    Type = Enum.Parse<AttackerType>(csv.GetField("type")),
                                    Stage = Enum.Parse<Evolution>(csv.GetField("stage")),
                                    HP = int.Parse(csv.GetField("hp")),
                                    DS = int.Parse(csv.GetField("ds")),
                                    AT = int.Parse(csv.GetField("at")),
                                    DE = int.Parse(csv.GetField("de")),
                                    CT = int.Parse(csv.GetField("ct")) / 100.0,
                                    MaxLevel = int.Parse(csv.GetField("maxLevel"))
                                };
                                formulas.Add(record);
                            }
                        }
                        if (formulas.Count == 36)
                        {
                            await SQLiteDatabaseManager.Database.DeleteAllAsync<StatFormula>();
                            await SQLiteDatabaseManager.Database.InsertAllAsync(formulas);
                        }
                    }
                }
                catch
                {
                    failed = true;
                }
                //Digimon Presets
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync("https://raw.githubusercontent.com/DMOHelper/DMOHelper/master/csvResources/digimonPresets.csv"))
                    using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                    {
                        reader = new StreamReader(streamToReadFrom);
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            csv.Read();
                            csv.ReadHeader();
                            while (csv.Read())
                            {
                                var record = new DigimonPresetsDatabase();
                                record.Name = csv.GetField("name");
                                record.Rank = csv.GetField("rank");
                                bool result = Enum.TryParse(csv.GetField("evolution"), out Evolution evo);
                                if (result)
                                {
                                    record.Evolution = evo;
                                }
                                record.Type = Enum.Parse<AttackerType>(csv.GetField("type"));
                                record.BaseHP = int.Parse(csv.GetField("baseHP"));
                                record.BaseDS = int.Parse(csv.GetField("baseDS"));
                                record.BaseAT = int.Parse(csv.GetField("baseAT"));
                                record.AS = int.Parse(csv.GetField("AS")) / 100.0;
                                record.BaseCT = int.Parse(csv.GetField("baseCT")) / 100.0;
                                record.HT = int.Parse(csv.GetField("HT"));
                                record.BaseDE = int.Parse(csv.GetField("baseDE"));
                                record.EV = int.Parse(csv.GetField("EV")) / 100.0;
                                record.Skill1Base = int.Parse(csv.GetField("skill1Base"));
                                record.Skill1Increase = int.Parse(csv.GetField("skill1Increase"));
                                record.Skill1Points = int.Parse(csv.GetField("skill1Points"));
                                record.Skill2Base = int.Parse(csv.GetField("skill2Base"));
                                record.Skill2Increase = int.Parse(csv.GetField("skill2Increase"));
                                record.Skill2Points = int.Parse(csv.GetField("skill2Points"));
                                record.Skill3Base = int.Parse(csv.GetField("skill3Base"));
                                record.Skill3Increase = int.Parse(csv.GetField("skill3Increase"));
                                record.Skill3Points = int.Parse(csv.GetField("skill3Points"));
                                record.Skill4Base = int.Parse(csv.GetField("skill4Base"));
                                record.Skill4Increase = int.Parse(csv.GetField("skill4Increase"));
                                record.Skill4Points = int.Parse(csv.GetField("skill4Points"));
                                record.SkillIncreaseBuff = bool.Parse(csv.GetField("skillIncreaseBuff"));
                                record.Attribute = Enum.Parse<DigimonAttribute>(csv.GetField("attribute"));
                                record.Elemental = Enum.Parse<ElementalAttribute>(csv.GetField("element"));
                                digiPresets.Add(record);
                            }
                            await SQLiteDatabaseManager.Database.DeleteAllAsync<DigimonPresetsDatabase>();
                            await SQLiteDatabaseManager.Database.InsertAllAsync(digiPresets);
                        }
                    }
                }
                catch
                {
                    failed = true;
                }
                //Accessory Presets
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync("https://raw.githubusercontent.com/DMOHelper/DMOHelper/master/csvResources/accessoryPresets.csv"))
                    using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                    {
                        reader = new StreamReader(streamToReadFrom);
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            csv.Read();
                            csv.ReadHeader();
                            while (csv.Read())
                            {
                                var record = new AccessoryPresetsDatabase();
                                bool result = Enum.TryParse(csv.GetField("type"), out AccessoryType type);
                                if (result)
                                {
                                    record.AccessoryType = type;
                                }
                                record.Name = csv.GetField("name");
                                bool result1 = Enum.TryParse(csv.GetField("option1"), out AccessoryOptions option1);
                                bool result2 = Enum.TryParse(csv.GetField("option2"), out AccessoryOptions option2);
                                bool result3 = Enum.TryParse(csv.GetField("option3"), out AccessoryOptions option3);
                                bool result4 = Enum.TryParse(csv.GetField("option4"), out AccessoryOptions option4);
                                bool result5 = Enum.TryParse(csv.GetField("option5"), out AccessoryOptions option5);
                                record.Option1 = option1;
                                record.Option2 = option2;
                                record.Option3 = option3;
                                record.Option4 = option4;
                                record.Option5 = option5;
                                record.Value1 = int.Parse(csv.GetField("value1"));
                                record.Value2 = int.Parse(csv.GetField("value2"));
                                record.Value3 = int.Parse(csv.GetField("value3"));
                                record.Value4 = int.Parse(csv.GetField("value4"));
                                record.Value5 = int.Parse(csv.GetField("value5"));
                                accPresets.Add(record);
                            }
                            await SQLiteDatabaseManager.Database.DeleteAllAsync<AccessoryPresetsDatabase>();
                            await SQLiteDatabaseManager.Database.InsertAllAsync(accPresets);
                        }
                    }
                }
                catch
                {
                    failed = true;
                }
                //Tamers
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync("https://raw.githubusercontent.com/DMOHelper/DMOHelper/master/csvResources/tamers.csv"))
                    using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                    {
                        reader = new StreamReader(streamToReadFrom);
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            csv.Read();
                            csv.ReadHeader();
                            while (csv.Read())
                            {
                                var record = new Tamer
                                {
                                    Name = csv.GetField("name"),
                                    HP = int.Parse(csv.GetField("hp")),
                                    DS = int.Parse(csv.GetField("ds")),
                                    DE = int.Parse(csv.GetField("de")),
                                    AT = int.Parse(csv.GetField("at")),
                                    PassiveStat1 = csv.GetField("passive1Stat"),
                                    PassiveStat2 = csv.GetField("passive2Stat"),
                                    PassiveAttribute1 = Enum.Parse<DigimonAttribute>(csv.GetField("passive1Attribute")),
                                    PassiveAttribute2 = Enum.Parse<DigimonAttribute>(csv.GetField("passive2Attribute")),
                                    PassiveValue1 = int.Parse(csv.GetField("passive1Value")),
                                    PassiveValue2 = int.Parse(csv.GetField("passive2Value")),
                                    Skill = csv.GetField("skill")
                                };
                                tamers.Add(record);
                            }
                        }
                        await SQLiteDatabaseManager.Database.DeleteAllAsync<Tamer>();
                        await SQLiteDatabaseManager.Database.InsertAllAsync(tamers);
                    }
                }
                catch
                {
                    failed = true;
                }
                //Tamer Skills
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync("https://raw.githubusercontent.com/DMOHelper/DMOHelper/master/csvResources/tamerSkills.csv"))
                    using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                    {
                        reader = new StreamReader(streamToReadFrom);
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            csv.Read();
                            csv.ReadHeader();
                            while (csv.Read())
                            {
                                var record = new TamerSkill
                                {
                                    Name = csv.GetField("name"),
                                    HasPartyEffect = bool.Parse(csv.GetField("partyEffect")),
                                    CanStack = bool.Parse(csv.GetField("canStack")),
                                    CT = double.Parse(csv.GetField("CT")),
                                    EnhancedCT = double.Parse(csv.GetField("EnhancedCT")),
                                    DamageResist = double.Parse(csv.GetField("DamageResist")),
                                    EnhancedDamageResist = double.Parse(csv.GetField("EnhancedDamageResist")),
                                    CriticalDamage = double.Parse(csv.GetField("CriticalDamage")),
                                    EnhancedCriticalDamage = double.Parse(csv.GetField("EnhancedCriticalDamage")),
                                    AT = double.Parse(csv.GetField("AT")),
                                    EnhancedAT = double.Parse(csv.GetField("EnhancedAT")),
                                    SkillDamage = double.Parse(csv.GetField("SkillDamage")),
                                    EnhancedSkillDamage = double.Parse(csv.GetField("EnhancedSkillDamage")),
                                    Heal = double.Parse(csv.GetField("Heal")),
                                    EnhancedHeal = double.Parse(csv.GetField("EnhancedHeal")),
                                    DSHeal = double.Parse(csv.GetField("DSHeal")),
                                    EnhancedDSHeal = double.Parse(csv.GetField("EnhancedDSHeal")),
                                    HP = double.Parse(csv.GetField("HP")),
                                    EnhancedHP = double.Parse(csv.GetField("EnhancedHP")),
                                    EV = double.Parse(csv.GetField("EV")),
                                    EnhancedEV = double.Parse(csv.GetField("EnhancedEV")),
                                    HT = double.Parse(csv.GetField("HT")),
                                    EnhancedHT = double.Parse(csv.GetField("EnhancedHT")),
                                    DE = double.Parse(csv.GetField("DE")),
                                    EnhancedDE = double.Parse(csv.GetField("EnhancedDE")),
                                    Cooldown = int.Parse(csv.GetField("cooldown")),
                                    EnhancedCooldown = int.Parse(csv.GetField("enhancedCooldown")),
                                    UltimateCooldown = int.Parse(csv.GetField("ultimateCooldown"))
                                };
                                skills.Add(record);
                            }
                        }
                        await SQLiteDatabaseManager.Database.DeleteAllAsync<TamerSkill>();
                        await SQLiteDatabaseManager.Database.InsertAllAsync(skills);
                    }
                }
                catch
                {
                    failed = true;
                }
                //Titles
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync("https://raw.githubusercontent.com/DMOHelper/DMOHelper/master/csvResources/titles.csv"))
                    using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                    {
                        reader = new StreamReader(streamToReadFrom);
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            csv.Read();
                            csv.ReadHeader();
                            while (csv.Read())
                            {
                                var record = new Title
                                {
                                    Name = csv.GetField("name"),
                                    AT = int.Parse(csv.GetField("at")),
                                    DE = int.Parse(csv.GetField("de")),
                                    HT = int.Parse(csv.GetField("ht")),
                                    HP = int.Parse(csv.GetField("hp")),
                                    DS = int.Parse(csv.GetField("ds")),
                                    CT = int.Parse(csv.GetField("ct")),
                                    EV = int.Parse(csv.GetField("ev")),
                                    SkillDamage = int.Parse(csv.GetField("skilldamage")),
                                    SkillAttribute = Enum.Parse<ElementalAttribute>(csv.GetField("skillAttribute"))
                                };
                                titles.Add(record);
                            }
                        }
                        await SQLiteDatabaseManager.Database.DeleteAllAsync<Title>();
                        await SQLiteDatabaseManager.Database.InsertAllAsync(titles);
                    }
                }
                catch
                {
                    failed = true;
                }
                //Decks
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync("https://raw.githubusercontent.com/DMOHelper/DMOHelper/master/csvResources/decks.csv"))
                    using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                    {
                        reader = new StreamReader(streamToReadFrom);
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            csv.Read();
                            csv.ReadHeader();
                            while (csv.Read())
                            {
                                var record = new Deck
                                {
                                    Name = csv.GetField("name"),
                                    HP = int.Parse(csv.GetField("hp")),
                                    AS = int.Parse(csv.GetField("as")),
                                    CriticalDamage = int.Parse(csv.GetField("criticaldamage")),
                                    Damage = int.Parse(csv.GetField("damage")),
                                    SkillDamage = int.Parse(csv.GetField("skilldamage")),
                                };
                                decks.Add(record);
                            }
                        }
                        await SQLiteDatabaseManager.Database.DeleteAllAsync<Deck>();
                        await SQLiteDatabaseManager.Database.InsertAllAsync(decks);
                    }
                }
                catch
                {
                    failed = true;
                }
                if (!failed)
                {
                    StatInformation.LastPresetUpdate = DateTime.UtcNow;
                }
                return failed;
            }
        }
    }
}
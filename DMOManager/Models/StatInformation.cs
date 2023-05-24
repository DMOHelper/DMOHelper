using DMOHelper.Enums;
using DMOHelper.Helper;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DMOHelper.Models
{
    public class StatInformation : AbstractPropertyChanged
    {
        private Ring ring;
        private Necklace necklace;
        private Earrings earrings;
        private Bracelet bracelet;
        private Seals seals;
        private Digimon digimon;
        private DigiviceSC digivice;
        private TamerStats tamerStats;
        private string tamer;
        private string skill1;
        private string skill2;
        private string deck;
        private string title;
        private double size;
        private int familyBuffs;
        private bool buff1h;
        private bool buff2h;
        private bool islandBuffs;
        private bool evoBuff;
        private bool hikari;
        private bool encouragement;
        private bool henry;
        private bool takato;
        private bool focus;
        private MemorySkillLevel ruler;
        private MemorySkillLevel guardian;

        public DateTime LastPresetUpdate { get; set; }
        public Ring Ring
        {
            get
            {
                return ring ?? new Ring();
            }
            set
            {
                ring = value;
                OnPropertyChanged();
            }
        }
        public Necklace Necklace
        {
            get
            {
                return necklace ?? new Necklace();
            }
            set
            {
                necklace = value;
                OnPropertyChanged();
            }
        }
        public Earrings Earrings
        {
            get
            {
                return earrings ?? new Earrings();
            }
            set
            {
                earrings = value;
                OnPropertyChanged();
            }
        }
        public Bracelet Bracelet
        {
            get
            {
                return bracelet ?? new Bracelet();
            }
            set
            {
                bracelet = value;
                OnPropertyChanged();
            }
        }
        public Seals Seals
        {
            get
            {
                return seals ?? new Seals();
            }
            set
            {
                seals = value;
                OnPropertyChanged();
            }
        }
        public Digimon Digimon
        {
            get { return digimon; }
            set
            {
                digimon = value;
                OnPropertyChanged();
            }
        }
        public DigiviceSC Digivice
        {
            get { return digivice; }
            set
            {
                digivice = value;
                OnPropertyChanged();
            }
        }
        public TamerStats TamerStats
        {
            get { return tamerStats; }
            set
            {
                tamerStats = value;
                OnPropertyChanged();
            }
        }
        public string Tamer
        {
            get { return tamer; }
            set
            {
                tamer = value;
                OnPropertyChanged();
            }
        }
        public string Skill1
        {
            get { return skill1; }
            set
            {
                skill1 = value;
                OnPropertyChanged();
            }
        }
        public string Skill2
        {
            get { return skill2; }
            set
            {
                skill2 = value;
                OnPropertyChanged();
            }
        }
        public string Deck
        {
            get { return deck; }
            set
            {
                deck = value;
                OnPropertyChanged();
            }
        }
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        public double Size
        {
            get { return size; }
            set
            {
                size = value;
                OnPropertyChanged();
            }
        }
        public double AttackClone { get; set; }
        public double CriticalClone { get; set; }
        public double HPClone { get; set; }
        public double EvadeClone { get; set; }
        public int FamilyBuffs
        {
            get { return familyBuffs; }
            set
            {
                familyBuffs = value;
                OnPropertyChanged();
            }
        }
        public bool Buff1h
        {
            get { return buff1h; }
            set
            {
                buff1h = value;
                OnPropertyChanged();
            }
        }
        public bool Buff2h
        {
            get { return buff2h; }
            set
            {
                buff2h = value;
                OnPropertyChanged();
            }
        }
        public bool IslandBuffs
        {
            get { return islandBuffs; }
            set
            {
                islandBuffs = value;
                OnPropertyChanged();
            }
        }
        public bool EvoBuff
        {
            get { return evoBuff; }
            set
            {
                evoBuff = value;
                OnPropertyChanged();
            }
        }
        public bool Hikari
        {
            get { return hikari; }
            set
            {
                hikari = value;
                OnPropertyChanged();
            }
        }
        public bool Encouragement
        {
            get { return encouragement; }
            set
            {
                encouragement = value;
                OnPropertyChanged();
            }
        }
        public bool Henry
        {
            get { return henry; }
            set
            {
                henry = value;
                OnPropertyChanged();
            }
        }
        public bool Takato
        {
            get { return takato; }
            set
            {
                takato = value;
                OnPropertyChanged();
            }
        }
        public bool Focus
        {
            get { return focus; }
            set
            {
                focus = value;
                OnPropertyChanged();
            }
        }
        public MemorySkillLevel Ruler
        {
            get { return ruler; }
            set
            {
                ruler = value;
                OnPropertyChanged();
            }
        }
        public MemorySkillLevel Guardian
        {
            get { return guardian; }
            set
            {
                guardian = value;
                OnPropertyChanged();
            }
        }
        public int Level { get; set; }
        public static List<StatFormula> StatFormulas
        {
            get
            {
                return SQLiteDatabaseManager.Database.Table<StatFormula>().ToListAsync().Result;
            }
        }

        public StatInformation()
        {
            ring = new Ring();
            necklace = new Necklace();
            earrings = new Earrings();
            bracelet = new Bracelet();
            seals = new Seals();
            digivice = new DigiviceSC();
            tamerStats = new TamerStats();
            digimon = new Digimon()
            {
                Name = "Custom"
            };
            Size = 140.0;
            Level = 0;
            LastPresetUpdate = new DateTime(2000, 1, 1);
        }
        internal void Calculate()
        {
            if (StatFormulas.Count > 0) {
                #region GetFormulas
                List<StatFormula> formulas;
                switch (Digimon.Evolution)
                {
                    case Evolution.Champion:
                    case Evolution.ChampionX:
                        formulas = StatFormulas.Where(x => x.Stage == Evolution.Champion).ToList();
                        break;
                    case Evolution.Ultimate:
                    case Evolution.UltimateX:
                        formulas = StatFormulas.Where(x => x.Stage == Evolution.Ultimate).ToList();
                        break;
                    case Evolution.Mega:
                    case Evolution.MegaX:
                        formulas = StatFormulas.Where(x => x.Stage == Evolution.Mega).ToList();
                        break;
                    case Evolution.BurstMode:
                    case Evolution.BurstModeX:
                        formulas = StatFormulas.Where(x => x.Stage == Evolution.BurstMode).ToList();
                        break;
                    case Evolution.Jogress:
                    case Evolution.JogressX:
                        formulas = StatFormulas.Where(x => x.Stage == Evolution.Jogress).ToList();
                        break;
                    case Evolution.Variant:
                        formulas = StatFormulas.Where(x => x.Stage == Evolution.Variant).ToList();
                        break;
                    case Evolution.Armor:
                        formulas = StatFormulas.Where(x => x.Stage == Evolution.Armor).ToList();
                        break;
                    case Evolution.Spirit:
                        formulas = StatFormulas.Where(x => x.Stage == Evolution.Spirit).ToList();
                        break;
                    case Evolution.Rookie:
                    case Evolution.RookieX:
                    default:
                        formulas = StatFormulas.Where(x => x.Stage == Evolution.Rookie).ToList();
                        break;
                }
                #endregion
                Level = formulas.First().MaxLevel;
                OnPropertyChanged("Level");
                Title title = SQLiteDatabaseManager.Database.Table<Title>().FirstAsync(x => x.Name == Title).Result;
                #region HP
                if(Digimon.BaseHP > 0)
                {
                    double baseHPMaxLevel = Math.Floor((Digimon.BaseHP * Size / 100) + formulas.First(x => x.Type == Digimon.Type).HP);
                    double baseHPwithDeck = Math.Floor(baseHPMaxLevel * (1 + (title.HP / 100)));
                    double addedHP = 0;
                    addedHP += baseHPwithDeck * (HPClone / 100);
                    if (Buff1h)
                    {
                        addedHP += baseHPwithDeck * 0.5;
                    }
                    if (Buff2h)
                    {
                        addedHP += baseHPwithDeck * 0.5;
                    }
                    if (Tamer == "Hikari" || Hikari)
                    {
                        addedHP += baseHPwithDeck * 0.3;
                    }
                    if (Encouragement)
                    {
                        addedHP += baseHPwithDeck * 0.3;
                    }

                }
                #endregion

            }
        }

        internal void SaveToDatabase()
        {
            SQLiteDatabaseManager.Database.DeleteAllAsync<Accessory>().Wait();
            SQLiteDatabaseManager.Database.DeleteAllAsync<Digimon>().Wait();
            SQLiteDatabaseManager.Database.DeleteAllAsync<DigiviceSC>().Wait();
            SQLiteDatabaseManager.Database.DeleteAllAsync<TamerStats>().Wait();
            SQLiteDatabaseManager.Database.InsertOrReplaceAsync(Ring).Wait();
            SQLiteDatabaseManager.Database.InsertOrReplaceAsync(Necklace).Wait();
            SQLiteDatabaseManager.Database.InsertOrReplaceAsync(Earrings).Wait();
            SQLiteDatabaseManager.Database.InsertOrReplaceAsync(Bracelet).Wait();
            SQLiteDatabaseManager.Database.InsertOrReplaceAsync(Seals).Wait();
            SQLiteDatabaseManager.Database.InsertOrReplaceAsync(Digimon).Wait();
            SQLiteDatabaseManager.Database.InsertOrReplaceAsync(Digivice).Wait();
            SQLiteDatabaseManager.Database.InsertOrReplaceAsync(TamerStats).Wait();
            SQLiteDatabaseManager.Database.InsertOrReplaceAsync(new StatInfoDatabase(this)).Wait();
        }

        internal static StatInformation LoadFromDatabase()
        {
            var output = new StatInformation();
            var statInfo = SQLiteDatabaseManager.Database.Table<StatInfoDatabase>().FirstOrDefaultAsync().Result;
            if (statInfo != null)
            {
                output.Size = statInfo.Size;
                output.Tamer = statInfo.Tamer;
                output.Skill1 = statInfo.Skill1;
                output.Skill2 = statInfo.Skill2;
                output.FamilyBuffs = statInfo.FamilyBuffs;
                output.Ruler = statInfo.Ruler;
                output.Guardian = statInfo.Guardian;
                output.Buff1h = statInfo.Buff1h;
                output.Buff2h = statInfo.Buff2h;
                output.IslandBuffs = statInfo.IslandBuffs;
                output.EvoBuff = statInfo.EvoBuff;
                output.Hikari = statInfo.Hikari;
                output.Encouragement = statInfo.Encouragement;
                output.Henry = statInfo.Henry;
                output.Takato = statInfo.Takato;
                output.Focus = statInfo.Focus;
                output.Deck = statInfo.Deck;
                output.Title = statInfo.Title;
                output.AttackClone = statInfo.AttackClone;
                output.CriticalClone = statInfo.CriticalClone;
                output.HPClone = statInfo.HPClone;
                output.EvadeClone = statInfo.EvadeClone;
                output.LastPresetUpdate = statInfo.LastPresetUpdate;
            }
            #region Accessories
            var accessories = SQLiteDatabaseManager.Database.Table<Accessory>().ToListAsync().Result;
            foreach (var accessory in accessories)
            {
                switch (accessory.AccessoryType)
                {
                    case AccessoryType.Ring:
                        output.ring = new Ring()
                        {
                            Option1 = accessory.Option1,
                            Option2 = accessory.Option2,
                            Option3 = accessory.Option3,
                            Option4 = accessory.Option4,
                            Option5 = accessory.Option5,
                            Value1 = accessory.Value1,
                            Value2 = accessory.Value2,
                            Value3 = accessory.Value3,
                            Value4 = accessory.Value4,
                            Value5 = accessory.Value5
                        };
                        break;
                    case AccessoryType.Necklace:
                        output.necklace = new Necklace()
                        {
                            Option1 = accessory.Option1,
                            Option2 = accessory.Option2,
                            Option3 = accessory.Option3,
                            Option4 = accessory.Option4,
                            Option5 = accessory.Option5,
                            Value1 = accessory.Value1,
                            Value2 = accessory.Value2,
                            Value3 = accessory.Value3,
                            Value4 = accessory.Value4,
                            Value5 = accessory.Value5
                        };
                        break;
                    case AccessoryType.Earrings:
                        output.earrings = new Earrings()
                        {
                            Option1 = accessory.Option1,
                            Option2 = accessory.Option2,
                            Option3 = accessory.Option3,
                            Option4 = accessory.Option4,
                            Option5 = accessory.Option5,
                            Value1 = accessory.Value1,
                            Value2 = accessory.Value2,
                            Value3 = accessory.Value3,
                            Value4 = accessory.Value4,
                            Value5 = accessory.Value5
                        };
                        break;
                    case AccessoryType.Bracelet:
                        output.bracelet = new Bracelet()
                        {
                            Option1 = accessory.Option1,
                            Option2 = accessory.Option2,
                            Option3 = accessory.Option3,
                            Option4 = accessory.Option4,
                            Option5 = accessory.Option5,
                            Value1 = accessory.Value1,
                            Value2 = accessory.Value2,
                            Value3 = accessory.Value3,
                            Value4 = accessory.Value4,
                            Value5 = accessory.Value5
                        };
                        break;
                }
            }
            #endregion
            var seals = SQLiteDatabaseManager.Database.Table<Seals>().FirstOrDefaultAsync().Result;
            if (seals != null)
            {
                output.Seals = seals;
            }
            var digivice = SQLiteDatabaseManager.Database.Table<DigiviceSC>().FirstOrDefaultAsync().Result;
            if (digivice != null)
            {
                output.Digivice = digivice;
            }
            var tamerStats = SQLiteDatabaseManager.Database.Table<TamerStats>().FirstOrDefaultAsync().Result;
            if (tamerStats != null)
            {
                output.TamerStats = tamerStats;
            }
            var digimon = SQLiteDatabaseManager.Database.Table<Digimon>().FirstOrDefaultAsync().Result;
            if (digimon != null)
            {
                output.Digimon = digimon;
            }
            return output;
        }
    }

    [Table("StatInformation")]
    public class StatInfoDatabase
    {
        [PrimaryKey]
        public int Id { get; set; }
        public double Size { get; set; }
        public double AttackClone { get; set; }
        public double CriticalClone { get; set; }
        public double HPClone { get; set; }
        public double EvadeClone { get; set; }
        public string Tamer { get; set; }
        public string Skill1 { get; set; }
        public string Skill2 { get; set; }
        public string Deck { get; set; }
        public string Title { get; set; }
        public int FamilyBuffs { get; set; }
        public bool Buff1h { get; set; }
        public bool Buff2h { get; set; }
        public bool IslandBuffs { get; set; }
        public bool EvoBuff { get; set; }
        public bool Hikari { get; set; }
        public bool Encouragement { get; set; }
        public bool Henry { get; set; }
        public bool Takato { get; set; }
        public bool Focus { get; set; }
        public MemorySkillLevel Ruler { get; set; }
        public MemorySkillLevel Guardian { get; set; }

        public DateTime LastPresetUpdate { get; set; }
        public StatInfoDatabase()
        {
            Id = 0;
        }
        public StatInfoDatabase(StatInformation statInfo)
        {
            Id = 0;
            Size = statInfo.Size;
            Tamer = statInfo.Tamer;
            Skill1 = statInfo.Skill1;
            Skill2 = statInfo.Skill2;
            FamilyBuffs = statInfo.FamilyBuffs;
            Ruler = statInfo.Ruler;
            Guardian = statInfo.Guardian;
            Buff1h = statInfo.Buff1h;
            Buff2h = statInfo.Buff2h;
            IslandBuffs = statInfo.IslandBuffs;
            EvoBuff = statInfo.EvoBuff;
            Hikari = statInfo.Hikari;
            Encouragement = statInfo.Encouragement;
            Henry = statInfo.Henry;
            Takato = statInfo.Takato;
            Focus = statInfo.Focus;
            Deck = statInfo.Deck;
            Title = statInfo.Title;
            AttackClone = statInfo.AttackClone;
            CriticalClone = statInfo.CriticalClone;
            HPClone = statInfo.HPClone;
            EvadeClone = statInfo.EvadeClone;
            LastPresetUpdate = statInfo.LastPresetUpdate;
        }
    }
}

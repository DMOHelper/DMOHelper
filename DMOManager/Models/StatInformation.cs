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
        private bool aguKizunaBuff;
        private int resultLevel;
        private int resultHP;
        private int resultDamageReduction;
        private int resultPseudoHP;
        private int resultAT;
        private int resultDamage;
        private int resultDamageDoubleAdvantage;
        private int resultCriticalDamage;
        private int resultCriticalDamageDoubleAdvantage;
        private int resultSkill1Damage;
        private int resultSkill1DamageDoubleAdvantage;
        private int resultSkill2Damage;
        private int resultSkill2DamageDoubleAdvantage;
        private int resultSkill3Damage;
        private int resultSkill3DamageDoubleAdvantage;
        private int resultSkill4Damage;
        private int resultSkill4DamageDoubleAdvantage;
        private double resultAttackSpeed;
        private int resultHT;
        private int resultDE;
        private int resultDS;
        private double resultEV;
        private double resultCT;
        private MemorySkillLevel tol;
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
        public bool AguKizunaBuff
        {
            get { return aguKizunaBuff; }
            set
            {
                aguKizunaBuff = value;
                OnPropertyChanged();
            }
        }
        public MemorySkillLevel TOL
        {
            get { return tol; }
            set
            {
                tol = value;
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
        public int ResultLevel
        {
            get { return resultLevel; }
            set
            {
                resultLevel = value;
                OnPropertyChanged();
            }
        }
        public int ResultHP
        {
            get { return resultHP; }
            set
            {
                resultHP = value;
                OnPropertyChanged();
            }
        }
        public int ResultDamageReduction
        {
            get { return resultDamageReduction; }
            set
            {
                resultDamageReduction = value;
                OnPropertyChanged();
            }
        }
        public int ResultPseudoHP
        {
            get { return resultPseudoHP; }
            set
            {
                resultPseudoHP = value;
                OnPropertyChanged();
            }
        }
        public int ResultAT
        {
            get { return resultAT; }
            set
            {
                resultAT = value;
                OnPropertyChanged();
            }
        }
        public int ResultDamage
        {
            get { return resultDamage; }
            set
            {
                resultDamage = value;
                OnPropertyChanged();
            }
        }
        public int ResultDamageDoubleAdvantage
        {
            get { return resultDamageDoubleAdvantage; }
            set
            {
                resultDamageDoubleAdvantage = value;
                OnPropertyChanged();
            }
        }
        public int ResultCriticalDamage
        {
            get { return resultCriticalDamage; }
            set
            {
                resultCriticalDamage = value;
                OnPropertyChanged();
            }
        }
        public int ResultCriticalDamageDoubleAdvantage
        {
            get { return resultCriticalDamageDoubleAdvantage; }
            set
            {
                resultCriticalDamageDoubleAdvantage = value;
                OnPropertyChanged();
            }
        }
        public double ResultAttackSpeed
        {
            get { return resultAttackSpeed; }
            set
            {
                resultAttackSpeed = value;
                OnPropertyChanged();
            }
        }
        public int ResultHT
        {
            get { return resultHT; }
            set
            {
                resultHT = value;
                OnPropertyChanged();
            }
        }
        public int ResultDE
        {
            get { return resultDE; }
            set
            {
                resultDE = value;
                OnPropertyChanged();
            }
        }
        public int ResultDS
        {
            get { return resultDS; }
            set
            {
                resultDS = value;
                OnPropertyChanged();
            }
        }
        public double ResultEV
        {
            get { return resultEV; }
            set
            {
                resultEV = value;
                OnPropertyChanged();
            }
        }
        public double ResultCT
        {
            get { return resultCT; }
            set
            {
                resultCT = value;
                OnPropertyChanged();
            }
        }
        public int ResultSkill1Damage
        {
            get { return resultSkill1Damage; }
            set
            {
                resultSkill1Damage = value;
                OnPropertyChanged();
            }
        }
        public int ResultSkill1DamageDoubleAdvantage
        {
            get { return resultSkill1DamageDoubleAdvantage; }
            set
            {
                resultSkill1DamageDoubleAdvantage = value;
                OnPropertyChanged();
            }
        }
        public int ResultSkill2Damage
        {
            get { return resultSkill2Damage; }
            set
            {
                resultSkill2Damage = value;
                OnPropertyChanged();
            }
        }
        public int ResultSkill2DamageDoubleAdvantage
        {
            get { return resultSkill2DamageDoubleAdvantage; }
            set
            {
                resultSkill2DamageDoubleAdvantage = value;
                OnPropertyChanged();
            }
        }
        public int ResultSkill3Damage
        {
            get { return resultSkill3Damage; }
            set
            {
                resultSkill3Damage = value;
                OnPropertyChanged();
            }
        }
        public int ResultSkill3DamageDoubleAdvantage
        {
            get { return resultSkill3DamageDoubleAdvantage; }
            set
            {
                resultSkill3DamageDoubleAdvantage = value;
                OnPropertyChanged();
            }
        }
        public int ResultSkill4Damage
        {
            get { return resultSkill4Damage; }
            set
            {
                resultSkill4Damage = value;
                OnPropertyChanged();
            }
        }
        public int ResultSkill4DamageDoubleAdvantage
        {
            get { return resultSkill4DamageDoubleAdvantage; }
            set
            {
                resultSkill4DamageDoubleAdvantage = value;
                OnPropertyChanged();
            }
        }
        public static List<StatFormula> StatFormulas { get; set; }

        public StatInformation()
        {
            tamer = "Tai";
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
            ResultLevel = 0;
            LastPresetUpdate = new DateTime(2000, 1, 1);
            StatFormulas = SQLiteDatabaseManager.Database.Table<StatFormula>().ToListAsync().Result;
        }
        internal void Calculate()
        {
            if (StatFormulas.Count == 0) //try reloading
            {
                StatFormulas = SQLiteDatabaseManager.Database.Table<StatFormula>().ToListAsync().Result;
            }
            if (StatFormulas.Count > 0)
            {
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
                ResultLevel = formulas.First().MaxLevel;
                #region Load Title, Deck and Tamer Informations
                Title title;
                Deck deck;
                try
                {
                    title = SQLiteDatabaseManager.Database.Table<Title>().FirstAsync(x => x.Name == Title).Result;
                }
                catch
                {
                    title = new Title()
                    {
                        AT = 0,
                        DE = 0,
                        HP = 0,
                        DS = 0,
                        HT = 0,
                        SkillDamage = 0
                    };
                }
                try
                {
                    deck = SQLiteDatabaseManager.Database.Table<Deck>().FirstAsync(x => x.Name == Deck).Result;
                }
                catch
                {
                    deck = new Deck()
                    {
                        HP = 0,
                        AS = 0,
                        Damage = 0,
                        SkillDamage = 0,
                        CriticalDamage = 0
                    };
                }
                Tamer tamer = SQLiteDatabaseManager.Database.Table<Tamer>().FirstAsync(x => x.Name == Tamer).Result;
                #endregion
                #region HP, DamageReduction and PseudoHP
                if (Digimon.BaseHP > 0)
                {
                    double baseHPMaxLevel = Math.Floor((Digimon.BaseHP * Size / 100) + formulas.First(x => x.Type == Digimon.Type).HP);
                    double baseHPwithDeck = Math.Floor(baseHPMaxLevel * (1 + (deck.HP / 100)));
                    double addedHP = 0;
                    //Clone
                    addedHP += Math.Floor(baseHPwithDeck * (HPClone / 100));
                    //Buffs
                    if (Buff1h)
                    {
                        addedHP += Math.Floor(baseHPwithDeck * 0.5);
                    }
                    if (Buff2h)
                    {
                        addedHP += Math.Floor(baseHPwithDeck * 0.5);
                    }
                    if (Tamer == "Hikari" || Hikari)
                    {
                        addedHP += Math.Floor(baseHPwithDeck * 0.3);
                    }
                    if (Encouragement || Skill1 == "Encouragement" || Skill2 == "Encouragement")
                    {
                        addedHP += Math.Floor(baseHPwithDeck * 0.3);
                    }
                    switch (TOL)
                    {
                        case MemorySkillLevel.Low:
                        case MemorySkillLevel.Lv2:
                            addedHP += Math.Floor(baseHPwithDeck * 0.15);
                            break;
                        case MemorySkillLevel.Mid:
                            addedHP += Math.Floor(baseHPwithDeck * 0.3);
                            break;
                        case MemorySkillLevel.High:
                            addedHP += Math.Floor(baseHPwithDeck * 0.5);
                            break;
                        case MemorySkillLevel.Highest:
                            addedHP += Math.Floor(baseHPwithDeck * 0.65);
                            break;
                        case MemorySkillLevel.Lv1:
                            addedHP += Math.Floor(baseHPwithDeck * 0.1);
                            break;
                        case MemorySkillLevel.Lv3:
                            addedHP += Math.Floor(baseHPwithDeck * 0.25);
                            break;
                        case MemorySkillLevel.None:
                        default:
                            break;
                    }
                    if (IslandBuffs)
                    {
                        addedHP += Math.Floor(baseHPwithDeck * 0.2);
                    }
                    if (tamer.PassiveStat1 == "HP" && tamer.PassiveAttribute1 == Digimon.Attribute)
                    {
                        addedHP += Math.Floor(baseHPwithDeck * (tamer.PassiveValue1 / 100.0));
                    }
                    if (tamer.PassiveStat2 == "HP" && tamer.PassiveAttribute2 == Digimon.Attribute)
                    {
                        addedHP += Math.Floor(baseHPwithDeck * (tamer.PassiveValue2 / 100.0));
                    }
                    //Static values
                    addedHP += Math.Floor(TamerStats.HP * (TamerStats.Intimacy / 100.0));
                    addedHP += Math.Floor(Ring.HP + Necklace.HP + Earrings.HP + Bracelet.HP + Digivice.HP + Seals.HP + title.HP);
                    //Results
                    ResultHP = (int)(baseHPwithDeck + Math.Floor(addedHP));
                    ResultDamageReduction = 0;
                    switch (Guardian)
                    {
                        case MemorySkillLevel.Low:
                        case MemorySkillLevel.Lv2:
                            ResultDamageReduction += 5;
                            break;
                        case MemorySkillLevel.Mid:
                            ResultDamageReduction += 10;
                            break;
                        case MemorySkillLevel.High:
                            ResultDamageReduction += 15;
                            break;
                        case MemorySkillLevel.Highest:
                            ResultDamageReduction += 20;
                            break;
                        case MemorySkillLevel.Lv1:
                            ResultDamageReduction += 2;
                            break;
                        case MemorySkillLevel.Lv3:
                            ResultDamageReduction += 8;
                            break;
                        case MemorySkillLevel.None:
                        default:
                            break;
                    }
                    ResultPseudoHP = (int)Math.Floor(ResultHP * (1 / (1 - (ResultDamageReduction / 100.0))));
                }
                #endregion
                #region Attack, Damage, CriticalDamage
                if (Digimon.BaseAT > 0)
                {
                    double baseATMaxLevel = Math.Floor((Digimon.BaseAT * Size / 100) + formulas.First(x => x.Type == Digimon.Type).AT);
                    double criticalDamageValue = Ring.CriticalDamage + Necklace.CriticalDamage + Earrings.CriticalDamage + Bracelet.CriticalDamage;
                    double addedAT = 0.0;
                    //Clone
                    addedAT += Math.Floor(baseATMaxLevel * (AttackClone / 100));
                    //Buffs
                    if (Buff1h)
                    {
                        addedAT += Math.Floor(baseATMaxLevel * 0.5);
                        criticalDamageValue += 100;
                    }
                    if (Buff2h)
                    {
                        addedAT += Math.Floor(baseATMaxLevel * 0.5);
                    }
                    if (IslandBuffs)
                    {
                        addedAT += Math.Floor(baseATMaxLevel * 0.1);
                    }
                    if (tamer.PassiveStat1 == "AT" && tamer.PassiveAttribute1 == Digimon.Attribute)
                    {
                        addedAT += Math.Floor(baseATMaxLevel * (tamer.PassiveValue1 / 100.0));
                    }
                    if (tamer.PassiveStat2 == "AT" && tamer.PassiveAttribute2 == Digimon.Attribute)
                    {
                        addedAT += Math.Floor(baseATMaxLevel * (tamer.PassiveValue2 / 100.0));
                    }
                    if (Tamer == "Tai")
                    {
                        addedAT += Math.Floor(baseATMaxLevel * 0.5);
                    }
                    if (Skill1 == "Berserker" || Skill2 == "Berserker")
                    {
                        addedAT += Math.Floor(baseATMaxLevel * 0.8);
                    }
                    if (Skill1 == "Suppresion" || Skill2 == "Suppresion")
                    {
                        addedAT += baseATMaxLevel;
                    }
                    //Static Values
                    addedAT += Math.Floor(TamerStats.AT * (TamerStats.Intimacy / 100.0));
                    addedAT += Math.Floor(Ring.Attack + Necklace.Attack + Earrings.Attack + Bracelet.Attack + Digivice.Attack + Seals.AT + title.AT);
                    //Results
                    ResultAT = (int)Math.Floor(baseATMaxLevel + addedAT);
                    double addedDamage = Math.Floor(ResultAT * (deck.Damage / 100.0));


                    /*
                     * Digivice applies only Skill Damage??? Gonna test that
                    if (Digivice.Attribute == Digimon.Attribute || Digivice.Attribute == DigimonAttribute.EqualDigimon)
                    {
                        addedDamage = Math.Floor(ResultAT * Digivice.AttributeValue / 100.0);
                    }
                    if (Digivice.Elemental == Digimon.Elemental || Digivice.Elemental == ElementalAttribute.EqualDigimon)
                    {
                        addedDamage = Math.Floor(ResultAT * Digivice.ElementalValue / 100.0);
                    }
                    */

                    if (EvoBuff)
                    {
                        if (Digimon.Evolution == Evolution.Mega || Digimon.Evolution == Evolution.MegaX)
                        {
                            addedDamage += Math.Floor(ResultAT * 0.5);
                        }
                        else if (Digimon.Evolution == Evolution.BurstMode || Digimon.Evolution == Evolution.BurstModeX)
                        {
                            addedDamage += Math.Floor(ResultAT * 0.25);
                        }
                    }
                    addedDamage += Math.Floor(ResultAT * (FamilyBuffs * 0.2));

                    //TODO
                    //switch (Ruler)
                    //{
                    //    case MemorySkillLevel.Low:
                    //    case MemorySkillLevel.Lv2:
                    //        addedDamage += Math.Floor(ResultAT * 0.05);
                    //        break;
                    //    case MemorySkillLevel.Mid:
                    //        addedDamage += Math.Floor(ResultAT * 0.1);
                    //        break;
                    //    case MemorySkillLevel.High:
                    //        addedDamage += Math.Floor(ResultAT * 0.15);
                    //        break;
                    //    case MemorySkillLevel.Highest:
                    //        addedDamage += Math.Floor(ResultAT * 0.2);
                    //        break;
                    //    case MemorySkillLevel.Lv1:
                    //        addedDamage += Math.Floor(ResultAT * 0.02);
                    //        break;
                    //    case MemorySkillLevel.Lv3:
                    //        addedDamage += Math.Floor(ResultAT * 0.08);
                    //        break;
                    //    case MemorySkillLevel.None:
                    //    default:
                    //        break;
                    //}
                    double addedAdvantage = ResultAT * (1 + ((Ring.Attribute + Necklace.Attribute + Earrings.Attribute + Bracelet.Attribute) / 200.0));
                    ResultDamage = ResultAT + (int)Math.Floor(addedDamage);
                    ResultDamageDoubleAdvantage = ResultAT + (int)Math.Floor(addedDamage + addedAdvantage);
                    ResultCriticalDamage = (int)Math.Floor(ResultDamage * ((criticalDamageValue + deck.CriticalDamage) / 100.0));
                    ResultCriticalDamageDoubleAdvantage = (int)Math.Floor(ResultDamageDoubleAdvantage * ((criticalDamageValue + deck.CriticalDamage) / 100.0));
                }
                #endregion
                #region AttackSpeed
                ResultAttackSpeed = Digimon.AS * (1 - ((Ring.AttackSpeed + Necklace.AttackSpeed + Earrings.AttackSpeed + Bracelet.AttackSpeed + deck.AS + TamerStats.ASReduction) / 100.0));
                #endregion
                #region DS
                if (Digimon.BaseDS > 0)
                {
                    double baseDSMaxLevel = Digimon.BaseDS + formulas.First(x => x.Type == Digimon.Type).DS;
                    double addedDS = 0;
                    //Buffs
                    if (Buff1h)
                    {
                        addedDS += Math.Floor(baseDSMaxLevel * 0.5);
                    }
                    if (Buff2h)
                    {
                        addedDS += Math.Floor(baseDSMaxLevel * 0.5);
                    }
                    switch (TOL)
                    {
                        case MemorySkillLevel.Low:
                        case MemorySkillLevel.Lv2:
                            addedDS += Math.Floor(baseDSMaxLevel * 0.15);
                            break;
                        case MemorySkillLevel.Mid:
                            addedDS += Math.Floor(baseDSMaxLevel * 0.3);
                            break;
                        case MemorySkillLevel.High:
                            addedDS += Math.Floor(baseDSMaxLevel * 0.5);
                            break;
                        case MemorySkillLevel.Highest:
                            addedDS += Math.Floor(baseDSMaxLevel * 0.65);
                            break;
                        case MemorySkillLevel.Lv1:
                            addedDS += Math.Floor(baseDSMaxLevel * 0.1);
                            break;
                        case MemorySkillLevel.Lv3:
                            addedDS += Math.Floor(baseDSMaxLevel * 0.25);
                            break;
                        case MemorySkillLevel.None:
                        default:
                            break;
                    }
                    if (IslandBuffs)
                    {
                        addedDS += Math.Floor(baseDSMaxLevel * 0.2);
                    }
                    //Static values
                    addedDS += Math.Floor(TamerStats.DS * (TamerStats.Intimacy / 100.0));
                    addedDS += Math.Floor(Ring.DS + Necklace.DS + Earrings.DS + Bracelet.DS + Digivice.DS + Seals.DS + title.DS);
                    //Results
                    ResultDS = (int)(baseDSMaxLevel + addedDS);
                }
                #endregion
                #region DE
                if (Digimon.BaseDE > 0)
                {
                    double baseDEMaxLevel = Math.Floor((Digimon.BaseDE * (Size / 100.0)) + formulas.First(x => x.Type == Digimon.Type).DE);
                    double addedDE = 0.0;
                    if (Buff1h)
                    {
                        addedDE += Math.Floor(baseDEMaxLevel * 0.5);
                    }
                    if (Buff2h)
                    {
                        addedDE += Math.Floor(baseDEMaxLevel * 0.5);
                    }
                    if (Tamer == "Jeri" || Skill1 == "Naivity" || Skill2 == "Naivity")
                    {
                        addedDE += 500.0;
                    }
                    addedDE += Math.Floor(TamerStats.DE * (TamerStats.Intimacy / 100.0));
                    addedDE += Math.Floor(Ring.Defense + Necklace.Defense + Earrings.Defense + Bracelet.Defense + Digivice.Defense + Seals.DE + title.DE);
                    ResultDE = (int)(baseDEMaxLevel + addedDE);
                }
                #endregion
                #region Critical Chance
                if (Digimon.BaseCT > 0)
                {
                    double baseCTMaxLevel = (Digimon.BaseCT * (Size / 100.0)) + (formulas.First(x => x.Type == Digimon.Type).CT);
                    double clone = Math.Floor(baseCTMaxLevel * (CriticalClone / 100.0));
                    ResultCT = Math.Round((baseCTMaxLevel + clone + Seals.CT + Ring.Critical + Necklace.Critical + Earrings.Critical + Bracelet.Critical + Digivice.Critical + TamerStats.CT), 2);
                }
                #endregion
                #region HitRate
                if (Digimon.HT > 0)
                {
                    ResultHT = (int)Math.Floor(Digimon.HT + Seals.HT + TamerStats.HT + Ring.HitRate + Necklace.HitRate + Earrings.HitRate + Bracelet.HitRate + Digivice.HitRate);
                }
                #endregion
                #region Evasion
                if (Digimon.EV > 0)
                {
                    double baseEV = Digimon.EV * (1 + (EvadeClone / 100.0));
                    ResultEV = Math.Round((baseEV + Ring.Evade + Necklace.Evade + Earrings.Evade + Bracelet.Evade + Seals.EV + Digivice.Evade), 2);
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
                output.TOL = statInfo.TOL;
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
                output.AguKizunaBuff = statInfo.AguKizunaBuff;
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
        public bool AguKizunaBuff { get; set; }
        public MemorySkillLevel TOL { get; set; }
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
            TOL = statInfo.TOL;
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
            AguKizunaBuff = statInfo.AguKizunaBuff;
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

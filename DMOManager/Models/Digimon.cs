using DMOHelper.Enums;
using DMOHelper.Helper;
using SQLite;
using System;

namespace DMOHelper.Models
{
    [Table("Digimon")]
    public class Digimon : AbstractPropertyChanged, IComparable<Digimon>
    {
        private string name;
        private string rank;
        private Evolution evolution;
        private AttackerType type;
        private int baseHP;
        private int baseDS;
        private int baseAT;
        private double _as;
        private double baseCT;
        private int ht;
        private int baseDE;
        private double ev;
        private int skill1Base;
        private int skill1Increase;
        private int skill1Points;
        private int skill2Base;
        private int skill2Increase;
        private int skill2Points;
        private int skill3Base;
        private int skill3Increase;
        private int skill3Points;
        private int skill4Base;
        private int skill4Increase;
        private int skill4Points;
        private bool skillIncreaseBuff;
        private int skill1Level;
        private int skill2Level;
        private int skill3Level;
        private int skill4Level;
        private DigimonAttribute attribute;
        private ElementalAttribute elemental;

        [PrimaryKey]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string Rank
        {
            get { return rank; }
            set
            {
                rank = value;
                OnPropertyChanged();
            }
        }
        public Evolution Evolution
        {
            get { return evolution; }
            set
            {
                evolution = value;
                OnPropertyChanged();
            }
        }
        public AttackerType Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged();
            }
        }
        public int BaseHP
        {
            get { return baseHP; }
            set
            {
                baseHP = value;
                OnPropertyChanged();
            }
        }
        public int BaseDS
        {
            get { return baseDS; }
            set
            {
                baseDS = value;
                OnPropertyChanged();
            }
        }
        public int BaseAT
        {
            get { return baseAT; }
            set
            {
                baseAT = value;
                OnPropertyChanged();
            }
        }
        public double AS
        {
            get { return _as; }
            set
            {
                _as = value;
                OnPropertyChanged();
            }
        }
        public double BaseCT
        {
            get { return baseCT; }
            set
            {
                baseCT = value;
                OnPropertyChanged();
            }
        }
        public int HT
        {
            get { return ht; }
            set
            {
                ht = value;
                OnPropertyChanged();
            }
        }
        public int BaseDE
        {
            get { return baseDE; }
            set
            {
                baseDE = value;
                OnPropertyChanged();
            }
        }
        public double EV
        {
            get { return ev; }
            set
            {
                ev = value;
                OnPropertyChanged();
            }
        }
        public int Skill1Base
        {
            get { return skill1Base; }
            set
            {
                skill1Base = value;
                OnPropertyChanged();
            }
        }
        public int Skill1Increase
        {
            get { return skill1Increase; }
            set
            {
                skill1Increase = value;
                OnPropertyChanged();
            }
        }
        public int Skill1Points
        {
            get { return skill1Points; }
            set
            {
                skill1Points = value;
                OnPropertyChanged();
            }
        }
        public int Skill2Base
        {
            get { return skill2Base; }
            set
            {
                skill2Base = value;
                OnPropertyChanged();
            }
        }
        public int Skill2Increase
        {
            get { return skill2Increase; }
            set
            {
                skill2Increase = value;
                OnPropertyChanged();
            }
        }
        public int Skill2Points
        {
            get { return skill2Points; }
            set
            {
                skill2Points = value;
                OnPropertyChanged();
            }
        }
        public int Skill3Base
        {
            get { return skill3Base; }
            set
            {
                skill3Base = value;
                OnPropertyChanged();
            }
        }
        public int Skill3Increase
        {
            get { return skill3Increase; }
            set
            {
                skill3Increase = value;
                OnPropertyChanged();
            }
        }
        public int Skill3Points
        {
            get { return skill3Points; }
            set
            {
                skill3Points = value;
                OnPropertyChanged();
            }
        }
        public int Skill4Base
        {
            get { return skill4Base; }
            set
            {
                skill4Base = value;
                OnPropertyChanged();
            }
        }
        public int Skill4Increase
        {
            get { return skill4Increase; }
            set
            {
                skill4Increase = value;
                OnPropertyChanged();
            }
        }
        public int Skill4Points
        {
            get { return skill4Points; }
            set
            {
                skill4Points = value;
                OnPropertyChanged();
            }
        }
        public bool SkillIncreaseBuff
        {
            get { return skillIncreaseBuff; }
            set
            {
                skillIncreaseBuff = value;
                OnPropertyChanged();
            }
        }
        public int Skill1Level
        {
            get { return skill1Level; }
            set
            {
                skill1Level = value;
                OnPropertyChanged();
            }
        }
        public int Skill2Level
        {
            get { return skill2Level; }
            set
            {
                skill2Level = value;
                OnPropertyChanged();
            }
        }
        public int Skill3Level
        {
            get { return skill3Level; }
            set
            {
                skill3Level = value;
                OnPropertyChanged();
            }
        }
        public int Skill4Level
        {
            get { return skill4Level; }
            set
            {
                skill4Level = value;
                OnPropertyChanged();
            }
        }
        public DigimonAttribute Attribute
        {
            get { return attribute; }
            set
            {
                attribute = value;
                OnPropertyChanged();
            }
        }
        public ElementalAttribute Elemental
        {
            get { return elemental; }
            set
            {
                elemental = value;
                OnPropertyChanged();
            }
        }

        public int CompareTo(Digimon? other)
        {
            if (other != null)
            {
                return this.Name.CompareTo(other.Name);
            }
            else return 1;
        }
    }


    [Table("DigimonPresets")]
    public class DigimonPresetsDatabase : Digimon
    {
        public DigimonPresetsDatabase() { }
    }
}

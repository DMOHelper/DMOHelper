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
            get { return elemental;}
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

using DMOHelper.Enums;
using DMOHelper.Helper;
using SQLite;

namespace DMOHelper.Models
{
    [Table("DigiviceSC")]
    public class DigiviceSC : AbstractPropertyChanged
    {
        private DigimonAttribute attribute;
        private ElementalAttribute elemental;
        private double attributeValue;
        private double elementalValue;
        private ChipsetOption chipsetOption1;
        private ChipsetOption chipsetOption2;
        private ChipsetOption chipsetOption3;
        private ChipsetOption chipsetOption4;
        private double chipsetOptionValue1;
        private double chipsetOptionValue2;
        private double chipsetOptionValue3;
        private double chipsetOptionValue4;

        [PrimaryKey]
        public int ID { get; set; }
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
        public double AttributeValue
        {
            get { return attributeValue; }
            set
            {
                attributeValue = value;
                OnPropertyChanged();
            }
        }
        public double ElementalValue
        {
            get { return elementalValue; }
            set
            {
                elementalValue = value;
                OnPropertyChanged();
            }
        }
        public ChipsetOption ChipsetOption1
        {
            get { return chipsetOption1; }
            set
            {
                chipsetOption1 = value;
                OnPropertyChanged();
            }
        }
        public ChipsetOption ChipsetOption2
        {
            get { return chipsetOption2; }
            set
            {
                chipsetOption2 = value;
                OnPropertyChanged();
            }
        }
        public ChipsetOption ChipsetOption3
        {
            get { return chipsetOption3; }
            set
            {
                chipsetOption3 = value;
                OnPropertyChanged();
            }
        }
        public ChipsetOption ChipsetOption4
        {
            get { return chipsetOption4; }
            set
            {
                chipsetOption4 = value;
                OnPropertyChanged();
            }
        }
        public double ChipsetOptionValue1
        {
            get { return chipsetOptionValue1; }
            set
            {
                chipsetOptionValue1 = value;
                OnPropertyChanged();
            }
        }
        public double ChipsetOptionValue2
        {
            get { return chipsetOptionValue2; }
            set
            {
                chipsetOptionValue2 = value;
                OnPropertyChanged();
            }
        }
        public double ChipsetOptionValue3
        {
            get { return chipsetOptionValue3; }
            set
            {
                chipsetOptionValue3 = value;
                OnPropertyChanged();
            }
        }
        public double ChipsetOptionValue4
        {
            get { return chipsetOptionValue4; }
            set
            {
                chipsetOptionValue4 = value;
                OnPropertyChanged();
            }
        }

        public DigiviceSC()
        {
            ID = 0;
        }

        internal double HP
        {
            get
            {
                double output = 0.0;
                if(ChipsetOption1 == ChipsetOption.HP)
                {
                    output += ChipsetOptionValue1;
                }
                if(ChipsetOption2 == ChipsetOption.HP)
                {
                    output += ChipsetOptionValue2;
                }
                if(ChipsetOption3 == ChipsetOption.HP)
                {
                    output += ChipsetOptionValue3;
                }
                if(ChipsetOption4 == ChipsetOption.HP)
                {
                    output += ChipsetOptionValue4;
                }
                return output;
            }
        }
        internal double DS
        {
            get
            {
                double output = 0.0;
                if(ChipsetOption1 == ChipsetOption.DS)
                {
                    output += ChipsetOptionValue1;
                }
                if(ChipsetOption2 == ChipsetOption.DS)
                {
                    output += ChipsetOptionValue2;
                }
                if(ChipsetOption3 == ChipsetOption.DS)
                {
                    output += ChipsetOptionValue3;
                }
                if(ChipsetOption4 == ChipsetOption.DS)
                {
                    output += ChipsetOptionValue4;
                }
                return output;
            }
        }
        internal double Attack
        {
            get
            {
                double output = 0.0;
                if(ChipsetOption1 == ChipsetOption.Attack)
                {
                    output += ChipsetOptionValue1;
                }
                if(ChipsetOption2 == ChipsetOption.Attack)
                {
                    output += ChipsetOptionValue2;
                }
                if(ChipsetOption3 == ChipsetOption.Attack)
                {
                    output += ChipsetOptionValue3;
                }
                if(ChipsetOption4 == ChipsetOption.Attack)
                {
                    output += ChipsetOptionValue4;
                }
                return output;
            }
        }
        internal double Defense
        {
            get
            {
                double output = 0.0;
                if(ChipsetOption1 == ChipsetOption.Defense)
                {
                    output += ChipsetOptionValue1;
                }
                if(ChipsetOption2 == ChipsetOption.Defense)
                {
                    output += ChipsetOptionValue2;
                }
                if(ChipsetOption3 == ChipsetOption.Defense)
                {
                    output += ChipsetOptionValue3;
                }
                if(ChipsetOption4 == ChipsetOption.Defense)
                {
                    output += ChipsetOptionValue4;
                }
                return output;
            }
        }
        internal double Critical
        {
            get
            {
                double output = 0.0;
                if(ChipsetOption1 == ChipsetOption.Critical)
                {
                    output += ChipsetOptionValue1;
                }
                if(ChipsetOption2 == ChipsetOption.Critical)
                {
                    output += ChipsetOptionValue2;
                }
                if(ChipsetOption3 == ChipsetOption.Critical)
                {
                    output += ChipsetOptionValue3;
                }
                if(ChipsetOption4 == ChipsetOption.Critical)
                {
                    output += ChipsetOptionValue4;
                }
                return output;
            }
        }
        internal double HitRate
        {
            get
            {
                double output = 0.0;
                if(ChipsetOption1 == ChipsetOption.HitRate)
                {
                    output += ChipsetOptionValue1;
                }
                if(ChipsetOption2 == ChipsetOption.HitRate)
                {
                    output += ChipsetOptionValue2;
                }
                if(ChipsetOption3 == ChipsetOption.HitRate)
                {
                    output += ChipsetOptionValue3;
                }
                if(ChipsetOption4 == ChipsetOption.HitRate)
                {
                    output += ChipsetOptionValue4;
                }
                return output;
            }
        }
        internal double Evade
        {
            get
            {
                double output = 0.0;
                if(ChipsetOption1 == ChipsetOption.Evade)
                {
                    output += ChipsetOptionValue1;
                }
                if(ChipsetOption2 == ChipsetOption.Evade)
                {
                    output += ChipsetOptionValue2;
                }
                if(ChipsetOption3 == ChipsetOption.Evade)
                {
                    output += ChipsetOptionValue3;
                }
                if(ChipsetOption4 == ChipsetOption.Evade)
                {
                    output += ChipsetOptionValue4;
                }
                return output;
            }
        }
    }
}

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
    }
}

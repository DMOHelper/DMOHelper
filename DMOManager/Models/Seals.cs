using DMOHelper.Helper;
using SQLite;

namespace DMOHelper.Models
{
    [Table("Seals")]
    public class Seals : AbstractPropertyChanged
    {
        [PrimaryKey] public int Id { get; set; }
        private double at;
        private double ct;
        private double ht;
        private double hp;
        private double ds;
        private double de;
        private double ev;
        public double AT
        {
            get { return at; }
            set
            {
                at = value;
                OnPropertyChanged();
            }
        }
        public double CT
        {
            get { return ct; }
            set
            {
                ct = value;
                OnPropertyChanged();
            }
        }
        public double HT
        {
            get { return ht; }
            set
            {
                ht = value;
                OnPropertyChanged();
            }
        }
        public double HP
        {
            get { return hp; }
            set
            {
                hp = value;
                OnPropertyChanged();
            }
        }
        public double DE
        {
            get { return de; }
            set
            {
                de = value;
                OnPropertyChanged();
            }
        }
        public double DS
        {
            get { return ds; }
            set
            {
                ds = value;
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

        public Seals()
        {
            Id = 0;
        }
        public Seals(double at, double ct, double ht, double hp, double ds, double de, double ev)
        {
            Id = 0;
            AT = at;
            CT = ct;
            HT = ht;
            HP = hp;
            DS = ds;
            DE = de;
            EV = ev;
        }
    }
}

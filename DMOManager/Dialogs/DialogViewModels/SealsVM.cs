using DMOHelper.Helper;
using DMOHelper.Models;

namespace DMOHelper.Dialogs.DialogViewModels
{
    public class SealsVM : AbstractPropertyChanged
    {
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

        public SealsVM(Seals seals)
        {
            AT = seals.AT;
            CT = seals.CT;
            HT = seals.HT;
            HP = seals.HP;
            DS = seals.DS;
            DE = seals.DE;
            EV = seals.EV;
        }
    }
}

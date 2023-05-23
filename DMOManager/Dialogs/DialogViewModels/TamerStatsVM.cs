using DMOHelper.Helper;
using DMOHelper.Models;

namespace DMOHelper.Dialogs.DialogViewModels
{
    public class TamerStatsVM : AbstractPropertyChanged
    {
        private int hp;
        private int ds;
        private int at;
        private int de;
        private int friendliness;
        private bool matureBlue;
        private bool professionalBlack;

        public int HP
        {
            get { return hp; }
            set
            {
                hp = value;
                OnPropertyChanged();
            }
        }
        public int DS
        {
            get { return ds; }
            set
            {
                ds = value;
                OnPropertyChanged();
            }
        }
        public int AT
        {
            get { return at; }
            set
            {
                at = value;
                OnPropertyChanged();
            }
        }
        public int DE
        {
            get { return de; }
            set
            {
                de = value;
                OnPropertyChanged();
            }
        }
        public int Friendliness
        {
            get { return friendliness; }
            set
            {
                friendliness = value;
                OnPropertyChanged();
            }
        }
        public bool MatureBlue
        {
            get { return matureBlue; }
            set
            {
                matureBlue = value;
                OnPropertyChanged();
            }
        }
        public bool ProfessionalBlack
        {
            get { return professionalBlack; }
            set
            {
                professionalBlack = value;
                OnPropertyChanged();
            }
        }

        public TamerStatsVM(TamerStats stats)
        {
            HP = stats.HP;
            DS = stats.DS;
            AT = stats.AT;
            DE = stats.DE;
            Friendliness = stats.Friendliness;
            if(stats.ASReduction > 0)
            {
                MatureBlue = true;
                ProfessionalBlack = false;
            }
            else if(stats.HT > 0 && stats.CT > 0)
            {
                MatureBlue = false;
                ProfessionalBlack = true;
            }
            else
            {
                MatureBlue = false;
                ProfessionalBlack = false;
            }
        }
    }
}

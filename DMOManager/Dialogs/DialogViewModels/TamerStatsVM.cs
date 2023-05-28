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
        private int intimacy;
        private int skilldamage;
        private bool matureBlue;
        private bool professionalBlack;
        private bool veteranRed;

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
        public int SkillDamage
        {
            get { return skilldamage; }
            set
            {
                skilldamage = value;
                OnPropertyChanged();
            }
        }
        public int Intimacy
        {
            get { return intimacy; }
            set
            {
                intimacy = value;
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
        public bool VeteranRed
        {
            get { return veteranRed; }
            set
            {
                veteranRed = value;
                OnPropertyChanged();
            }
        }

        public TamerStatsVM(TamerStats stats)
        {
            HP = stats.HP;
            DS = stats.DS;
            AT = stats.AT;
            DE = stats.DE;
            SkillDamage = stats.SkillDamage;
            Intimacy = stats.Intimacy;
            if (stats.ASReduction > 0)
            {
                MatureBlue = true;
                ProfessionalBlack = false;
                VeteranRed = false;
            }
            else if (stats.HT > 0 && stats.CT > 0)
            {
                if (stats.CT > 0)
                {
                    MatureBlue = false;
                    ProfessionalBlack = true;
                    VeteranRed = false;
                }
                else if (stats.CT == 0)
                {
                    MatureBlue = false;
                    ProfessionalBlack = false;
                    VeteranRed = true;
                }
            }
            else
            {
                MatureBlue = false;
                ProfessionalBlack = false;
                VeteranRed = false;
            }
        }
    }
}

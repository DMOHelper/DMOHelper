using DMOHelper.Helper;

namespace DMOHelper.Dialogs.DialogViewModels
{
    public class CloneVM : AbstractPropertyChanged
    {
        private double attackClone;
        private double criticalClone;
        private double evadeClone;
        private double hpClone;

        public double AttackClone

        {
            get { return attackClone; }
            set
            {
                attackClone = value;
                OnPropertyChanged();
            }
        }
        public double CriticalClone
        {
            get { return criticalClone; }
            set
            {
                criticalClone = value;
                OnPropertyChanged();
            }
        }
        public double HPClone
        {
            get { return hpClone; }
            set
            {
                hpClone = value;
                OnPropertyChanged();
            }
        }
        public double EvadeClone
        {
            get { return evadeClone; }
            set
            {
                evadeClone = value;
                OnPropertyChanged();
            }
        }

        public CloneVM(double at, double ct, double hp, double ev)
        {
            AttackClone = at;
            CriticalClone = ct;
            HPClone = hp;
            EvadeClone = ev;
        }
    }
}

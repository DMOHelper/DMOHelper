using DMOHelper.Helper;
using SQLite;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DMOHelper.Models
{
    [Table("Account")]
    public class Account : AbstractPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string _name;
        [Display(Name = "Name")]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        private int _mc;
        [Display(Name = "MT Coins")]
        public int MaintenanceCoins
        {
            get { return _mc; }
            set
            {
                _mc = value;
                OnPropertyChanged();
            }
        }
        private long _money;
        [Display(Name = "Money")]
        public long Money { get
            {
                return _money;
            }
            set
            {
                _money = value;
                OnPropertyChanged();
            }
        }
        [Display(Name = "Total")]
        public long TotalValue
        {
            get
            {
                try
                {
                    long total = Money;
                    foreach (ItemStack stack in VMMain.GetInstance().ItemStacks.Where(x => x.Account == Name))
                    {
                        total += stack.Value;
                    }
                    return total;
                }
                catch (Exception) { return -2; }
            }
        }

        public Account(string name)
        {
            Name = name;
            MaintenanceCoins = 0;
            Money = 0;
        }
        public Account()
        {

        }

        public void RefreshValue()
        {
            OnPropertyChanged(nameof(TotalValue));
        }
    }
}

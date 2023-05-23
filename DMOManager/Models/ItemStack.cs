using DMOHelper.Helper;
using SQLite;
using System.Linq;

namespace DMOHelper.Models
{
    [Table("ItemStack")]
    public class ItemStack : AbstractPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        private int _amount;
        public int Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Value));
            }
        }
        private long _buyPrice;
        public long BuyPrice
        {
            get { return _buyPrice; }
            set
            {
                _buyPrice = value;
                OnPropertyChanged();
            }
        }

        public string Account { get; set; }

        public long Value
        {
            get
            {
                Item item = VMMain.GetInstance().Items.First(x => x.Type == Type);
                return item.TargetPrice * Amount;
            }
        }

        public decimal Margin
        {
            get
            {
                Item item = VMMain.GetInstance().Items.First(x => x.Type == Type);
                return decimal.Round((item.TargetPrice / (decimal)BuyPrice), 3);
            }
        }

        public string MarginText
        {
            get
            {
                if(Margin > 0)
                {
                    return Margin.ToString() + "x";
                }
                else return string.Empty;
            }
        }
        public void RefreshValue()
        {
            OnPropertyChanged(nameof(Value));
            OnPropertyChanged(nameof(MarginText));
        }


        public ItemStack()
        {

        }
        public ItemStack(int amount, string type, long buyPrice, string account)
        {
            Amount = amount;
            Type = type;
            BuyPrice = buyPrice;
            Account = account;
        }
    }
}

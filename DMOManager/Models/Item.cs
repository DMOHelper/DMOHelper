using DMOHelper.Helper;
using SQLite;

namespace DMOHelper.Models
{
    [Table("Item")]
    public class Item : AbstractPropertyChanged
    {
        [PrimaryKey]
        public string Type { get; set; } = string.Empty;
        private long _targetPrice;
        public long TargetPrice
        {
            get { return _targetPrice; }
            set
            {
                _targetPrice = value;
                OnPropertyChanged();
            }
        }

        public Item()
        {

        }
        public Item(string type, long price)
        {
            Type = type;
            TargetPrice = price;
        }
    }
}

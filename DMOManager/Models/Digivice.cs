using DMOHelper.Enums;
using SQLite;

namespace DMOHelper.Models
{
    [Table("Digivice")]
    public class Digivice
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Account { get; set; }
        public ViceType Type { get; set; }
        public Digivice()
        {

        }

        public Digivice(string account, ViceType type)
        {
            Account = account;
            Type = type;
        }
    }
}
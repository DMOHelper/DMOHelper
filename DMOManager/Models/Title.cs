using DMOHelper.Enums;
using SQLite;

namespace DMOHelper.Models
{
    [Table("Title")]
    public class Title
    {
        [PrimaryKey]
        public string Name { get; set; }
        public BuffType Effect1 { get; set; }
        public BuffType Effect2 { get; set; }
        public BuffType Effect3 { get; set; }
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public int Value3 { get; set; }
    }
}

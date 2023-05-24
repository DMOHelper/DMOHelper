using SQLite;

namespace DMOHelper.Models
{
    [Table("TamerStats")]
    public class TamerStats
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int HP { get; set; }
        public int DS { get; set; }
        public int AT { get; set; }
        public int DE { get; set; }
        public int Intimacy { get; set; }
        public int ASReduction { get; set; }
        public int HT { get; set; }
        public int CT { get; set; }

        public TamerStats()
        {
            Id = 0;
        }
    }
}

using SQLite;

namespace DMOHelper.Models
{
    [Table("StatFormula")]
    public class StatFormula
    {
        public string Stat { get; set; }
        public string Stage { get; set; }
        public int QA { get; set; }
        public int SA { get; set; }
        public int NA { get; set; }
        public int DE { get; set; }
        public int MaxLevel { get; set; }
        public StatFormula()
        {
            
        }

    }
}

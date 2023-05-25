using DMOHelper.Enums;
using SQLite;

namespace DMOHelper.Models
{
    [Table("StatFormula")]
    public class StatFormula
    {
        public AttackerType Type { get; set; }
        public Evolution Stage { get; set; }
        public int HP { get; set; }
        public int DS { get; set; }
        public int AT { get; set; }
        public int DE { get; set; }
        public double CT { get; set; }
        public int MaxLevel { get; set; }
        public StatFormula()
        {
            
        }

    }
}

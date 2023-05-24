using SQLite;

namespace DMOHelper.Models
{
    [Table("Deck")]
    public class Deck
    {
        [PrimaryKey]
        public string Name { get; set; }
        public int HP { get; set; }
        public int AS { get; set; }
        public int CriticalDamage { get; set; }
        public int Damage { get; set; }
        public int SkillDamage { get; set; }
    }
}

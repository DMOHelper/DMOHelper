using DMOManager.Enums;
using SQLite;

namespace DMOManager.Models
{
    [Table("Tamer")]
    public class Tamer
    {
        [PrimaryKey]
        public string Name { get; set; }
        public int HP { get; set; }
        public int DS { get; set; }
        public int DE { get; set; }
        public int AT { get; set; }
        public string PassiveStat1 { get; set; }
        public string PassiveStat2 { get; set; }
        public DigimonAttribute PassiveAttribute1 { get; set; }
        public DigimonAttribute PassiveAttribute2 { get; set; }
        public int PassiveValue1 { get; set; }
        public int PassiveValue2 { get; set; }
        public string Skill { get; set; }

        public Tamer() { }
    }
}

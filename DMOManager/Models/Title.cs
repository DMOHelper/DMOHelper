using DMOHelper.Enums;
using SQLite;

namespace DMOHelper.Models
{
    [Table("Title")]
    public class Title
    {
        [PrimaryKey]
        public string Name { get; set; }
        public int AT { get; set; }
        public int DE { get; set; }
        public int HT { get; set; }
        public int HP { get; set; }
        public int DS { get; set; }
        public int CT { get; set; }
        public int EV { get; set; }
        public int SkillDamage { get; set; }
        public ElementalAttribute SkillAttribute { get; set; }
    }
}

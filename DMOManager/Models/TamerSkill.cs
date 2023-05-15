using SQLite;

namespace DMOManager.Models
{
    [Table("TamerSkills")]
    public class TamerSkill
    {
        [PrimaryKey]
        public string Name { get; set; }
        public bool ChangesStat { get; set; }
        public bool HasPartyEffect { get; set; }
        public bool CanStack { get; set; }
        public string Effect1 { get; set; }
        public string Effect2 { get; set; }
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public int Cooldown { get; set; }
        public int EnhancedValue1 { get; set; }
        public int EnhancedValue2 { get; set; }
        public int EnhancedCooldown { get; set; }
        public int UltimateValue1 { get; set; }
        public int UltimateValue2 { get; set; }
        public int UltimateCooldown { get; set; }

        public TamerSkill() { }
    }
}

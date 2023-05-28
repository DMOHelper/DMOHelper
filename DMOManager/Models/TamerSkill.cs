using SQLite;

namespace DMOHelper.Models
{
    [Table("TamerSkills")]
    public class TamerSkill
    {
        [PrimaryKey]
        public string Name { get; set; }
        public bool HasPartyEffect { get; set; }
        public bool CanStack { get; set; }
        public double CT { get; set; }
        public double EnhancedCT { get; set; }
        public double DamageResist { get; set; }
        public double EnhancedDamageResist { get; set; }
        public double CriticalDamage { get; set; }
        public double EnhancedCriticalDamage { get; set; }
        public double AT { get; set; }
        public double EnhancedAT { get; set; }
        public double SkillDamage { get; set; }
        public double EnhancedSkillDamage { get; set; }
        public double Heal { get; set; }
        public double EnhancedHeal { get; set; }
        public double DSHeal { get; set; }
        public double EnhancedDSHeal { get; set; }
        public double HP { get; set; }
        public double EnhancedHP { get; set; }
        public double EV { get; set; }
        public double EnhancedEV { get; set; }
        public double HT { get; set; }
        public double EnhancedHT { get; set; }
        public double DE { get; set; }
        public double EnhancedDE { get; set; }
        public int Cooldown { get; set; }
        public int EnhancedCooldown { get; set; }
        public int UltimateCooldown { get; set; }

        public TamerSkill() { }
    }
}

using DMOHelper.Helper;
using SQLite;

namespace DMOHelper.Models
{
    [Table("Seals")]
    public class Seals : AbstractPropertyChanged
    {
        [PrimaryKey] public int Id { get; set; }

        public double AT { get; set; }
        public double CT { get; set; }
        public double HT { get; set; }
        public double HP { get; set; }
        public double DE { get; set; }
        public double DS { get; set; }
        public double EV { get; set; }


        public Seals()
        {
            Id = 0;
        }
        public Seals(double at, double ct, double ht, double hp, double ds, double de, double ev)
        {
            Id = 0;
            AT = at;
            CT = ct;
            HT = ht;
            HP = hp;
            DS = ds;
            DE = de;
            EV = ev;
        }
    }
}

using DMOManager.Helper;
using Newtonsoft.Json;
using SQLite;

namespace DMOManager.Models
{
    public class StatInformation : AbstractPropertyChanged
    {
        public Ring Ring { get; set; }
        public Necklace Necklace { get; set; }
        public Earrings Earrings { get; set; }
        public Bracelet Bracelet { get; set; }
        public StatInformation() { }

        internal void SaveToDatabase()
        {
            string serialized = JsonConvert.SerializeObject(this);
            var statInfo = new StatInfoDatabase()
            {
                Serialized = serialized
            };
            SQLiteDatabaseManager.Database.InsertOrReplaceAsync(statInfo).Wait();
        }

        internal static StatInformation LoadFromDatabase()
        {
            var statInfo = SQLiteDatabaseManager.Database.Table<StatInfoDatabase>().FirstOrDefaultAsync().Result;
            if (statInfo != null)
            {
                try
                {
                    return JsonConvert.DeserializeObject<StatInformation>(statInfo.Serialized);
                }
                catch
                {
                    return new StatInformation()
                    {
                        Ring = new Ring(),
                        Necklace = new Necklace(),
                        Earrings = new Earrings(),
                        Bracelet = new Bracelet()
                    };
                }
            }
            else return new StatInformation()
            {
                Ring = new Ring(),
                Necklace = new Necklace(),
                Earrings = new Earrings(),
                Bracelet = new Bracelet()
            };
        }
    }

    [Table("StatInformation")]
    public class StatInfoDatabase
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Serialized { get; set; }
        public StatInfoDatabase()
        {
            Id = 0;
        }
    }
}

using DMOManager.Helper;
using DMOManager.Models;
using System.Collections.Generic;

namespace DMOManager.Dialogs.DialogViewModels
{
    public class DigimonVM : AbstractPropertyChanged
    {
        public static string Title { get; } = "Digimon Presets";

        public static List<Digimon> Presets
        {
            get
            {
                List<Digimon> output = new List<Digimon>();
                var presets = SQLiteDatabaseManager.Database.Table<DigimonPresetsDatabase>().ToListAsync().Result;
                foreach (DigimonPresetsDatabase preset in presets)
                {
                    output.Add(preset);
                }
                output.Sort();
                return output;
            }
        }

        private Digimon digimon;
        public Digimon Digimon
        {
            get { return digimon; }
            set
            {
                digimon = value;
                OnPropertyChanged();
            }
        }

        public DigimonVM()
        {
            digimon = new Digimon();
        }
        public DigimonVM(Digimon _digimon)
        {
            digimon = _digimon;
        }
    }
}
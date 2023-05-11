using DMOManager.Enums;
using DMOManager.Helper;
using DMOManager.Models;
using System.Collections.Generic;

namespace DMOManager.Dialogs.DialogViewModels
{
    public class DigimonVM : AbstractPropertyChanged
    {
        public static List<Digimon> Presets
        {
            get
            {
                return new List<Digimon>();
            }
        }

    }
}

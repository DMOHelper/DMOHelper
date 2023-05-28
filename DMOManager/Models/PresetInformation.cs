using System;

namespace DMOHelper.Models
{
    public class PresetInformation
    {
        public DateTime LastPresetUpdate { get; set; }

        public PresetInformation()
        {
            LastPresetUpdate = new DateTime(2000, 1, 1);
        }
    }
}

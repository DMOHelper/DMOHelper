using DMOManager.Enums;
using DMOManager.Helper;
using DMOManager.Models;
using System.Collections.Generic;

namespace DMOManager.Dialogs
{
    public class AccessoryVM : AbstractPropertyChanged
    {
        public static List<AccessoryOptions> Ring
        {
            get
            {
                return Models.Ring.AllowedOptions;
            }
        }
        public static List<AccessoryOptions> Necklace
        {
            get
            {
                return Models.Necklace.AllowedOptions;
            }
        }
        public static List<AccessoryOptions> Earrings
        {
            get
            {
                return Models.Earrings.AllowedOptions;
            }
        }
        public static List<AccessoryOptions> Bracelet
        {
            get
            {
                return Models.Bracelet.AllowedOptions;
            }
        }

        private Ring currentRing;
        public Ring CurrentRing
        {
            get { return currentRing; }
            set
            {
                currentRing = value;
                OnPropertyChanged();
            }
        }
        private Necklace currentNecklace;
        public Necklace CurrentNecklace
        {
            get { return currentNecklace; }
            set
            {
                currentNecklace = value;
                OnPropertyChanged();
            }
        }
        private Earrings currentEarrings;
        public Earrings CurrentEarrings
        {
            get { return currentEarrings; }
            set
            {
                currentEarrings = value;
                OnPropertyChanged();
            }
        }
        private Bracelet currentBracelet;
        public Bracelet CurrentBracelet
        {
            get { return currentBracelet; }
            set
            {
                currentBracelet = value;
                OnPropertyChanged();
            }
        }

        public AccessoryVM()
        {
            currentRing = new Ring();
            currentNecklace = new Necklace();
            currentBracelet = new Bracelet();
            currentEarrings = new Earrings();
        }

        public AccessoryVM(Ring cRing, Necklace cNeck, Earrings cEars, Bracelet cBrace)
        {
            currentRing = cRing;
            currentNecklace = cNeck;
            currentEarrings = cEars;
            currentBracelet = cBrace;
        }
    }
}

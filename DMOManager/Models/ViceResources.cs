using DMOManager.Enums;
using DMOManager.Helper;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace DMOManager.Models
{
    [Table("ViceResources")]
    public class ViceResources : AbstractPropertyChanged
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Account { get; set; }
        private ViceType _current;

        #region True Vice Materials

        #region EOE
        private int _eoe;
        public int EOE
        {
            get
            {
                return _eoe;
            }
            set
            {
                _eoe = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NeededEOEForUpgrade));
                OnPropertyChanged(nameof(NeededEOEForTV));
                OnPropertyChanged(nameof(Resources));
            }
        }
        public int? NeededEOEForUpgrade
        {
            get
            {
                switch (_current)
                {
                    case ViceType.Beg0:
                        return 149 - EOE;
                    case ViceType.Beg1:
                        return 211 - EOE;
                    case ViceType.Beg2:
                        return 287 - EOE;
                    case ViceType.Adv0:
                        return 301 - EOE;
                    case ViceType.Adv1:
                        return 307 - EOE;
                    case ViceType.Adv2:
                        return 318 - EOE;
                    case ViceType.OT103:
                        return 318 - EOE;
                    case ViceType.TrueVice:
                        return 710 - EOE;
                    default: return null;
                }
            }
        }
        public int? NeededEOEForTV
        {
            get
            {
                switch (_current)
                {
                    case ViceType.Beg0:
                        return 1573 - EOE;
                    case ViceType.Beg1:
                        return 1424 - EOE;
                    case ViceType.Beg2:
                        return 1213 - EOE;
                    case ViceType.Adv0:
                        return 926 - EOE;
                    case ViceType.Adv1:
                        return 625 - EOE;
                    case ViceType.Adv2:
                        return 318 - EOE;
                    case ViceType.OT103:
                        return 318 - EOE;
                    case ViceType.TrueVice:
                        return null;
                    default: return null;
                }
            }
        }
        #endregion

        #region FOE
        private int _foe;
        public int FOE
        {
            get
            {
                return _foe;
            }
            set
            {
                _foe = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NeededFOEForUpgrade));
                OnPropertyChanged(nameof(NeededFOEForTV));
                OnPropertyChanged(nameof(AEOEMakeable));
                OnPropertyChanged(nameof(Resources));
            }
        }
        public int? NeededFOEForUpgrade
        {
            get
            {
                switch (_current)
                {
                    case ViceType.Beg0:
                        return 8 - FOE;
                    case ViceType.Adv0:
                        int leftAEOE = 5 - AEOE;
                        if (leftAEOE > 0)
                        {
                            return (leftAEOE * 3) - FOE;
                        }
                        else return null;
                    default: return null;
                }
            }
        }
        public int? NeededFOEForTV
        {
            get
            {
                int leftAEOE = 5 - AEOE;
                switch (_current)
                {
                    case ViceType.Beg0:
                        if (leftAEOE > 0)
                        {
                            return (leftAEOE * 3) + 8 - FOE;
                        }
                        else return 8 - FOE;
                    case ViceType.Beg1:
                    case ViceType.Beg2:
                    case ViceType.Adv0:
                        if (leftAEOE > 0)
                        {
                            return (leftAEOE * 3) - FOE;
                        }
                        else return null;
                    default: return null;
                }
            }
        }
        #endregion

        #region POE
        private int _poe;
        public int POE
        {
            get
            {
                return _poe;
            }
            set
            {
                _poe = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NeededPOEForUpgrade));
                OnPropertyChanged(nameof(NeededPOEForTV));
                OnPropertyChanged(nameof(AEOEMakeable));
                OnPropertyChanged(nameof(Resources));
            }
        }
        public int? NeededPOEForUpgrade
        {
            get
            {
                switch (_current)
                {
                    case ViceType.Beg1:
                        return 11 - POE;
                    case ViceType.Adv0:
                        int leftAEOE = 5 - AEOE;
                        if (leftAEOE > 0)
                        {
                            return (leftAEOE * 3) - POE;
                        }
                        else return null;
                    default: return null;
                }
            }
        }
        public int? NeededPOEForTV
        {
            get
            {
                int leftAEOE = 5 - AEOE;
                switch (_current)
                {
                    case ViceType.Beg0:
                    case ViceType.Beg1:
                        if (leftAEOE > 0)
                        {
                            return (leftAEOE * 3) + 11 - POE;
                        }
                        else return 11 - POE;
                    case ViceType.Beg2:
                    case ViceType.Adv0:
                        if (leftAEOE > 0)
                        {
                            return (leftAEOE * 3) - POE;
                        }
                        else return null;
                    default: return null;
                }
            }
        }
        #endregion

        #region MyoCore
        private int _myoCore;
        public int MyoCore
        {
            get
            {
                return _myoCore;
            }
            set
            {
                _myoCore = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NeededMyoCoreForUpgrade));
                OnPropertyChanged(nameof(NeededMyoCoreForTV));
                OnPropertyChanged(nameof(HeinousMakeable));
                OnPropertyChanged(nameof(CondensedMakeable));
                OnPropertyChanged(nameof(Resources));
            }
        }
        public int? NeededMyoCoreForUpgrade
        {
            get
            {
                switch (_current)
                {
                    case ViceType.Beg1:
                        return 6 - MyoCore;
                    case ViceType.Adv1:
                        int leftHeinous = 3 - Heinous;
                        if (leftHeinous > 0)
                        {
                            return (leftHeinous * 3) - MyoCore;
                        }
                        else return null;
                    case ViceType.Adv2:
                    case ViceType.OT103:
                        int leftCondensed = 4 - Condensed;
                        if (leftCondensed > 0)
                        {
                            return leftCondensed - MyoCore;
                        }
                        else return null;
                    default: return null;
                }
            }
        }
        public int? NeededMyoCoreForTV
        {
            get
            {
                int hein = (Heinous > 3) ? 3 : Heinous;
                int cond = (Condensed > 4) ? 4 : Condensed;
                int myo = 19;
                switch (_current)
                {
                    case ViceType.Beg0:
                    case ViceType.Beg1:
                        myo -= (hein * 3);
                        myo -= cond;
                        myo -= MyoCore;
                        return myo;
                    case ViceType.Beg2:
                    case ViceType.Adv0:
                    case ViceType.Adv1:
                        if (hein >= 3 && cond >= 4)
                        {
                            return null;
                        }
                        else
                        {
                            myo -= 6;
                            myo -= (hein * 3);
                            myo -= cond;
                            myo -= MyoCore;
                            return myo;
                        }
                    case ViceType.Adv2:
                    case ViceType.OT103:
                        if (cond >= 4)
                        {
                            return null;
                        }
                        else
                        {
                            myo -= 15;
                            myo -= cond;
                            myo -= MyoCore;
                            return myo;
                        }
                    default: return null;
                }
            }
        }
        #endregion

        #region DEnergy
        private int _denergy;
        public int DEnergy
        {
            get
            {
                return _denergy;
            }
            set
            {
                _denergy = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NeededDEnergyForUpgrade));
                OnPropertyChanged(nameof(NeededDEnergyForTV));
                OnPropertyChanged(nameof(Resources));
            }
        }
        public int? NeededDEnergyForUpgrade
        {
            get
            {
                switch (_current)
                {
                    case ViceType.Beg2:
                        return 7 - DEnergy;
                    default: return null;
                }
            }
        }
        public int? NeededDEnergyForTV
        {
            get
            {
                switch (_current)
                {
                    case ViceType.Beg0:
                    case ViceType.Beg1:
                    case ViceType.Beg2:
                        return 7 - DEnergy;
                    default: return null;
                }
            }
        }
        #endregion

        #region BEnergy
        private int _benergy;
        public int BEnergy
        {
            get
            {
                return _benergy;
            }
            set
            {
                _benergy = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NeededBEnergyForUpgrade));
                OnPropertyChanged(nameof(NeededBEnergyForTV));
                OnPropertyChanged(nameof(Resources));
            }
        }
        public int? NeededBEnergyForUpgrade
        {
            get
            {
                switch (_current)
                {
                    case ViceType.Beg2:
                        return 7 - BEnergy;
                    default: return null;
                }
            }
        }
        public int? NeededBEnergyForTV
        {
            get
            {
                switch (_current)
                {
                    case ViceType.Beg0:
                    case ViceType.Beg1:
                    case ViceType.Beg2:
                        return 7 - BEnergy;
                    default: return null;
                }
            }
        }
        #endregion

        #region Virus
        private int _virus;
        public int Virus
        {
            get
            {
                return _virus;
            }
            set
            {
                _virus = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NeededVirusForUpgrade));
                OnPropertyChanged(nameof(NeededVirusForTV));
                OnPropertyChanged(nameof(HeinousMakeable));
                OnPropertyChanged(nameof(Resources));
            }
        }
        public int? NeededVirusForUpgrade
        {
            get
            {
                switch (_current)
                {
                    case ViceType.Beg2:
                        return 8 - Virus;
                    case ViceType.Adv1:
                        int leftHeinous = 3 - Heinous;
                        if (leftHeinous > 0)
                        {
                            return (leftHeinous * 3) - Virus;
                        }
                        else return null;
                    default: return null;
                }
            }
        }
        public int? NeededVirusForTV
        {
            get
            {
                int hein = (Heinous > 3) ? 3 : Heinous;
                int virus = 17;
                switch (_current)
                {
                    case ViceType.Beg0:
                    case ViceType.Beg1:
                    case ViceType.Beg2:
                        virus -= (hein * 3);
                        virus -= Virus;
                        return virus;
                    case ViceType.Adv0:
                    case ViceType.Adv1:
                        if (hein >= 3)
                        {
                            return null;
                        }
                        else
                        {
                            virus -= 8;
                            virus -= (hein * 3);
                            virus -= Virus;
                            return virus;
                        }
                    default: return null;
                }
            }
        }
        #endregion

        #region Skull
        private int _skull;
        public int Skull
        {
            get
            {
                return _skull;
            }
            set
            {
                _skull = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NeededSkullForUpgrade));
                OnPropertyChanged(nameof(NeededSkullForTV));
                OnPropertyChanged(nameof(HeinousMakeable));
                OnPropertyChanged(nameof(CondensedMakeable));
                OnPropertyChanged(nameof(Resources));
            }
        }
        public int? NeededSkullForUpgrade
        {
            get
            {
                switch (_current)
                {
                    case ViceType.Adv0:
                        return 7 - Skull;
                    case ViceType.Adv1:
                        int leftHeinous = 3 - Heinous;
                        if (leftHeinous > 0)
                        {
                            return leftHeinous - Skull;
                        }
                        else return null;
                    case ViceType.Adv2:
                    case ViceType.OT103:
                        int leftCondensed = 4 - Condensed;
                        if (leftCondensed > 0)
                        {
                            return (leftCondensed * 2) - Skull;
                        }
                        else return null;
                    case ViceType.TrueVice:
                        return 4 - Skull;
                    default: return null;
                }
            }
        }
        public int? NeededSkullForTV
        {
            get
            {
                int hein = (Heinous > 3) ? 3 : Heinous;
                int cond = (Condensed > 4) ? 4 : Condensed;
                int skull = 18;
                switch (_current)
                {
                    case ViceType.Beg0:
                    case ViceType.Beg1:
                    case ViceType.Beg2:
                    case ViceType.Adv0:
                        skull -= hein;
                        skull -= (cond * 2);
                        skull -= Skull;
                        return skull;
                    case ViceType.Adv1:
                        if (hein >= 3 && cond >= 4)
                        {
                            return null;
                        }
                        else
                        {
                            skull -= 7;
                            skull -= hein;
                            skull -= (cond * 2);
                            skull -= Skull;
                            return skull;
                        }
                    case ViceType.Adv2:
                        if (cond >= 4)
                        {
                            return null;
                        }
                        else
                        {
                            skull -= 10;
                            skull -= (cond * 2);
                            skull -= Skull;
                            return skull;
                        }
                    default: return null;
                }
            }
        }
        #endregion

        #region Soul
        private int _soul;
        public int Soul
        {
            get
            {
                return _soul;
            }
            set
            {
                _soul = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NeededSoulForUpgrade));
                OnPropertyChanged(nameof(NeededSoulForTV));
                OnPropertyChanged(nameof(CondensedMakeable));
                OnPropertyChanged(nameof(Resources));
            }
        }
        public int? NeededSoulForUpgrade
        {
            get
            {
                switch (_current)
                {
                    case ViceType.Adv1:
                        return 6 - Soul;
                    case ViceType.Adv2:
                    case ViceType.OT103:
                        int cond = 4 - Condensed;
                        if (cond > 0)
                        {
                            return cond - Soul;
                        }
                        else return null;
                    case ViceType.TrueVice:
                        return 2 - Soul;
                    default: return null;
                }
            }
        }
        public int? NeededSoulForTV
        {
            get
            {
                int cond = (Condensed > 4) ? 4 : Condensed;
                int soul = 10;
                switch (_current)
                {
                    case ViceType.Beg0:
                    case ViceType.Beg1:
                    case ViceType.Beg2:
                    case ViceType.Adv0:
                    case ViceType.Adv1:
                        soul -= cond;
                        soul -= Soul;
                        return soul;
                    case ViceType.Adv2:
                    case ViceType.OT103:
                        if (cond >= 4)
                        {
                            return null;
                        }
                        else
                        {
                            soul -= 6;
                            soul -= cond;
                            return soul;
                        }
                    default: return null;
                }
            }
        }
        #endregion

        #region Venom
        private int _venom;
        public int Venom
        {
            get
            {
                return _venom;
            }
            set
            {
                _venom = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NeededVenomForUpgrade));
                OnPropertyChanged(nameof(NeededVenomForTV));
                OnPropertyChanged(nameof(Resources));
            }
        }
        public int? NeededVenomForUpgrade
        {
            get
            {
                switch (_current)
                {
                    case ViceType.Adv2:
                    case ViceType.OT103:
                        return 7 - Venom;
                    case ViceType.TrueVice:
                        return 1 - Venom;
                    default: return null;
                }
            }
        }
        public int? NeededVenomForTV
        {
            get
            {
                switch (_current)
                {
                    case ViceType.Beg0:
                    case ViceType.Beg1:
                    case ViceType.Beg2:
                    case ViceType.Adv0:
                    case ViceType.Adv1:
                    case ViceType.Adv2:
                    case ViceType.OT103:
                        return 7 - Venom;
                    default: return null;
                }
            }
        }
        #endregion

        #region AEOE
        private int _aeoe;
        public int AEOE
        {
            get
            {
                return _aeoe;
            }
            set
            {
                _aeoe = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NeededAEOEForUpgrade));
                OnPropertyChanged(nameof(NeededAEOEForTV));
                OnPropertyChanged(nameof(Resources));
            }
        }
        public int? NeededAEOEForUpgrade
        {
            get
            {
                switch (_current)
                {
                    case ViceType.Adv0:
                        return 5 - AEOE;
                    default: return null;
                }
            }
        }
        public int? NeededAEOEForTV
        {
            get
            {
                switch (_current)
                {
                    case ViceType.Beg0:
                    case ViceType.Beg1:
                    case ViceType.Beg2:
                    case ViceType.Adv0:
                        return 5 - AEOE;
                    default: return null;
                }
            }
        }
        #endregion

        #region Heinous
        private int _heinous;
        public int Heinous
        {
            get
            {
                return _heinous;
            }
            set
            {
                _heinous = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NeededHeinousForUpgrade));
                OnPropertyChanged(nameof(NeededHeinousForTV));
                OnPropertyChanged(nameof(Resources));
            }
        }
        public int? NeededHeinousForUpgrade
        {
            get
            {
                switch (_current)
                {
                    case ViceType.Adv1:
                        return 3 - Heinous;
                    default: return null;
                }
            }
        }
        public int? NeededHeinousForTV
        {
            get
            {
                switch (_current)
                {
                    case ViceType.Beg0:
                    case ViceType.Beg1:
                    case ViceType.Beg2:
                    case ViceType.Adv0:
                    case ViceType.Adv1:
                        return 3 - Heinous;
                    default: return null;
                }
            }
        }
        #endregion

        #region Condensed
        private int _condensed;
        public int Condensed
        {
            get
            {
                return _condensed;
            }
            set
            {
                _condensed = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NeededCondensedForUpgrade));
                OnPropertyChanged(nameof(NeededCondensedForTV));
                OnPropertyChanged(nameof(Resources));
            }
        }
        public int? NeededCondensedForUpgrade
        {
            get
            {
                switch (_current)
                {
                    case ViceType.Adv2:
                    case ViceType.OT103:
                        return 4 - Condensed;
                    default: return null;
                }
            }
        }
        public int? NeededCondensedForTV
        {
            get
            {
                switch (_current)
                {
                    case ViceType.Beg0:
                    case ViceType.Beg1:
                    case ViceType.Beg2:
                    case ViceType.Adv0:
                    case ViceType.Adv1:
                    case ViceType.Adv2:
                    case ViceType.OT103:
                        return 4 - Condensed;
                    default: return null;
                }
            }
        }
        #endregion

        #endregion

        public void SetCurrent(ViceType type)
        {
            _current = type;
            Refresh();
            OnPropertyChanged(nameof(Resources));
        }

        public void Refresh()
        {
            OnPropertyChanged(nameof(NeededEOEForTV));
            OnPropertyChanged(nameof(NeededEOEForUpgrade));
            OnPropertyChanged(nameof(NeededFOEForTV));
            OnPropertyChanged(nameof(NeededFOEForUpgrade));
            OnPropertyChanged(nameof(NeededPOEForTV));
            OnPropertyChanged(nameof(NeededPOEForUpgrade));
            OnPropertyChanged(nameof(NeededMyoCoreForTV));
            OnPropertyChanged(nameof(NeededMyoCoreForUpgrade));
            OnPropertyChanged(nameof(NeededVirusForTV));
            OnPropertyChanged(nameof(NeededVirusForUpgrade));
            OnPropertyChanged(nameof(NeededDEnergyForTV));
            OnPropertyChanged(nameof(NeededDEnergyForUpgrade));
            OnPropertyChanged(nameof(NeededBEnergyForTV));
            OnPropertyChanged(nameof(NeededBEnergyForUpgrade));
            OnPropertyChanged(nameof(NeededSkullForTV));
            OnPropertyChanged(nameof(NeededSkullForUpgrade));
            OnPropertyChanged(nameof(NeededSoulForTV));
            OnPropertyChanged(nameof(NeededSoulForUpgrade));
            OnPropertyChanged(nameof(NeededVenomForTV));
            OnPropertyChanged(nameof(NeededVenomForUpgrade));
            OnPropertyChanged(nameof(NeededAEOEForTV));
            OnPropertyChanged(nameof(NeededAEOEForUpgrade));
            OnPropertyChanged(nameof(NeededHeinousForTV));
            OnPropertyChanged(nameof(NeededHeinousForUpgrade));
            OnPropertyChanged(nameof(NeededCondensedForTV));
            OnPropertyChanged(nameof(NeededCondensedForUpgrade));
            OnPropertyChanged(nameof(IsUpgradeable));
        }

        public bool IsUpgradeable
        {
            get
            {
                if (_current == ViceType.None)
                {
                    return false;
                }
                else if (NeededEOEForUpgrade.HasEnough() &&
                    NeededFOEForUpgrade.HasEnough() &&
                    NeededPOEForUpgrade.HasEnough() &&
                    NeededMyoCoreForUpgrade.HasEnough() &&
                    NeededVirusForUpgrade.HasEnough() &&
                    NeededDEnergyForUpgrade.HasEnough() &&
                    NeededBEnergyForUpgrade.HasEnough() &&
                    NeededSkullForUpgrade.HasEnough() &&
                    NeededSoulForUpgrade.HasEnough() &&
                    NeededVenomForUpgrade.HasEnough() &&
                    NeededAEOEForUpgrade.HasEnough() &&
                    NeededHeinousForUpgrade.HasEnough() &&
                    NeededCondensedForUpgrade.HasEnough())
                {
                    return true;
                }
                else return false;
            }
        }
        #region Makeable
        public bool AEOEMakeable
        {
            get
            {
                if (FOE >= 3 && POE >= 3)
                {
                    return true;
                }
                else return false;
            }
        }

        public bool HeinousMakeable
        {
            get
            {
                if (Skull >= 1 && MyoCore >= 3 && Virus >= 3)
                {
                    return true;
                }
                else return false;
            }
        }

        public bool CondensedMakeable
        {
            get
            {
                if (MyoCore >= 1 && Skull >= 2 && Soul >= 1)
                {
                    return true;
                }
                else return false;
            }
        }
        #endregion


        public List<ViceResourcesListItem> Resources
        {
            get
            {
                return new List<ViceResourcesListItem>()
                {
                    new ViceResourcesListItem(ViceMaterial.EOE, EOE, NeededEOEForUpgrade, NeededEOEForTV),
                    new ViceResourcesListItem(ViceMaterial.FOE, FOE, NeededFOEForUpgrade, NeededFOEForTV),
                    new ViceResourcesListItem(ViceMaterial.POE, POE, NeededPOEForUpgrade, NeededPOEForTV),
                    new ViceResourcesListItem(ViceMaterial.MyoCore, MyoCore, NeededMyoCoreForUpgrade, NeededMyoCoreForTV),
                    new ViceResourcesListItem(ViceMaterial.DEnergy, DEnergy, NeededDEnergyForUpgrade, NeededDEnergyForTV),
                    new ViceResourcesListItem(ViceMaterial.BEnergy, BEnergy, NeededBEnergyForUpgrade, NeededBEnergyForTV),
                    new ViceResourcesListItem(ViceMaterial.Virus, Virus, NeededVirusForUpgrade, NeededVirusForTV),
                    new ViceResourcesListItem(ViceMaterial.Skull, Skull, NeededSkullForUpgrade, NeededSkullForTV),
                    new ViceResourcesListItem(ViceMaterial.Soul, Soul, NeededSoulForUpgrade, NeededSoulForTV),
                    new ViceResourcesListItem(ViceMaterial.Venom, Venom, NeededVenomForUpgrade, NeededVenomForTV),
                    new ViceResourcesListItem(ViceMaterial.AEOE, AEOE, NeededAEOEForUpgrade, NeededAEOEForTV),
                    new ViceResourcesListItem(ViceMaterial.Heinous, Heinous, NeededHeinousForUpgrade, NeededHeinousForTV),
                    new ViceResourcesListItem(ViceMaterial.Condensed, Condensed, NeededCondensedForUpgrade, NeededCondensedForTV)
                };
            }
        }

        public ViceResources() { }
        public ViceResources(string account)
        {
            Account = account;
            _current = ViceType.None;
        }
    }
}

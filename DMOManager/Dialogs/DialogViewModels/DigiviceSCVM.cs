using DMOHelper.Enums;
using DMOHelper.Models;
using System.Collections.Generic;

namespace DMOHelper.Dialogs.DialogViewModels
{
    public class DigiviceSCVM : DigiviceSC
    {
        public static List<ChipsetOption> ChipsetOptions
        {
            get
            {
                return new List<ChipsetOption>
                {
                    ChipsetOption.None,
                    ChipsetOption.HP,
                    ChipsetOption.DS,
                    ChipsetOption.Attack,
                    ChipsetOption.Defense,
                    ChipsetOption.Critical,
                    ChipsetOption.HitRate,
                    ChipsetOption.Evade
                };
            }
        }
        public static List<DigimonAttribute> DigimonAttributes
        {
            get
            {
                return new List<DigimonAttribute>() {
                    DigimonAttribute.None,
                    DigimonAttribute.Vaccine,
                    DigimonAttribute.Data,
                    DigimonAttribute.Virus,
                    DigimonAttribute.Unknown,
                    DigimonAttribute.EqualDigimon
                };
            }
        }
        public static List<ElementalAttribute> ElementalAttributes
        {
            get
            {
                return new List<ElementalAttribute> {
                    ElementalAttribute.Neutral,
                    ElementalAttribute.Fire,
                    ElementalAttribute.Ice,
                    ElementalAttribute.Land,
                    ElementalAttribute.Light,
                    ElementalAttribute.PitchBlack,
                    ElementalAttribute.Steel,
                    ElementalAttribute.Thunder,
                    ElementalAttribute.Water,
                    ElementalAttribute.Wind,
                    ElementalAttribute.Wood,
                    ElementalAttribute.EqualDigimon
                };
            }
        }

        public DigiviceSCVM(DigiviceSC _digivice)
        {
            Attribute = _digivice.Attribute;
            Elemental = _digivice.Elemental;
            AttributeValue = _digivice.AttributeValue;
            ElementalValue = _digivice.ElementalValue;
            ChipsetOption1 = _digivice.ChipsetOption1;
            ChipsetOption2 = _digivice.ChipsetOption2;
            ChipsetOption3 = _digivice.ChipsetOption3;
            ChipsetOption4 = _digivice.ChipsetOption4;
            ChipsetOptionValue1 = _digivice.ChipsetOptionValue1;
            ChipsetOptionValue2 = _digivice.ChipsetOptionValue2;
            ChipsetOptionValue3 = _digivice.ChipsetOptionValue3;
            ChipsetOptionValue4 = _digivice.ChipsetOptionValue4;
        }
    }
}

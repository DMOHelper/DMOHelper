using System.ComponentModel;

namespace DMOHelper.Enums
{
    public enum ViceType
    {
        None = 0,
        [Description("Digivice of Beginning Lv. 0")]
        Beg0 = 1,
        [Description("Digivice of Beginning Lv. 1")]
        Beg1 = 2,
        [Description("Digivice of Beginning Lv. 2")]
        Beg2 = 3,
        [Description("Digivice of Adventure Lv. 0")]
        Adv0 = 4,
        [Description("Digivice of Adventure Lv. 1")]
        Adv1 = 5,
        [Description("Digivice of Adventure Lv. 2")]
        Adv2 = 6,
        [Description("True Digivice")]
        TrueVice = 7,
        [Description("103-OT-Digivice")]
        OT103 = 8
        
    }
}

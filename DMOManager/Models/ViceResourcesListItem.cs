using DMOManager.Enums;

namespace DMOManager.Models
{
    public class ViceResourcesListItem
    {
        public ViceMaterial Resource { get; set; }
        public int Amount { get; set; }
        public int? Upgrade { get; set; }
        public int? TrueVice { get; set; }

        public ViceResourcesListItem(ViceMaterial res, int a, int? u, int? tv)
        {
            Resource = res;
            Amount = a;
            Upgrade = u;
            TrueVice = tv;
        }
    }
}
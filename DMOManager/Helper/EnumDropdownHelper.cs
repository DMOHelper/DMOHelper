namespace DMOHelper.Helper
{
    public class EnumDropdownHelper
    {
        public string Description { get; set; }
        public int Index { get; set; }

        public EnumDropdownHelper(string desc, int index)
        {
            Description = desc;
            Index = index;
        }
    }
}

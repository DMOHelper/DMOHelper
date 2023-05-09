using DMOManager.Enums;
using DMOManager.Helper;
using DMOManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DMOManager
{
    public sealed class VMMain : AbstractPropertyChanged
    {
        private static readonly Lazy<VMMain> lazy = new Lazy<VMMain>(() => new VMMain());

        private Account selected;
        public Account SelectedAccount
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Account> Accounts { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        public List<ItemStack> ItemStacks { get; set; }
        public List<Digivice> Digivices { get; set; }
        public List<EnumDropdownHelper> ViceTypes { get; set; }
        public List<ViceResources> Resources { get; set; }
        public ObservableCollection<ItemStack> SelectedAccountStacks { get; set; }
        public ObservableCollection<Digivice> SelectedAccountVices { get; set; }
        private ViceResources? _selectedResources;
        public ViceResources? SelectedResources
        {
            get
            {
                return _selectedResources;
            }
            set
            {
                _selectedResources = value;
                OnPropertyChanged();
            }
        }
        public long TotalAll
        {
            get
            {
                Suspicious = false;
                try
                {
                    long total = 0;
                    foreach (Account acc in Accounts)
                    {
                        total += acc.TotalValue;
                    }
                    if (total > 9999999999999)
                    {
                        Suspicious = true;
                        return -1;
                    }
                    else return total;
                }
                catch (Exception)
                {
                    Suspicious = true;
                    return -3;
                }
            }
        }

        private string source;
        public string Source
        {
            get
            {
                return source;
            }
            set
            {
                source = value;
                OnPropertyChanged();
            }
        }
        private int accIndex;
        public int AccIndex
        {
            get
            {
                return accIndex;
            }
            set
            {
                accIndex = value;
                OnPropertyChanged();
            }
        }
        internal bool beer = true;
        private bool suspicious = false;
        public bool Suspicious
        {
            get
            {
                return suspicious; ;
            }
            set
            {
                suspicious = value;
                OnPropertyChanged();
            }
        }


        public VMMain()
        {
            Source = "/Images/Beer.png";
            Accounts = SQLiteDatabaseManager.Database.Table<Account>().ToListAsync().Result.ToCollection();
            Items = SQLiteDatabaseManager.Database.Table<Item>().ToListAsync().Result.ToCollection();
            ItemStacks = SQLiteDatabaseManager.Database.Table<ItemStack>().ToListAsync().Result;
            Digivices = SQLiteDatabaseManager.Database.Table<Digivice>().ToListAsync().Result;
            Resources = SQLiteDatabaseManager.Database.Table<ViceResources>().ToListAsync().Result;
            SelectedAccountStacks = new ObservableCollection<ItemStack>();
            SelectedAccountVices = new ObservableCollection<Digivice>();
            ViceTypes = new List<EnumDropdownHelper>();
            foreach (ViceType type in Enum.GetValues(typeof(ViceType)))
            {
                if (type == ViceType.None) { }
                else ViceTypes.Add(new EnumDropdownHelper(type.GetAttributeOfType<DescriptionAttribute>().Description, (int)type));
            }
        }

        public static VMMain GetInstance()
        {
            return lazy.Value;
        }
        public void AccountSelected(string name)
        {
            SelectedAccountStacks.Clear();
            SelectedAccountVices.Clear();
            ItemStacks.Where(stack => stack.Account == name).ForEach(SelectedAccountStacks.Add);
            Digivices.Where(vice => vice.Account == name).ForEach(SelectedAccountVices.Add);
            try
            {
                SelectedResources = Resources.First(x => x.Account == name);
            }
            catch (InvalidOperationException) { SelectedResources = null; };
        }

        public void Refresh()
        {
            OnPropertyChanged(nameof(TotalAll));
        }
    }
}
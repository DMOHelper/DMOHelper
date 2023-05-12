using CsvHelper;
using DMOManager.Enums;
using DMOManager.Helper;
using DMOManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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
        public StatInformation StatInformation { get; set; }

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
            Task.Run(UpdatePresets);
            Source = "/Images/Beer.png";
            Accounts = SQLiteDatabaseManager.Database.Table<Account>().ToListAsync().Result.ToCollection();
            Items = SQLiteDatabaseManager.Database.Table<Item>().ToListAsync().Result.ToCollection();
            ItemStacks = SQLiteDatabaseManager.Database.Table<ItemStack>().ToListAsync().Result;
            Digivices = SQLiteDatabaseManager.Database.Table<Digivice>().ToListAsync().Result;
            Resources = SQLiteDatabaseManager.Database.Table<ViceResources>().ToListAsync().Result;
            StatInformation = StatInformation.LoadFromDatabase();
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

        public async void UpdatePresets()
        {

            using (HttpClient client = new HttpClient())
            {
                StreamReader reader;
                List<StatFormula> formulas = new List<StatFormula>();
                List<DigimonPresetsDatabase> digiPresets = new List<DigimonPresetsDatabase>();
                List<AccessoryPresetsDatabase> accPresets = new List<AccessoryPresetsDatabase>();
                //Stat Formula
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync("https://raw.githubusercontent.com/DMOHelper/DMOHelper/master/csvResources/statformula.csv"))
                    using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                    {
                        reader = new StreamReader(streamToReadFrom);
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            csv.Read();
                            csv.ReadHeader();
                            while (csv.Read())
                            {
                                var record = new StatFormula();
                                record.Stat = csv.GetField("stat");
                                record.Stage = csv.GetField("stage");
                                record.QA = int.Parse(csv.GetField("qa"));
                                record.SA = int.Parse(csv.GetField("sa"));
                                record.NA = int.Parse(csv.GetField("na"));
                                record.DE = int.Parse(csv.GetField("de"));
                                record.MaxLevel = int.Parse(csv.GetField("maxLevel"));
                                formulas.Add(record);
                            }
                        }
                        if (formulas.Count == 30)
                        {
                            await SQLiteDatabaseManager.Database.DeleteAllAsync<StatFormula>();
                            await SQLiteDatabaseManager.Database.InsertAllAsync(formulas);
                        }
                    }
                }
                catch { return; }
                //Digimon Presets
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync("https://raw.githubusercontent.com/DMOHelper/DMOHelper/master/csvResources/digimonPresets.csv"))
                    using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                    {
                        reader = new StreamReader(streamToReadFrom);
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            csv.Read();
                            csv.ReadHeader();
                            while (csv.Read())
                            {
                                var record = new DigimonPresetsDatabase();
                                record.Name = csv.GetField("name");
                                record.Rank = csv.GetField("rank");
                                bool result = Enum.TryParse(csv.GetField("evolution"), out Evolution evo);
                                if (result)
                                {
                                    record.Evolution = evo;
                                }
                                record.Type = csv.GetField("type");
                                record.BaseHP = int.Parse(csv.GetField("baseHP"));
                                record.BaseDS = int.Parse(csv.GetField("baseDS"));
                                record.BaseAT = int.Parse(csv.GetField("baseAT"));
                                record.AS = int.Parse(csv.GetField("AS")) / 100.0;
                                record.BaseCT = int.Parse(csv.GetField("baseCT")) / 100.0;
                                record.HT = int.Parse(csv.GetField("HT"));
                                record.BaseDE = int.Parse(csv.GetField("baseDE"));
                                record.EV = int.Parse(csv.GetField("EV")) / 100.0;
                                digiPresets.Add(record);
                            }
                            await SQLiteDatabaseManager.Database.DeleteAllAsync<DigimonPresetsDatabase>();
                            await SQLiteDatabaseManager.Database.InsertAllAsync(digiPresets);
                        }
                    }
                }
                catch { return; }
                //Accessory Presets
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync("https://raw.githubusercontent.com/DMOHelper/DMOHelper/master/csvResources/accessoryPresets.csv"))
                    using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                    {
                        reader = new StreamReader(streamToReadFrom);
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            csv.Read();
                            csv.ReadHeader();
                            while (csv.Read())
                            {
                                var record = new AccessoryPresetsDatabase();
                                bool result = Enum.TryParse(csv.GetField("type"), out AccessoryType type);
                                if(result)
                                {
                                    record.AccessoryType = type;
                                }
                                record.Name = csv.GetField("name");
                                bool result1 = Enum.TryParse(csv.GetField("option1"), out AccessoryOptions option1);
                                bool result2 = Enum.TryParse(csv.GetField("option2"), out AccessoryOptions option2);
                                bool result3 = Enum.TryParse(csv.GetField("option3"), out AccessoryOptions option3);
                                bool result4 = Enum.TryParse(csv.GetField("option4"), out AccessoryOptions option4);
                                bool result5 = Enum.TryParse(csv.GetField("option5"), out AccessoryOptions option5);
                                record.Option1 = option1;
                                record.Option2 = option2;
                                record.Option3 = option3;
                                record.Option4 = option4;
                                record.Option5 = option5;
                                record.Value1 = int.Parse(csv.GetField("value1"));
                                record.Value2 = int.Parse(csv.GetField("value2"));
                                record.Value3 = int.Parse(csv.GetField("value3"));
                                record.Value4 = int.Parse(csv.GetField("value4"));
                                record.Value5 = int.Parse(csv.GetField("value5"));
                                accPresets.Add(record);
                            }
                            await SQLiteDatabaseManager.Database.DeleteAllAsync<AccessoryPresetsDatabase>();
                            await SQLiteDatabaseManager.Database.InsertAllAsync(accPresets);
                        }
                    }
                }
                catch { return; }
            }
        }
    }
}
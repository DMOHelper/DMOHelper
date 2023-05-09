using SQLite;
using System.IO;
using System.Globalization;
using DMOManager.Models;

namespace DMOManager
{
    internal static class SQLiteDatabaseManager
    {
        private static CultureInfo culture = new CultureInfo("en-US");

        private static SQLiteAsyncConnection database;
        internal static SQLiteAsyncConnection Database
        {
            get
            {
                if (database == null)
                {
                    database = new SQLiteAsyncConnection(Path.Combine("./DMOManager_Database.db3"), SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

                    database.CreateTableAsync<Account>().Wait();
                    database.CreateTableAsync<Item>().Wait();
                    database.CreateTableAsync<ItemStack>().Wait();
                    database.CreateTableAsync<Digivice>().Wait();
                    database.CreateTableAsync<ViceResources>().Wait();
                    database.CreateTableAsync<StatInfoDatabase>().Wait();
                }
                return database;
            }
        }

        /// <summary>
        /// Standard AppClosureHandling.
        /// </summary>
        internal async static void AppClosureHandling()
        {
            if (database != null)
            {
                await database.CloseAsync();
            }
        }
    }
}


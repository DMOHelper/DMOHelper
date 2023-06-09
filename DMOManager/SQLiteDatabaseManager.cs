﻿using SQLite;
using System.IO;
using System.Globalization;
using DMOHelper.Models;
using System;

namespace DMOHelper
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
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DMOHelper"));
                    database = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DMOHelper\\DMOHelper_Database.db3"), SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

                    database.CreateTableAsync<Account>().Wait();
                    database.CreateTableAsync<Item>().Wait();
                    database.CreateTableAsync<ItemStack>().Wait();
                    database.CreateTableAsync<Digivice>().Wait();
                    database.CreateTableAsync<DigiviceSC>().Wait();
                    database.CreateTableAsync<ViceResources>().Wait();
                    database.CreateTableAsync<StatInfoDatabase>().Wait();
                    database.CreateTableAsync<StatFormula>().Wait();
                    database.CreateTableAsync<DigimonPresetsDatabase>().Wait();
                    database.CreateTableAsync<AccessoryPresetsDatabase>().Wait();
                    database.CreateTableAsync<Accessory>().Wait();
                    database.CreateTableAsync<Digimon>().Wait();
                    database.CreateTableAsync<Seals>().Wait();
                    database.CreateTableAsync<Tamer>().Wait();
                    database.CreateTableAsync<TamerSkill>().Wait();
                    database.CreateTableAsync<TamerStats>().Wait();
                    database.CreateTableAsync<Deck>().Wait();
                    database.CreateTableAsync<Title>().Wait();
                    database.CreateTableAsync<PresetInformation>().Wait();
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


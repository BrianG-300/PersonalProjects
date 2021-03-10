﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArsenalAnalyzer.Models;
using SQLite;

namespace ArsenalAnalyzer.Services
{
    public class BallDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public BallDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Item>().Wait();
        }

        public Task<List<Item>> GetItemsAsync()
        {
            return _database.Table<Item>().ToListAsync();
        }

        public Task<Item> GetItemAsync(int id)
        {
            return _database.Table<Item>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Item p)
        {
            if (p.Id != 0)
            {
                return _database.UpdateAsync(p);
            }
            else
            {
                return _database.InsertAsync(p);
            }
        }

        public Task<int> DeleteItemAsync(Item p)
        {
            return _database.DeleteAsync(p);
        }
    }
}
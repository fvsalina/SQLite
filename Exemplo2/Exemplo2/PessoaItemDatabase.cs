﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Exemplo2
{
    class PessoaItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public PessoaItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Pessoa>().Wait();
        }

        public Task<List<Pessoa>> GetItemsAsync()
        {
            return database.Table<Pessoa>().ToListAsync();
        }

      
        public Task<Pessoa> GetItemAsync(int id)
        {
            return database.Table<Pessoa>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Pessoa item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Pessoa item)
        {
            return database.DeleteAsync(item);
        }
    }
}

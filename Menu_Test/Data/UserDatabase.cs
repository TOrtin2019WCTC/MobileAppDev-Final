using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Menu_Test.Models;
using SQLite;

namespace Menu_Test.Data
{
    public class UserDatabase
    {

        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public UserDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

         async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(PlaceVisited).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(PlaceVisited)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }


        public Task<List<PlaceVisited>> GetItemsAsync()
        {
            return Database.Table<PlaceVisited>().ToListAsync();
        }


        public Task<PlaceVisited> GetItemAsync(int id)
        {
            return Database.Table<PlaceVisited>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(PlaceVisited item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }


        public Task<int> DeleteItemAsync(PlaceVisited item)
        {
            return Database.DeleteAsync(item);
        }



    }
}

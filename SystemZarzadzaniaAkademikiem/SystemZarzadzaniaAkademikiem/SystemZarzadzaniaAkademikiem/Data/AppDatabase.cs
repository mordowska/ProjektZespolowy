using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using SystemZarzadzaniaAkademikiem.Models;

namespace SystemZarzadzaniaAkademikiem.Data
{
    public class AppDatabase
    {
        public SQLiteAsyncConnection Database { get; }
        public AppDatabase(string dbfile)
        {
            Database = new SQLiteAsyncConnection(dbfile);
            Database.CreateTableAsync<Admin>().Wait();
            Database.CreateTableAsync<User>().Wait();
        }
    }
}

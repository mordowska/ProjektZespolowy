using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net.Cipher.Data;
using SQLite.Net.Interop;
using SystemZarzadzaniaAkademikiem.Models;

namespace SystemZarzadzaniaAkademikiem.Data
{
    public class AppDatabase : SecureDatabase
    {
        public SQLiteAsyncConnection Database { get; }
        public AppDatabase(ISQLitePlatform platform, string dbfile, string someSalt) : base(platform, dbfile, someSalt)
        {
            Database = new SQLiteAsyncConnection(dbfile);
        }
        protected override void CreateTables()
        {
            Database.CreateTableAsync<Admin>().Wait();
            Database.CreateTableAsync<User>().Wait();
        }
    }
}

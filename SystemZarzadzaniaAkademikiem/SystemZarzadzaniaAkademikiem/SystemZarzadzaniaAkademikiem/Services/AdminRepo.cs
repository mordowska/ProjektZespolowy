using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using SystemZarzadzaniaAkademikiem.Data;
using SystemZarzadzaniaAkademikiem.Models;

namespace SystemZarzadzaniaAkademikiem.Services
{
    public class AdminRepo : IAdminRepo
    {
        readonly SQLiteAsyncConnection _database;
        public AdminRepo(AppDatabase database)
        {
            _database = database.Database;
            if (_database.Table<SuperUser>().FirstOrDefaultAsync().Result==null)
            {
                _database.InsertAsync(new SuperUser { Login="Admin",Password="S3cr3tP@ss"});
            }
        }
        public Task<SuperUser> GetAdmin()
        {
            return _database.Table<SuperUser>().FirstOrDefaultAsync();
        }
        public Task<int> SaveAdminAsync(SuperUser admin)
        {
            if (admin.Id != 0)
            {
                return _database.UpdateAsync(admin);
            }
            else
            {
                return _database.InsertAsync(admin);
            }
        }
    }
}

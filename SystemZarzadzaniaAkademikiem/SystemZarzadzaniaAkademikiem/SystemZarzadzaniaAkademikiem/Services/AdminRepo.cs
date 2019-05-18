using SQLite;
using System;
using System.Collections.Generic;
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
        }
        public Task<Admin> GetAdmin()
        {
            return _database.Table<Admin>().FirstOrDefaultAsync();
        }
        public Task<int> SaveAdmin(Admin admin)
        {
            if (_database.Table<Admin>().FirstOrDefaultAsync() == null)
            {

            }
            else
            {

            }
        }
    }
}

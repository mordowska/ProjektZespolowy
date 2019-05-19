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
            if (_database.Table<Admin>().FirstOrDefaultAsync()==null)
            {
                _database.InsertAsync(new Admin { Login="Admin",Password="S3cr3tP@ss"});
            }
        }
        public Task<Admin> GetAdmin()
        {
            return _database.Table<Admin>().FirstOrDefaultAsync();
        }
        public Task<int> UpdateAdmin(Admin admin)
        {
            return _database.UpdateAsync(admin);
        }
    }
}

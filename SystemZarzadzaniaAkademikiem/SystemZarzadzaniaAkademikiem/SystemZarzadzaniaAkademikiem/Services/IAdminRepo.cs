using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SystemZarzadzaniaAkademikiem.Models;

namespace SystemZarzadzaniaAkademikiem.Services
{
    public interface IAdminRepo
    {
        Task<Admin> GetAdmin();
        Task<int> SaveAdmin(Admin admin);
    }
}

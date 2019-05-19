using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SystemZarzadzaniaAkademikiem.Models;

namespace SystemZarzadzaniaAkademikiem.Services
{
    public interface IAdminRepo
    {
        Admin GetAdmin();
        int UpdateAdmin(Admin admin);
    }
}

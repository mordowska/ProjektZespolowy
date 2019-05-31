using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using SystemZarzadzaniaAkademikiem.Data;
using SystemZarzadzaniaAkademikiem.Models;

namespace SystemZarzadzaniaAkademikiem.Services
{
    public interface IUserRepo
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserAsync(string id);
        Task<int> SaveUserAsync(User user);
        Task<int> DeleteUserAsync(User user);
    }
}

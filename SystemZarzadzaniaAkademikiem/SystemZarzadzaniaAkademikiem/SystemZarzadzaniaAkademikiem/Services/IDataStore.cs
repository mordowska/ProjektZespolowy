using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SystemZarzadzaniaAkademikiem.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddUserAsync(T category);
        Task<bool> UpdateUserAsync(T category);
        Task<bool> DeleteUserAsync(int id);
        Task<IEnumerable<T>> GetUsersAsync(bool forceRefresh = false);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemZarzadzaniaAkademikiem.Models;

namespace SystemZarzadzaniaAkademikiem.Services
{
    class MockDataStore : IDataStore<User>
    {
        List<User> users;
        public MockDataStore()
        {
            users = new List<User>();
            var mockUsers = new List<User> 
            {
                new User { Id = int.Parse(Guid.NewGuid().ToString()), Name = "Jan", Lastname="Kowalski", Index="233456",Sex="Mężczyzna"},
                new User { Id = int.Parse(Guid.NewGuid().ToString()), Name = "Joanna", Lastname="Nowak",Index="278901",Sex="Kobieta" }
            };
            foreach (var user in mockUsers)
            {
                users.Add(user);
            }
        }

        public async Task<bool> AddUserAsync(User user)
        {
            users.Add(user);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var oldUser = users.Where((User arg) => arg.Id == user.Id).FirstOrDefault();
            users.Remove(oldUser);
            users.Add(user);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var oldUser = users.Where((User arg) => arg.Id == id).FirstOrDefault();
            users.Remove(oldUser);

            return await Task.FromResult(true);
        }
        public async Task<IEnumerable<User>> GetUsersAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(users);
        }
    }
}

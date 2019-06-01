using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SystemZarzadzaniaAkademikiem.Models;

namespace SystemZarzadzaniaAkademikiem.Services
{
    public class RoomRepo : IRoomRepo
    {
        public Task<int> DeleteRoomAsync(Room room)
        {
            throw new NotImplementedException();
        }

        public Task<Room> GetRoomAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Room>> GetRoomsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveRoomAsync(Room room)
        {
            throw new NotImplementedException();
        }
    }
}

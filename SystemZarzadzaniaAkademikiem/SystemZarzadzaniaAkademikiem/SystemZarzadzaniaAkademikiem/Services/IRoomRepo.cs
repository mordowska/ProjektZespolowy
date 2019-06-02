using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SystemZarzadzaniaAkademikiem.Models;

namespace SystemZarzadzaniaAkademikiem.Services
{
    public interface IRoomRepo
    {
        Task<List<Room>> GetRoomsAsync();
        Task<Room> GetRoomAsync(int roomNumber);
        Task<int> SaveRoomAsync(Room room);
        Task<int> DeleteRoomAsync(Room room);
    }
}

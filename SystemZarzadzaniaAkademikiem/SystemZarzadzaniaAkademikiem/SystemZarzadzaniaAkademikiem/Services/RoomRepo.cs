using System.Collections.Generic;
using System.Threading.Tasks;
using SystemZarzadzaniaAkademikiem.Data;
using SystemZarzadzaniaAkademikiem.Models;
using SQLite;

namespace SystemZarzadzaniaAkademikiem.Services
{
    public class RoomRepo : IRoomRepo
    {
        private readonly SQLiteAsyncConnection _database;

        public RoomRepo(AppDatabase database)
        {
            _database = database.Database;
        }

        public Task<int> DeleteRoomAsync(Room room)
        {
            return _database.DeleteAsync(room);
        }

        public Task<Room> GetRoomAsync(int roomNumber)
        {
            return _database.Table<Room>().Where(i => i.RoomNumber == roomNumber).FirstOrDefaultAsync();
        }

        public Task<List<Room>> GetRoomsAsync()
        {
            return _database.Table<Room>().ToListAsync();
        }
        
        public Task<int> SaveRoomAsync(Room room)
        {
            if (room.Id != 0)
                return _database.UpdateAsync(room);
            return _database.InsertAsync(room);
        }
    }
}
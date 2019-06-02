using System.Collections.Generic;
using SQLite;

namespace SystemZarzadzaniaAkademikiem.Models
{
    public class Room
    {
        [PrimaryKey] [AutoIncrement] public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string StudentA { get; set; }
        public string StudentB { get; set; }
        public string Floor { set; get; }

        public Room(List<string> list)
        {
            int.TryParse(list[0], out int result);
            RoomNumber = result;
            Floor = list[1];
            StudentA = list[2];
            StudentB = list[3];
        }

        public Room()
        {
        }
    }
}
using System.Collections.Generic;
using SQLite;

namespace SystemZarzadzaniaAkademikiem.Models
{
    public class Room
    {
        [PrimaryKey] [AutoIncrement] public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string StudentA { get; set; }
        public string StudentB { get; set; }
        public string Floor { set; get; }

        public Room(List<string> list)
        {
            RoomNumber = list[0];
            Floor = list[1];
            StudentA = list[2];
            StudentB = list[3];
        }

        public Room()
        {
        }
    }
}
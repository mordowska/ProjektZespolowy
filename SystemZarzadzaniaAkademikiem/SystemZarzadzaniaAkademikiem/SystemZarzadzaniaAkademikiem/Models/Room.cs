using System;
using System.Collections.Generic;
using SQLite;
using SystemZarzadzaniaAkademikiem.Enums;

namespace SystemZarzadzaniaAkademikiem.Models
{
    public class Room
    {
        [PrimaryKey] [AutoIncrement] public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string StudentA { get; set; }
        public string StudentB { get; set; }
        public Floor Floor { set; get; }

        public Room(List<string> list)
        {
            int.TryParse(list[0], out int result);
            RoomNumber = result;
            StudentA = list[1];
            StudentB = list[2];
            Enum.TryParse(list[3], out Floor floorResult);
            Floor = floorResult;
        }

        public Room()
        {
        }
    }
}
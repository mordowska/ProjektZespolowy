using SQLite;

namespace SystemZarzadzaniaAkademikiem.Models
{
    public class Room
    {
        [PrimaryKey] [AutoIncrement] public int Id { get; set; }

        public string RoomNumber { get; set; }

        public User StudentA { get; set; }
        public User StudentB { get; set; }
    }
}
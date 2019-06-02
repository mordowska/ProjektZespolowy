using SQLite;

namespace SystemZarzadzaniaAkademikiem.Models
{
    public class SuperUser
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull,Unique]
        public string Login { get; set; }
        [NotNull,Unique]
        public string Password { get; set; }
        [NotNull]
        public string Salt { get; set; }
    }
}

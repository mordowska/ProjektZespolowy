using System;
using System.Collections.Generic;
using System.Text;
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
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLite.Net.Cipher.Model;

namespace SystemZarzadzaniaAkademikiem.Models
{
    public class Admin
    {
        [PrimaryKey,NotNull,Unique]
        public string Login { get; set; }
        [NotNull,Unique,Secure]
        public string Password { get; set; }
    }
}

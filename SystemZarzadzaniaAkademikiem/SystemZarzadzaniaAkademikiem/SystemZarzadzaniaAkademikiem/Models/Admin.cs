using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLite.Net.Cipher.Interfaces;
using SQLite.Net.Cipher.Model;

namespace SystemZarzadzaniaAkademikiem.Models
{
    public class Admin:IModel
    {
        [PrimaryKey]
        public string Id { get; set; }
        [NotNull,Unique,Secure]
        public string Login { get; set; }
        [NotNull,Unique,Secure]
        public string Password { get; set; }
    }
}

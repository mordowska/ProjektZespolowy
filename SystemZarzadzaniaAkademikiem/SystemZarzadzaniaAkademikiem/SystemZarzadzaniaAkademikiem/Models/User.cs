using System;
using System.Collections.Generic;
using System.Text;

namespace SystemZarzadzaniaAkademikiem.Models
{
    class User
    {
        public int Id;
        public string Imie { set; get; }
        public string Nazwisko { set; get; }
        public string Indeks { set; get; }
        public string Plec { set; get; }
    }
}

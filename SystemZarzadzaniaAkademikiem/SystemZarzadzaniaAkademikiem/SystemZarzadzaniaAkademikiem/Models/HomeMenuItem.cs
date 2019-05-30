using System;
using System.Collections.Generic;
using System.Text;

namespace SystemZarzadzaniaAkademikiem.Models
{
    public enum MenuItemType
    {
        ChangeAdmin,
        Browse,
        About,
        Logout
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemZarzadzaniaAkademikiem.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SystemZarzadzaniaAkademikiem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CRUDMenu : ContentPage
	{
        CRUDMainPage RootPage;
        List<HomeMenuItem> menuItems;
        public CRUDMenu (CRUDMainPage RootPage = null)
		{
            this.RootPage = RootPage;
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.ChangeAdmin, Title="Change Admin Credentials"},
                new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse Tabels" },
                new HomeMenuItem {Id = MenuItemType.About, Title="About" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
	}
}
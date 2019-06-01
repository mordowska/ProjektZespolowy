using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemZarzadzaniaAkademikiem.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SystemZarzadzaniaAkademikiem.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChangeAdminPage : ContentPage
	{
        AdminChangeViewModel viewModel;
        CRUDMainPage mainPage;
        public ChangeAdminPage (CRUDMainPage mainPage =null)
		{
            this.mainPage = mainPage;
			InitializeComponent ();
            BindingContext = viewModel = new AdminChangeViewModel();
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Test3");
            await mainPage.NavigateFromMenu(1);
        }
    }
}
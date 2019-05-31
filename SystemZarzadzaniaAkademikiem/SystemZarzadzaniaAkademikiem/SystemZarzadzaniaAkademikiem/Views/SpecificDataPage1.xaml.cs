using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemZarzadzaniaAkademikiem.Services;
using SystemZarzadzaniaAkademikiem.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SystemZarzadzaniaAkademikiem.Views
{
	public partial class SpecificDataPage1 : ContentPage
	{
		public SpecificDataPage1 (SpecificDataPage1ViewModel specificDataPage1ViewModel)
		{
            UserRepo userRepo = new UserRepo(App.Database);
			InitializeComponent ();
            Debug.WriteLine(userRepo.GetUserAsync(index).Result.Name);
		}
        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SpecificDataPage2());
        }
    }
}
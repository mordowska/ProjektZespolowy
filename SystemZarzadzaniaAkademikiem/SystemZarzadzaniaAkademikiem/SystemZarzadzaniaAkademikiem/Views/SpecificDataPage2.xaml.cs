using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemZarzadzaniaAkademikiem.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SystemZarzadzaniaAkademikiem.Views
{
    //tu!
	public partial class SpecificDataPage2 : ContentPage
	{
        private UserViewModel viewModel;
        public SpecificDataPage2 ()
		{
			InitializeComponent ();
            viewModel = new UserViewModel();
            BindingContext = viewModel;
        }
        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
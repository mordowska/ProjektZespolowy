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
    public partial class SpecificDataPage2 : ContentPage
	{
        private SpecificDataPage2ViewModel viewModel;
        public SpecificDataPage2 (SpecificDataPage2ViewModel specificDataPage2ViewModel)
		{
			InitializeComponent ();
            BindingContext = viewModel = specificDataPage2ViewModel;
        }
        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
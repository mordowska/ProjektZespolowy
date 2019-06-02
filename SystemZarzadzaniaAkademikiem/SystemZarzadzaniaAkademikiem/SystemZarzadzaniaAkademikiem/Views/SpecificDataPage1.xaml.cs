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
        private SpecificDataPage1ViewModel viewModel;

        public SpecificDataPage1 (SpecificDataPage1ViewModel specificDataPage1ViewModel)
		{
            BindingContext = viewModel = specificDataPage1ViewModel;
            InitializeComponent ();
		}
        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            if (viewModel.isValid)
            {
                await Navigation.PushAsync(new SpecificDataPage2(new SpecificDataPage2ViewModel(viewModel.index)));
            }
        }
    }
}
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
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImportantDataPage : ContentPage
	{
        private ImportantDataViewModel viewModel;
        public ImportantDataPage ()
		{
			InitializeComponent ();
            viewModel = new ImportantDataViewModel();
            BindingContext = viewModel;
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SpecificDataPage1(1));
        }
    }
}
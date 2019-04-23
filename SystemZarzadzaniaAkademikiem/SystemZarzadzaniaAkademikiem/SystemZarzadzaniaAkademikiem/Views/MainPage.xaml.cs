using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SystemZarzadzaniaAkademikiem.ViewModels;

namespace SystemZarzadzaniaAkademikiem.Views
{
    public partial class MainPage : ContentPage
    {
        MainDebugViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MainDebugViewModel();
        }

        async void Button_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImportantDataPage());
        }
    }
}

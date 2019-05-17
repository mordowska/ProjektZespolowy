using System;
using SystemZarzadzaniaAkademikiem.ViewModels;
using Xamarin.Forms;

namespace SystemZarzadzaniaAkademikiem.Views
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MainPageViewModel();
        }

        async void Button_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImportantDataPage());
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            viewModel.Counter = 0;
        }
    }
}

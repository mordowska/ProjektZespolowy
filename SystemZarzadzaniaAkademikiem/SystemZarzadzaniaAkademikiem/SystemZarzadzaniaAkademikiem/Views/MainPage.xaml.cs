using System;
using System.Diagnostics;
using SystemZarzadzaniaAkademikiem.Models;
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
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            User newUser = new User { Name="Krystyna",Lastname="Kasperkowiak",Index="123458",Sex="Woman"};
            await App.Database.SaveUserAsync(newUser);
            var u = await App.Database.GetUserAsync(1) as User;
            Debug.WriteLine(u.Name+u.Lastname+u.Index+u.Sex);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            viewModel.Counter = 0;
        }
    }
}

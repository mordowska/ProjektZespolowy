using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemZarzadzaniaAkademikiem.Views;
using Xamarin.Forms;

namespace SystemZarzadzaniaAkademikiem
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Button_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImportantDataPage());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SystemZarzadzaniaAkademikiem.Views
{
	public partial class SpecificDataPage1 : ContentPage
	{
		public SpecificDataPage1 (int index)
		{
			InitializeComponent ();
		}
        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SpecificDataPage2());
        }
    }
}
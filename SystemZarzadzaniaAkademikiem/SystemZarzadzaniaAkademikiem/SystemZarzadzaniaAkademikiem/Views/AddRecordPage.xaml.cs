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
	public partial class AddRecordPage : ContentPage
	{
        AddRecordViewModel viewModel;
		public AddRecordPage (string tableName)
		{
			InitializeComponent ();
            BindingContext = viewModel = new AddRecordViewModel(tableName);
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadColumnsCommand.Execute(null);
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
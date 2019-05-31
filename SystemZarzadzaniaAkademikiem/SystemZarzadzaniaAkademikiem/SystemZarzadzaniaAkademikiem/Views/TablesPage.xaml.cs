using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemZarzadzaniaAkademikiem.Models;
using SystemZarzadzaniaAkademikiem.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SystemZarzadzaniaAkademikiem.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TablesPage : ContentPage
	{
        TablesViewModel viewModel;
		public TablesPage ()
		{
			InitializeComponent ();
            BindingContext =viewModel = new TablesViewModel();
		}
        async void OnTableSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var table = args.SelectedItem as Table;
            if (table == null)
                return;
            await Navigation.PushAsync(new TableDetailPage());

            // Manually deselect item.
            TablesListView.SelectedItem = null;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadTablesCommand.Execute(null);
        }
    }
}
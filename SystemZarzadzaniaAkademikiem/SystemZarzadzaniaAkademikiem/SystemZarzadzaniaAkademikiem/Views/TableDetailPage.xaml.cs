using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemZarzadzaniaAkademikiem.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SystemZarzadzaniaAkademikiem.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TableDetailPage : ContentPage
	{
        TableDetailViewModel viewModel;
		public TableDetailPage (TableDetailViewModel tableDetailViewModel)
		{
			InitializeComponent ();

            BindingContext = viewModel = tableDetailViewModel;
        }
        protected override void OnAppearing()
        {
            List<SQLiteConnection.ColumnInfo> list = App.Database.DatabaseNotAsync.GetTableInfo(viewModel.name);
            StackLayout s = new StackLayout();
            s.Orientation = StackOrientation.Horizontal;
            foreach (var a in list)
            {
                Debug.WriteLine(a.Name);
                var label = new Label { Text=a.Name};
                s.Children.Add(label);
            }
            Content = new ScrollView
            {
                HorizontalOptions = LayoutOptions.Fill,
                Orientation = ScrollOrientation.Horizontal,
                Content = s
            };
            
        }

    }
}
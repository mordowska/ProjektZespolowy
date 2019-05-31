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
	public partial class TableDetailPage : ContentPage
	{
        TableDetailViewModel viewModel;
		public TableDetailPage (TableDetailViewModel tableDetailViewModel)
		{
			InitializeComponent ();

            BindingContext = viewModel = tableDetailViewModel;
        }
	}
}
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
        public bool isLoading;
		public TableDetailPage (TableDetailViewModel tableDetailViewModel)
		{
			InitializeComponent ();

            BindingContext = viewModel = tableDetailViewModel;
        }
        protected override void OnAppearing()
        {
            if (Content == null)
            {
                List<SQLiteConnection.ColumnInfo> list = App.Database.DatabaseNotAsync.GetTableInfo(viewModel.name);
                StackLayout main = new StackLayout { Orientation = StackOrientation.Vertical };
                Grid mainGrid = new Grid { MinimumHeightRequest = 80 };
                StackLayout s = new StackLayout();
                s.Orientation = StackOrientation.Horizontal;
                int k = 0;
                foreach (var a in list)
                {
                    var label = new Label { Text = a.Name };
                    mainGrid.Children.Add(label, k, 0);
                    k++;
                }
                //main.Children.Add(s,0,0);
                int j = 0;
                var objects = RunSql("SELECT * FROM " + viewModel.name, false);
                for (int row = 0; row < objects.Count; row++)
                {
                    var tempStack = new StackLayout { Orientation = StackOrientation.Horizontal };
                    for (int column = 0; column < objects[row].Length; column++)
                    {
                        if (objects[row][column] == null)
                        {
                            var label = new Label { Text = "NULL" };
                            mainGrid.Children.Add(label, column, row + 1);
                            j = column;
                        }
                        else if (objects[row][column] != null)
                        {
                            if (objects[row][column].ToString().Length <= 1 && column != 18 && column != 19)
                            {
                                if (objects[row][column].ToString() == "0")
                                {
                                    var label = new Label { Text = "NULL" };
                                    mainGrid.Children.Add(label, column, row + 1);
                                    j = column;
                                }
                                else
                                {
                                    var label = new Label { Text = objects[row][column].ToString() };
                                    mainGrid.Children.Add(label, column, row + 1);
                                    j = column;
                                }
                            }
                            else
                            {
                                var label = new Label { Text = objects[row][column].ToString() };
                                mainGrid.Children.Add(label, column, row + 1);
                                j = column;
                            }
                        }
                    }
                    var buttonEdit = new Button { Text = "Edit", CommandParameter = objects[row][0] };
                    var buttonDelete = new Button { Text = "Delete", CommandParameter = objects[row][0] };
                    buttonDelete.Clicked += Remove_Record;
                    buttonEdit.Clicked += Edit_Record;
                    mainGrid.Children.Add(buttonEdit, j + 1, row + 1);
                    mainGrid.Children.Add(buttonDelete, j + 2, row + 1);
                    //j++;
                }
                main.Children.Add(mainGrid);
                var addButton = new Button { Text = "Add", HorizontalOptions = LayoutOptions.Center, WidthRequest = 300 };
                addButton.Clicked += Add_Record;
                main.Children.Add(addButton);
                ScrollView sv = new ScrollView
                {
                    HorizontalOptions = LayoutOptions.Fill,
                    Orientation = ScrollOrientation.Both,
                    Content = main
                };
                Content = sv;
            }

        }
        async private void Add_Record(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddRecordPage(viewModel?.name));
        }
        
        private List<object[]> RunSql(string sqlString, bool includeColumnNamesAsFirstRow)
        {
            var lstRes = new List<object[]>();
            SQLitePCL.sqlite3_stmt stQuery = null;
            try
            {
                stQuery = SQLite3.Prepare2(App.Database.DatabaseNotAsync.Handle, sqlString);
                var colLenght = SQLite3.ColumnCount(stQuery);

                if (includeColumnNamesAsFirstRow)
                {
                    var obj = new object[colLenght];
                    lstRes.Add(obj);
                    for (int i = 0; i < colLenght; i++)
                    {
                        obj[i] = SQLite3.ColumnName(stQuery, i);
                    }
                }

                while (SQLite3.Step(stQuery) == SQLite3.Result.Row)
                {
                    var obj = new object[colLenght];
                    lstRes.Add(obj);
                    for (int i = 0; i < colLenght; i++)
                    {
                        var colType = SQLite3.ColumnType(stQuery, i);
                        switch (colType)
                        {
                            case SQLite3.ColType.Blob:
                                obj[i] = SQLite3.ColumnBlob(stQuery, i);
                                break;
                            case SQLite3.ColType.Float:
                                obj[i] = SQLite3.ColumnDouble(stQuery, i);
                                break;
                            case SQLite3.ColType.Integer:
                                obj[i] = SQLite3.ColumnInt(stQuery, i);
                                break;
                            case SQLite3.ColType.Null:
                                obj[i] = null;
                                break;
                            case SQLite3.ColType.Text:
                                obj[i] = SQLite3.ColumnString(stQuery, i);
                                break;
                        }
                    }
                }
                return lstRes;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (stQuery != null)
                {
                    SQLite3.Finalize(stQuery);
                }
            }
        }
        private void Remove_Record(object sender, EventArgs e)
        {
            var button = sender as Button;
            viewModel?.DeleteRecordCommand.Execute(button.CommandParameter);
            Content = null;
            OnAppearing();
        }
        async private void Edit_Record(object sender, EventArgs e)
        {
            var button = sender as Button;
            await Navigation.PushAsync(new EditRecordPage(viewModel?.name,button.CommandParameter));
        }
    }
}
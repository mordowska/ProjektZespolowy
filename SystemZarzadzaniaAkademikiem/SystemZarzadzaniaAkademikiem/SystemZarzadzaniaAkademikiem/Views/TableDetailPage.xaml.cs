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
            StackLayout main = new StackLayout();
            main.Orientation = StackOrientation.Vertical;
            StackLayout s = new StackLayout();
            s.Orientation = StackOrientation.Horizontal;
            foreach (var a in list)
            {
                Debug.WriteLine(a.Name);
                var label = new Label { Text=a.Name};
                s.Children.Add(label);
            }
            main.Children.Add(s);
            var objects = RunSql("SELECT * FROM "+viewModel.name,false);
            for (int row = 0; row < objects.Count; row++)
            {
                var tempStack = new StackLayout { Orientation = StackOrientation.Horizontal };
                for (int column = 0; column < objects[row].Length; column++)
                {
                    
                    if (objects[row][column] != null) {
                        Debug.WriteLine(objects[row][column]);
                        var label = new Label { Text = objects[row][column].ToString() };
                        tempStack.Children.Add(label);
                    } 
                }
                main.Children.Add(tempStack);
            }
            Content = new ScrollView
            {
                HorizontalOptions = LayoutOptions.Fill,
                Orientation = ScrollOrientation.Horizontal,
                Content = main
            };
            
        }
        public List<object[]> RunSql(string sqlString, bool includeColumnNamesAsFirstRow)
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

    }
}
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using SystemZarzadzaniaAkademikiem.Models;
using SystemZarzadzaniaAkademikiem.Services;
using Xamarin.Forms;

namespace SystemZarzadzaniaAkademikiem.ViewModels
{
    public class AddRecordViewModel : BaseViewModel
    {
        private UserRepo userRepo;
        private AdminRepo adminRepo;
        public ObservableCollection<Column> Columns { get; set; }
        public Command LoadColumnsCommand { get; set; }
        public Command AddRecordCommand { get; set; }
        private string tableName;
        public AddRecordViewModel(string tableName)
        {
            Title = "Add Column";
            this.tableName = tableName;
            Columns = new ObservableCollection<Column>();
            LoadColumnsCommand = new Command(() => ExecuteLoadColumnsCommand());
            AddRecordCommand = new Command(() => ExecuteAddRecordCommand());
            userRepo = new UserRepo(App.Database);
            adminRepo = new AdminRepo(App.Database);
        }
        void ExecuteLoadColumnsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Columns.Clear();
                List<SQLiteConnection.ColumnInfo> list = App.Database.DatabaseNotAsync.GetTableInfo(tableName);
                foreach (var a in list)
                {
                    if (a.Name.ToLower() != "id")
                    {
                        Column c = new Column { Name = a.Name, Value = "" };
                        Columns.Add(c);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        void ExecuteAddRecordCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                switch (tableName)
                {
                    case "User":
                        
                        List<string> temp = new List<string>();
                        for(int i=0;i<Columns.Count;i++)
                        {
                            if (Columns[i].Value == "")
                            {
                                temp.Add(null);
                            }
                            else
                            {
                                temp.Add(Columns[i].Value);
                            }
                            Debug.WriteLine(temp[i]);
                        }
                        
                        User newUser = new User(temp);
                        userRepo.SaveUserAsync(newUser);
                        break;
                    case "SuperUser":
                        SuperUser newSuperUser = new SuperUser
                        {
                            Login = Columns[0].Value,
                            Password = Columns[1].Value 
                        };
                        adminRepo.SaveAdminAsync(newSuperUser);
                        break;
                    default:
                        Debug.WriteLine("Error, uknown table");
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}

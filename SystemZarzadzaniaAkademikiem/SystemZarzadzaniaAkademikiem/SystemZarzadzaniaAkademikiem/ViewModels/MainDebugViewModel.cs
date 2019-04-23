using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using SystemZarzadzaniaAkademikiem.Models;
using SystemZarzadzaniaAkademikiem.Services;
using Xamarin.Forms;

namespace SystemZarzadzaniaAkademikiem.ViewModels
{
    /// <summary>
    /// Ten viewmodel jest tylko po to by wyswietlac pewne informacje na 
    /// mainpage poki nie mamy bazy danych/cruda. Moze byc potem usuniety.
    /// </summary>
    class MainDebugViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public Command LoadUsersCommand { get; set; }
        MockDataStore MockDataStore;
        public MainDebugViewModel()
        {
            Users = new ObservableCollection<User>();
            LoadUsersCommand = new Command(async () => await ExecuteLoadItemsCommandAsync());
        }
        async Task ExecuteLoadItemsCommandAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Users.Clear();
                var users = await MockDataStore.GetUsersAsync(true);
                foreach (var user in users)
                {
                    Users.Add(user);
                }
            }
            catch (Exception) { }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

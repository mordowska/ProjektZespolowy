using System;
using System.Collections.Generic;
using System.Text;
using SystemZarzadzaniaAkademikiem.Services;
using Xamarin.Forms;

namespace SystemZarzadzaniaAkademikiem.ViewModels
{
    public class AdminChangeViewModel : BaseViewModel
    {
        private string _newLogin;
        private string _newPassword;
        public string NewLogin
        {
            get
            {
                return _newLogin;
            }
            set
            {
                _newLogin = value;
                OnPropertyChanged();
            }
        }
        public string NewPassword
        {
            get
            {
                return _newPassword;
            }
            set
            {
                _newPassword = value;
                OnPropertyChanged();
            }
        }
        public Command ChangeAdmin { get; set; }
        AdminRepo adminRepo;
        public AdminChangeViewModel()
        {
            Title = "Changing Admin Credentials";
            ChangeAdmin = new Command(ExecuteChangeAdmin);
            adminRepo = new AdminRepo(App.Database);
        }
        async void ExecuteChangeAdmin()
        {
            await adminRepo.SaveAdminAsync(new Models.SuperUser { Id=1,Login=NewLogin,Password=NewPassword});
        }
    }
}

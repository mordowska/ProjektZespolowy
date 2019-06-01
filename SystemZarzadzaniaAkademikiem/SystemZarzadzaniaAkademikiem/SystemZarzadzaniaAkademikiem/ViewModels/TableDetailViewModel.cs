using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace SystemZarzadzaniaAkademikiem.ViewModels
{
    public class TableDetailViewModel
    {
        public string name;
        public TableDetailViewModel(string name)
        {
            this.name = name;
        }
        public Command DeleteRecordCommand
        {
            get
            {
                return new Command((id) =>
                {
                    App.Database.DatabaseNotAsync.Execute("DELETE FROM "+name+" WHERe Id="+id);

                });
            }
        }
    }
}

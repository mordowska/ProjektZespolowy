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
        //public Command DeleteRecordCommand;
        public TableDetailViewModel(string name)
        {
            this.name = name;
            //DeleteRecordCommand = new Command((id) => ExecuteDeleteRecordCommand());
        }
        public Command DeleteRecordCommand
        {
            get
            {
                return new Command((id) =>
                {
                    Debug.WriteLine(id);

                });
            }
        }
        /*void ExecuteDeleteRecordCommand()
        {
            Debug.WriteLine(id);
        }*/
    }
}

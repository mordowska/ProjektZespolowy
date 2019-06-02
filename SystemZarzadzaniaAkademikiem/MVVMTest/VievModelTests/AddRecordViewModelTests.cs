using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using SystemZarzadzaniaAkademikiem.ViewModels;

namespace MVVMTest.VievModelTests
{
    public class AddRecordViewModelTests
    {
        private AddRecordViewModel viewModel;

        [Test]
        public void test()
        {
            viewModel = new AddRecordViewModel("User");

        }
    }
}

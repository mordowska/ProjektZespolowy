using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;
using SystemZarzadzaniaAkademikiem.Models;
using SystemZarzadzaniaAkademikiem.ViewModels;
using System.Linq;
using SystemZarzadzaniaAkademikiem.Views;

namespace MVVMTest.VievModelTests
{
    public class UserViewModelTests
    {
        //private UserViewModel viewModel;
        //private User user = new User();
        //private List<string> list;

        //[SetUp]
        //public void Setup()
        //{
        //    InitializeUser();
        //    viewModel = new UserViewModel(user);
        //}

        //public void InitializeUser()
        //{
        //    list = new List<string>(new string[]
        //    { "Adam", "Nowak", "2312412",
        //      "male", "1", "UnderWindow",
        //      "23:00", "7:00", "Hot",
        //      "Loud", "Every Day", "Yes",
        //      "Biology", "Yes", "Rarely",
        //      "No", "Yes", "15", "1"});

        //    user = new User(list);
        //}

        //[Test]
        //public void test()
        //{
        //    bool result = true;
        //    FieldInfo[] temp = viewModel.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        //    for(int i=0; i< temp.Length; i++)
        //    {
        //        string check = (string)temp[i]?.GetValue(viewModel);
        //        if(!check.Equals(list[4+i]))
        //        {
        //            result = false;
        //        }
        //    }
        //    Assert.IsTrue(result);
        //    var actualList = temp.OfType<string>().ToList();
        //    CollectionAssert.IsSubsetOf(actualList, list);
        //}
    }
}

using NUnit.Framework;
using SystemZarzadzaniaAkademikiem.ViewModels;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            AdminLoginViewModel adminLoginViewModel = new AdminLoginViewModel();
            adminLoginViewModel.Login = "1234567890";
            Assert.AreEqual("1234567890", adminLoginViewModel.Login);
        }
    }
}
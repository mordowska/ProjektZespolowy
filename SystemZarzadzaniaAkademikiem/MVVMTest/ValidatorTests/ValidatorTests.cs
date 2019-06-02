using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using SystemZarzadzaniaAkademikiem.Validators;

namespace MVVMTest.ValidatorTests
{
    public class ValidatorTests
    {
        [Test]
        public void validateEmptyFieldfalseWhenStringNull()
        {
            string field = null;
            bool result = Validator.EmptyField(field);

            Assert.IsFalse(result);
        }

        [Test]
        public void validateEmptyFieldfalseWhenStringEmpty()
        {
            string field = "";
            bool result = Validator.EmptyField(field);

            Assert.IsFalse(result);
        }

        [Test]
        public void validateEmptyFieldTrueWhenStringNotEmpty()
        {
            string field = "Ala";
            bool result = Validator.EmptyField(field);

            Assert.IsTrue(result);
        }

        [Test]
        public void validateIndexValFalseWhenStartZero()
        {
            string index = "012312";
            bool result = Validator.IndexVal(index);

            Assert.IsFalse(result);
        }

        [Test]
        public void validateIndexValFalseWhenNotNumeric()
        {
            string index = "123a12";
            bool result = Validator.IndexVal(index);

            Assert.IsFalse(result);
        }

        [Test]
        public void validateIndexValFalseWhenLengthNotSix()
        {
            string index = "41231";
            bool result = Validator.IndexVal(index);

            Assert.IsFalse(result);
        }

        [Test]
        public void validateIndexValTrueWhenNumericalAndLengthIsSix()
        {
            string index = "301821";
            bool result = Validator.IndexVal(index);

            Assert.IsTrue(result);
        }

        [Test]
        public void validateLoginFalseWhenNull()
        {
            string login = null;
            bool result = Validator.ValidLogin(login);

            Assert.IsFalse(result);
        }

        [Test]
        public void validateLoginFalseWhenEmpty()
        {
            string login = "";
            bool result = Validator.ValidLogin(login);

            Assert.IsFalse(result);
        }

        [Test]
        public void validateLoginFalseWhenLengthLowerThanSix()
        {
            string login = "Kamil";
            bool result = Validator.ValidLogin(login);

            Assert.IsFalse(result);
        }

        [Test]
        public void validateLoginTrueWhenLengthGreaterThanFive()
        {
            string login = "Maciej";
            bool result = Validator.ValidLogin(login);

            Assert.IsTrue(result);
        }

        [Test]
        public void validatePasswordFalseWhenNull()
        {
            string password = null;
            bool result = Validator.ValidPassword(password);

            Assert.IsFalse(result);
        }

        [Test]
        public void validatePasswordFalseWhenEmpty()
        {
            string password = "";
            bool result = Validator.ValidPassword(password);

            Assert.IsFalse(result);
        }

        [Test]
        public void validatePasswordFalseWhenNotContainsDigit()
        {
            string password = "Pa$$word";
            bool result = Validator.ValidPassword(password);

            Assert.IsFalse(result);
        }

        [Test]
        public void validatePasswordFalseWhenNotContainsUpperCase()
        {
            string password = "pa$$w0rd";
            bool result = Validator.ValidPassword(password);

            Assert.IsFalse(result);
        }

        [Test]
        public void validatePasswordFalseWhenNotContainsLowerCase()
        {
            string password = "PA$$W0RD";
            bool result = Validator.ValidPassword(password);

            Assert.IsFalse(result);
        }

        [Test]
        public void validatePasswordFalseWhenNotContainsSymbol()
        {
            string password = "Pa55word";
            bool result = Validator.ValidPassword(password);

            Assert.IsFalse(result);
        }

        [Test]
        public void validatePasswordFalseWhenLengthLowerThanSix()
        {
            string password = "Pa$5w";
            bool result = Validator.ValidPassword(password);

            Assert.IsFalse(result);
        }

        [Test]
        public void validatePasswordTrueWhenHaveUpperLowerCasesDigitSymbol()
        {
            string password = "Pa$$w0rd";
            bool result = Validator.ValidPassword(password);

            Assert.IsFalse(result);
        }
    }
}

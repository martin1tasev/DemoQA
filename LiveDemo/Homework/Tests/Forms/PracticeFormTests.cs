using DemoQA.Factories;
using DemoQA.Models;
using DemoQA.Pages.PracticeForm;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace DemoQA.Tests.Forms
{
    [TestFixture]
    public class PracticeFormTests : BaseTest
    {
        private PracticeFormPage _practiceFormPage;
        private PracticeFormModel _user;

        [SetUp]
        public void Setup()
        {
            Initialize();
            Driver.Navigate("http://demoqa.com/automation-practice-form");
            _practiceFormPage = new PracticeFormPage(Driver);
            _user = PracticeFormFactory.Create();
        }

        [Test]
        public void ThanksMessageDisplayed_When_FillFormWithValidData()
        {
            _practiceFormPage.FillForm(_user);

            //Assert.AreEqual("Thanks for submitting the form", _practiceFormPage.Popup.Message.Text);
        }

        [Test]
        public void ErrorDisplayed_When_FillFormWithoutFirstName()
        {
            //Arange
            _user.FirstName = string.Empty;

            //Act
            _practiceFormPage.FillForm(_user);

            //Assert
            _practiceFormPage.AssertErrorBorderColor(_practiceFormPage.FirstName);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}

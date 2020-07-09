using DemoQA.Pages;
using DemoQA.Pages.HomePage;
using DemoQA.Utilities.Extensions;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace DemoQA.Tests
{
    public class NavigationTests : BaseTest
    {
        private HomePage _homePage;
        private DemoQAPage _demoQaPage;

        [SetUp]
        public void Setup()
        {
            Initialize();
            _homePage = new HomePage(Driver);
            _demoQaPage = new DemoQAPage(Driver);
            _homePage.NaviteTo();
        }

        [Test]
        [TestCase("Sortable")]
        [TestCase("Selectable")]
        [TestCase("Resizable")]
        [TestCase("Droppable")]
        [TestCase("Dragabble")]
        public void SuccessfullyPageLoaded_When_NavigateToSortable(string sectionName)
        {
            _homePage.CategotyButton("Interactions").Click();
            _demoQaPage.SubMenu(sectionName).Click();

            _demoQaPage.AssertPageTitle(sectionName);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}

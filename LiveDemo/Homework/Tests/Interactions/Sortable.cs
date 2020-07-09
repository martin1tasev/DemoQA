using DemoQA.Pages;
using DemoQA.Tests;
using DemoQA.Utilities.Extensions;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace DemoQA.Interactions
{
    [TestFixture]
    public class Sortable : BaseTest
    {
        private SortablePage _sortablePage;

        [SetUp]
        public void Setup()
        {
            Initialize();
            _sortablePage = new SortablePage(Driver);
            _sortablePage.NaviteTo();
        }

        [Test]
        public void OptionPlaceIsSwitch_When_DragAndDropUnderOtherOption()
        {
            //Arrange
            var index = 1;

            //Act
            Builder.DragAndDropToOffset(_sortablePage.ListOfOptions[index].WrappedElement, 0, 50).Perform();

            //Assert
            _sortablePage.AssertTextByIndex("T", index + 1);
        }

        [Test]
        public void OptionPlaceIsSwitch_When_DragAndDropOverOtherOption()
        {
            var index = 4;

            Builder.DragAndDropToOffset(_sortablePage.ListOfOptions[index].WrappedElement, 100, 50).Perform();

            _sortablePage.AssertTextByIndex("Five", index + 1);
        }

        [Test]
        public void AllOptionsAreOrdered_When_DragAndDropSingleOption()
        {
            Builder.DragAndDropToOffset(_sortablePage.ListOfOptions[4].WrappedElement, 100, 50).Perform();

            Assert.IsTrue(_sortablePage.ListOfOptions.All(o => o.Location.X == _sortablePage.Container.Location.X));
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                string dirPath = Path.GetFullPath(@"..\..\..\", Directory.GetCurrentDirectory());
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile($"{dirPath}\\Screenshots\\{TestContext.CurrentContext.Test.FullName}.png", ScreenshotImageFormat.Png);
            }

            Driver.Quit();
        }
    }
}

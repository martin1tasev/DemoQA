using DemoQA.Tests;
using DemoQA.Utilities.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using StabilizeTestsDemos.ThirdVersion;
using System.Runtime.InteropServices.ComTypes;

namespace DemoQA.Interactions
{
    [TestFixture]
    public class Resizable : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            Initialize();
            Driver.Navigate("http://demoqa.com/resizable");
        }

        [Test]
        public void ElementSizeIsMaximum_When_ResizeMoreThanMaximum()
        {
            var container = Driver.FindElement(By.ClassName("constraint-area"));
            var resizableBox = Driver.FindElement(By.Id("resizableBoxWithRestriction"));
            var resizeArrow = Driver.FindElement(By.XPath("//span[contains(@class, 'react-resizable-handle')]"));

            Builder.DragAndDropToOffset(resizeArrow.WrappedElement, 300, 100).Perform();

            Assert.AreEqual(container.Size.Height, resizableBox.Size.Height);
            Assert.AreEqual(container.Size.Width, resizableBox.Size.Width);
        }

        [Test]
        public void ElementSizeIsMinimum_When_ResizeToMinimum()
        {
            var resizableBox = Driver.FindElement(By.Id("resizableBoxWithRestriction"));
            var resizeArrow = Driver.FindElement(By.XPath("//span[contains(@class, 'react-resizable-handle')]"));

            Builder.DragAndDropToOffset(resizeArrow.WrappedElement, -50, -50).Perform();

            Assert.AreEqual(150, resizableBox.Size.Height);
            Assert.AreEqual(150, resizableBox.Size.Width);
        }

        [Test]
        public void ElementHaveCorrectSize_When_ResizeWithAnyNumber([Range(99, 100)] double x, [Range(99, 100)] double y)
        {
            var resizable = Driver.FindElement(By.Id("resizable"));
            var resizeArrow = Driver.FindElement(By.XPath("//*[@id='resizable']/span"));

            var heightBefore = resizable.Size.Height;
            var widthBefore = resizable.Size.Width;

            Builder.DragAndDropToOffset(resizeArrow.ScrollTo().WrappedElement, (int)x, (int)y).Perform();

            Assert.AreEqual(heightBefore + y, resizable.Size.Height);
            Assert.AreEqual(widthBefore + x, resizable.Size.Width);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}

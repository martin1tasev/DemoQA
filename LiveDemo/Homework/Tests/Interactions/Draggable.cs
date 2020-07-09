using DemoQA.Tests;
using NUnit.Framework;
using OpenQA.Selenium;

namespace DemoQA.Interactions
{
    [TestFixture]
    public class Draggable : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            Initialize();
            Driver.Navigate("http://demoqa.com/dragabble");
        }

        [Test]
        public void ElementYIsSame_When_DragAndDropOnlyXDiagonally()
        {
            var axisRestrictedTab = Driver.FindElement(By.Id("draggableExample-tab-axisRestriction"));
            axisRestrictedTab.Click();

            var onlyXBox = Driver.FindElement(By.Id("restrictedX"));
            var yBefore = onlyXBox.Location.Y;
            Builder.DragAndDropToOffset(onlyXBox.WrappedElement, 100, 100).Perform();
            var yAfter = onlyXBox.Location.Y;

            Assert.AreEqual(yBefore, yAfter);
        }

        [Test]
        public void ElementXIsSame_When_DragAndDropOnlyYDiagonally()
        {
            var axisRestrictedTab = Driver.FindElement(By.Id("draggableExample-tab-axisRestriction"));
            axisRestrictedTab.Click();

            var onlyYBox = Driver.FindElement(By.Id("restrictedY"));
            var xBefore = onlyYBox.Location.X;
            Builder.DragAndDropToOffset(onlyYBox.WrappedElement, 100, 100).Perform();
            var xAfter = onlyYBox.Location.X;

            Assert.AreEqual(xBefore, xAfter);
        }

        [Test]
        public void ElementStillInBox_When_DragAndDropOutOfBox()
        {
            var axisRestrictedTab = Driver.FindElement(By.Id("draggableExample-tab-containerRestriction"));
            axisRestrictedTab.Click();

            var container = Driver.FindElement(By.Id("containmentWrapper"));
            var draggable = Driver.FindElement(By.XPath("//div[@id='containmentWrapper']/div"));

            Builder.DragAndDropToOffset(draggable.WrappedElement, 0, container.Size.Height - 100).Perform();

            Assert.IsNotNull(container.FindElement(By.TagName("div")));
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}

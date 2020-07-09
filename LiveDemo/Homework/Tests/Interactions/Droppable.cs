using DemoQA.Pages.DroppablePage;
using DemoQA.Tests;
using DemoQA.Utilities.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace DemoQA.Interactions
{
    [TestFixture]
    public class Droppable : BaseTest
    {
        private DroppablePage _droppablePage;

        [SetUp]
        public void Setup()
        {
            Initialize();
            _droppablePage = new DroppablePage(Driver);
            _droppablePage.NaviteTo();
        }

        [Test]
        public void DropElementChangeColorOfTarget_When_DragAndDropDragMe()
        {
            var colorBefore = _droppablePage.DropHere.GetCssColor();

            Builder.DragAndDrop(_droppablePage.DragMe.WrappedElement, _droppablePage.DropHere.WrappedElement).Perform();

            Assert.AreNotEqual(colorBefore, _droppablePage.DropHere.GetCssColor());
        }

        [Test]
        public void TargetColorChanged_When_DragAcceptableElement()
        {
            var axisRestrictedTab = Driver.FindElement(By.Id("droppableExample-tab-accept"));
            axisRestrictedTab.Click();

            var acceptable = Driver.FindElement(By.Id("acceptable"));
            Builder.MoveToElement(acceptable.WrappedElement) .ClickAndHold()
                .MoveByOffset(1,1)
                .Perform();

            var classAfterAction = Driver.FindElement(By.Id("droppable")).GetAttribute("class");
            StringAssert.Contains("ui-droppable-active", classAfterAction);
        }

        [Test]
        public void TargetColorNotChanged_When_DragNotAcceptableElement()
        {
            var axisRestrictedTab = Driver.FindElement(By.Id("droppableExample-tab-accept"));
            axisRestrictedTab.Click();

            var notAcceptable = Driver.FindElement(By.Id("notAcceptable"));

            Builder.MoveToElement(notAcceptable.WrappedElement)
                .ClickAndHold()
                .MoveByOffset(1, 1)
                .Perform();

            var classAfterAction = Driver.FindElement(By.Id("droppable")).GetAttribute("class");
            StringAssert.DoesNotContain(classAfterAction, "ui-droppable-active");
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}

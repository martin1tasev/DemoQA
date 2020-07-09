using AutoFixture;
using AutoFixture.DataAnnotations;
using DemoQA.Tests;
using DemoQA.Utilities.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;

namespace DemoQA.Interactions
{
    [TestFixture]
    public class Selectable : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            Initialize();
            Driver.Navigate("http://demoqa.com/selectable");
        }

        [Test]
        public void SelectItemColorChange_When_SelectItem([Range(0, 3)] int index)
        {
            var list = Driver.FindElement(By.Id("verticalListContainer"));
            var listoptions = Driver.FindElements(By.XPath("//ul[@id='verticalListContainer']/li"));

            listoptions[index].Click();

            Assert.AreEqual("rgba(0, 123, 255, 1)", listoptions[index].GetCssColor());
        }

        [Test]
        public void AllItemsColorChanged_When_MoreThanIOneItem()
        {
            var list = Driver.FindElement(By.Id("verticalListContainer"));
            var listoptions = list.FindElements(By.TagName("li"));

            foreach (var option in listoptions)
            {
                option.Click();
            }

            Assert.IsTrue(listoptions.All(o => o.GetCssColor() == "rgba(0, 123, 255, 1)"));
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}

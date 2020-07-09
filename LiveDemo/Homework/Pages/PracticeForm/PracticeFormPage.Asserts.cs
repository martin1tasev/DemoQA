using DemoQA.Utilities.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using StabilizeTestsDemos.ThirdVersion;

namespace DemoQA.Pages.PracticeForm
{
    public partial class PracticeFormPage : BasePage
    {
        public void AssertErrorBorderColor(WebElement element)
        {
            this.WaitForLoad();
            Assert.AreEqual("rgb(209, 176, 184)", element.GetCssColor());
        }

        public void AssertSuccessBorderColor(WebElement element)
        {
            this.WaitForLoad();
            Assert.AreEqual("rgb(40, 167, 69);", element.GetCssColor());
        }
    }
}

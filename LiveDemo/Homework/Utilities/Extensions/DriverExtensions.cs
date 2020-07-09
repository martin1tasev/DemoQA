using OpenQA.Selenium;
using StabilizeTestsDemos.ThirdVersion;
using System.Threading;

namespace DemoQA.Utilities.Extensions
{
    public static class DriverExtensions
    {
        public static string GetCssColor(this WebElement element)
        {
            return element.WrappedElement.GetCssValue("background-color");
        }
    }
}

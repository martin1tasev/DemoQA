using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using StabilizeTestsDemos.ThirdVersion;
using System;
using System.Threading;

namespace DemoQA.Utilities.Extensions
{
    public static class ElementExtensions
    {
        public static WebElement ScrollTo(this WebElement element)
        {
            ((IJavaScriptExecutor)element.WrappedDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            return element;
        }

        public static WebElement ToBeVisible(this WebElement element)
        {
            var wait = new WebDriverWait(element.WrappedDriver, TimeSpan.FromSeconds(20));
            IWebElement nativeWebElement =
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element.By));

            return element;
        }

        public static void HighLight(this WebElement element)
        {
            var colorBefore = element.GetCssColor();
            ((IJavaScriptExecutor)element.WrappedDriver).ExecuteScript("arguments[0].style.backgroundColor = 'red';", element);
            Thread.Sleep(500);
            ((IJavaScriptExecutor)element.WrappedDriver).ExecuteScript($"arguments[0].style.backgroundColor = '{colorBefore}';", element);
        }
    }
}

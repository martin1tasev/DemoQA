using OpenQA.Selenium;
using StabilizeTestsDemos.ThirdVersion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoQA.Pages
{
    public partial class SortablePage
    {
        public List<WebElement> ListOfOptions => Driver.FindElements(By.XPath("//div[@id='demo-tabpane-list']//div[contains(@class, 'list-group-item')]")).ToList();

        public WebElement Container => Driver.FindElement(By.CssSelector("#demo-tabpane-list > div"));
    }
}

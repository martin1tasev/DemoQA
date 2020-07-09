using OpenQA.Selenium;
using StabilizeTestsDemos.ThirdVersion;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQA.Pages.DroppablePage
{
    public partial class DroppablePage : BasePage
    {
        public DroppablePage(WebDriver driver)
            : base(driver)
        {
        }

        public override string Url => "http://demoqa.com/droppable";
    }
}

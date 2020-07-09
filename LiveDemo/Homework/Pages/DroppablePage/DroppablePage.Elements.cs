using OpenQA.Selenium;
using StabilizeTestsDemos.ThirdVersion;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQA.Pages.DroppablePage
{
    public partial class DroppablePage
    {
        public WebElement DragMe => Driver.FindElement(By.Id("draggable"));

        public WebElement DropHere => Driver.FindElement(By.Id("droppable"));
    }
}

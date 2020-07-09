using OpenQA.Selenium;
using StabilizeTestsDemos.ThirdVersion;

namespace DemoQA.Pages
{
    public partial class SortablePage : DemoQAPage
    {
        public SortablePage(WebDriver driver) 
            : base(driver)
        {
        }

        public override string Url => "http://demoqa.com/sortable";
    }
}

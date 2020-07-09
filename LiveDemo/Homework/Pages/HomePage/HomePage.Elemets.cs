using OpenQA.Selenium;
using StabilizeTestsDemos.ThirdVersion;

namespace DemoQA.Pages.HomePage
{
    public partial class HomePage : BasePage
    {
        public WebElement CategotyButton(string categoryName) => 
            Driver.FindElement(By.XPath($"//*[normalize-space(text())='{categoryName}']/ancestor::div[contains(@class, 'top-card')]"));
    }
}

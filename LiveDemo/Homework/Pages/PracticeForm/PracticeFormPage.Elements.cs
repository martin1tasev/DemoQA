using OpenQA.Selenium;
using StabilizeTestsDemos.ThirdVersion;

namespace DemoQA.Pages.PracticeForm
{
    public partial class PracticeFormPage : BasePage
    {
        public PracticeFormSection Popup => new PracticeFormSection(Driver.WrappedDriver);

        public WebElement FirstName => Driver.FindElement(By.Id("firstName"));

        public WebElement LastName => Driver.FindElement(By.Id("lastName"));

        public WebElement Email => Driver.FindElement(By.Id("userEmail"));

        public WebElement PhoneNumber => Driver.FindElement(By.Id("userNumber"));

        public WebElement SportsCheckBox => Driver.FindElement(By.XPath("//*[@id='hobbiesWrapper']/div[2]/div[1]/label"));

        public WebElement Submit => Driver.FindElement(By.Id("submit"));

        public WebElement Gender(string labelText) =>
            Driver.FindElement(By.XPath($"//*[@id='genterWrapper']//label[text()='{labelText}']"));
    }
}

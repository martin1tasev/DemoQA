using DemoQA.Models;
using DemoQA.Utilities.Extensions;
using OpenQA.Selenium;
using StabilizeTestsDemos.ThirdVersion;

namespace DemoQA.Pages.PracticeForm
{
    public partial class PracticeFormPage : BasePage
    {
        public PracticeFormPage(WebDriver driver) 
            : base(driver)
        {
        }

        public override string Url => "http://demoqa.com/automation-practice-form";

        public void FillForm(PracticeFormModel user)
        {
            FirstName.SetText(user.FirstName);
            LastName.SetText(user.LastName);
            Email.SetText(user.Email);
            Gender(user.Gender).Click();
            PhoneNumber.SetText(user.PhoneNumber);

            Submit.ScrollTo().ToBeVisible().Click();
        }
    }
}

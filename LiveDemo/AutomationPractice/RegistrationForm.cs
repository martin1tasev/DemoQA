using AutoFixture;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace Homework
{
    [TestFixture]
    public class RegistrationForm
    {
        private object conflict;
        private ChromeDriver _driver;
        private WebDriverWait _wait;
        private RegistrationUser _user;
        private Fixture _fixture;

        [SetUp]
        public void CalssInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            _driver.Manage().Window.Maximize();

            _user = UserFactory.CreateValidUser();
            _fixture = new Fixture();
        }

        [Test]
        public void FillRegistrationFormWithModel()
        {
            _user.FirstName = "";
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=my-account");

            var emailInput = _driver.FindElement(By.Id("email_create"));
            emailInput.SendKeys(_user.FirstName);

            var createAccountButton = _driver.FindElement(By.Id("SubmitCreate"));
            createAccountButton.Click();

            var radioButtons = _wait.Until(d => d.FindElements(By.XPath("//div[@class='radio']//input")));
            radioButtons[(int)Gender.Male].Click();

            var firstName = _driver.FindElement(By.Id("customer_firstname"));
            firstName.SendKeys(_user.FirstName);

            var lastName = _driver.FindElement(By.Id("customer_lastname"));
            lastName.SendKeys("Batman");

            var password = _driver.FindElement(By.Id("passwd"));
            password.SendKeys("pass123456");

            var dateDD = _wait.Until(d => d.FindElement(By.Id("days")));
            SelectElement date = new SelectElement(dateDD);
            date.SelectByValue("3");

            var monthDD = _driver.FindElement(By.Id("months"));
            SelectElement months = new SelectElement(monthDD);
            months.SelectByValue("3");

            var yearDD = _driver.FindElement(By.Id("years"));
            SelectElement years = new SelectElement(yearDD);
            years.SelectByValue("2016");

            var realFirstName = _driver.FindElement(By.Id("firstname"));
            realFirstName.SendKeys("Ventsi");

            var realLastName = _driver.FindElement(By.Id("lastname"));
            realLastName.SendKeys("Batman");

            var address = _driver.FindElement(By.Id("address1"));
            address.SendKeys("Neshto");

            var city = _driver.FindElement(By.Id("city"));
            city.SendKeys("Sofia");

            var stateDD = _driver.FindElement(By.Id("id_state"));
            SelectElement state = new SelectElement(stateDD);
            state.SelectByText("Arizona");

            var postcode = _driver.FindElement(By.Id("postcode"));
            postcode.SendKeys("85001");

            var phone = _driver.FindElement(By.Id("phone_mobile"));
            phone.SendKeys("85001");

            var alias = _driver.FindElement(By.Id("alias"));
            Type(alias, "Home");

            var registerButton = _driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();
        }

        [Test]
        public void FillRegistrationFormOnlyInTest()
        {
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=my-account");

            var emailInput = _driver.FindElement(By.Id("email_create"));
            emailInput.SendKeys($"{_fixture.Create<string>()}@gmail.com");

            var createAccountButton = _driver.FindElement(By.Id("SubmitCreate"));
            createAccountButton.Click();

            var test = (int)Gender.Male;
            System.Threading.Thread.Sleep(2000);
            var radioButtons = _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@class='radio']//input")));
            radioButtons[test].Click();

            var firstName = _driver.FindElement(By.Id("customer_firstname"));
            firstName.SendKeys("Ventsi");

            var lastName = _driver.FindElement(By.Id("customer_lastname"));
            lastName.SendKeys("Batman");

            var password = _driver.FindElement(By.Id("passwd"));
            password.SendKeys("pass123456");

            var dateDD = _wait.Until(d => d.FindElement(By.Id("days")));
            SelectElement date = new SelectElement(dateDD);
            date.SelectByValue("3");

            var monthDD = _driver.FindElement(By.Id("months"));
            SelectElement months = new SelectElement(monthDD);
            months.SelectByValue("3");

            var yearDD = _driver.FindElement(By.Id("years"));
            SelectElement years = new SelectElement(yearDD);
            years.SelectByValue("2016");

            var realFirstName = _driver.FindElement(By.Id("firstname"));
            realFirstName.SendKeys("Ventsi");

            var realLastName = _driver.FindElement(By.Id("lastname"));
            realLastName.SendKeys("Batman");

            var address = _driver.FindElement(By.Id("address1"));
            address.SendKeys("Neshto");

            var city = _driver.FindElement(By.Id("city"));
            city.SendKeys("Sofia");

            var stateDD = _driver.FindElement(By.Id("id_state"));
            SelectElement state = new SelectElement(stateDD);
            state.SelectByText("Arizona");

            var postcode = _driver.FindElement(By.Id("postcode"));
            postcode.SendKeys("85001");

            var phone = _driver.FindElement(By.Id("phone_mobile"));
            phone.SendKeys("85001");

            var alias = _driver.FindElement(By.Id("alias"));
            Type(alias, "Home");

            var registerButton = _driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();
        }
























        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}

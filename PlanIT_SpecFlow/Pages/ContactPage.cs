using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanIT_SpecFlow.Pages
{
    public class ContactPage
    {
        private IWebDriver driver;
        public ContactPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement TxtForename => driver.FindElement(By.XPath("//input[@id='forename']"));
        IWebElement TxtEmail => driver.FindElement(By.XPath("//input[@id='email']"));
        IWebElement TxtMessage => driver.FindElement(By.XPath("//textarea[@id='message']"));
        IWebElement BtnSubmit => driver.FindElement(By.XPath("//a[contains(text(),'Submit')]"));
        public void EntertheFields(string Forename, string Email, string Message)
        {
            TxtForename.SendKeys(Forename);
            TxtEmail.SendKeys(Email);
            TxtMessage.SendKeys(Message);
        }
        public void clickSubmit()
        {
            BtnSubmit.Click();
        }
    }
}

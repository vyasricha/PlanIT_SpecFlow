using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanIT_SpecFlow.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        public HomePage(IWebDriver driver) 
        {
            this.driver = driver;
        }
        IWebElement MenuContact => driver.FindElement(By.XPath("//body/div[1]/div[1]/div[1]/div[1]/ul[1]/li[3]/a[1]"));
        IWebElement BtnStartShop => driver.FindElement(By.XPath("//a[contains(text(),'Start Shopping »')]"));
        public void gotocontactpage()
        {
            MenuContact.Click();
        }
        public void gotoshopping()
        {
            BtnStartShop.Click();
        }

    }
}

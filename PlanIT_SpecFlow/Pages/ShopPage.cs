using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanIT_SpecFlow.Pages
{
    public class ShopPage
    {
        private IWebDriver driver;
        public ShopPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement Menucart => driver.FindElement(By.XPath("//body/div[1]/div[1]/div[1]/div[1]/ul[2]/li[4]/a[1]"));
        public void AddItems()
        {
            string[] Items = { "Stuffed Frog", "Fluffy Bunny", "Valentine Bear" };
            int[] Quantity = { 2, 5, 3 };
            int j = 0;
            for(int l = 0; l < Quantity.Length; l++)
            {
                for (int i = 0; i < Quantity[j]; i++)
                {
                    driver.FindElement(By.XPath("//h4[contains(text(),'" + Items[j] + "')]/following::p//a[contains(text(),'Buy')]")).Click();
                }
                j++;                
            }
        }
        public void gotocart()
        {
            Menucart.Click();
        }
    }
}

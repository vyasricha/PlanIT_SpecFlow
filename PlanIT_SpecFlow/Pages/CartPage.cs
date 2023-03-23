using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanIT_SpecFlow.Pages
{
    public class CartPage
    {
        private IWebDriver driver;
        double[] ExpPrice = { 10.99, 9.99, 14.99 };
        int[] Quantity = { 2, 5, 3 };
        double Total = 0;
        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void verifyPrice()
        {
            //Verify the Price for the cart Items
            int j = 0;
            for (int i = 1; i <= ExpPrice.Length; i++)
            {
                IWebElement actualPrice = driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[2]"));
                Console.WriteLine("actualPrice:" + actualPrice.Text);
                string ExpectedPrice = "$" + ExpPrice[j];
                Console.WriteLine("ExpectedPrice:" + ExpectedPrice);
                Assert.AreEqual(ExpectedPrice, actualPrice.Text);
                j++;
            }
        }
        public void verifySubTotal()
        {
            //Verify the subTotle for the cart Items
            int k = 0;
            for (int i = 1; i <= ExpPrice.Length; i++)
            {
                double ExpSubTotal = ExpPrice[k] * Quantity[k];
                IWebElement actualSubTotal = driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[4]"));
                Console.WriteLine("actualSubTotal:" + actualSubTotal.Text);
                string ExpectedSubTotal = "$" + ExpSubTotal;
                Console.WriteLine("ExpectedSubTotal:" + ExpectedSubTotal);
                Assert.AreEqual(ExpectedSubTotal, actualSubTotal.Text);
                k++;
                Total = Total + ExpSubTotal;
            }
        }
        public void verifyTotal()
        {
            //verify the Total
            IWebElement actualTotal = driver.FindElement(By.XPath("//body[1]/div[2]/div[1]/form[1]/table[1]/tfoot[1]/tr[1]/td[1]/strong[1]"));
            Console.WriteLine("actualTotal:" + actualTotal.Text);
            string ExpectedTotal = "Total: " + Total;
            Console.WriteLine("ExpectedTotal:" + ExpectedTotal);
            Assert.AreEqual(ExpectedTotal, actualTotal.Text);
        }
    }
}

using OpenQA.Selenium;
using PlanIT_SpecFlow.Pages;
using System;
using TechTalk.SpecFlow;

namespace PlanIT_SpecFlow.StepDefinitions
{
    [Binding]
    public class ShoppingPageStepDefinitions
    {
        private IWebDriver driver;
        HomePage homePage;
        ShopPage shopPage;
        CartPage cartPage;

        //Create an Instance to use the driver
        public ShoppingPageStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Nevigate to shopping Page from Home Page")]
        public void GivenNevigateToShoppingPageFromHomePage()
        {
            homePage = new HomePage(driver);
            homePage.gotoshopping();
            Thread.Sleep(4000);
        }

        [When(@"I add some Items into cart with diffrent Quantity")]
        public void WhenIAddSomeItemsIntoCartWithDiffrentQuantity()
        {
            shopPage = new ShopPage(driver);
            shopPage.AddItems();
            Thread.Sleep(3000);
        }

        [When(@"I nevigate to Cart Page")]
        public void WhenINevigateToCartPage()
        {
            shopPage.gotocart();
            Thread.Sleep(3000);
        }

        [Then(@"Verify that Price, subTotal and Total are correct")]
        public void ThenVerifyThatPriceSubTotalAndTotalAreCorrect()
        {
            cartPage = new CartPage(driver);
            cartPage.verifyPrice();
            cartPage.verifySubTotal();
            cartPage.verifyTotal();
        }
    }
}

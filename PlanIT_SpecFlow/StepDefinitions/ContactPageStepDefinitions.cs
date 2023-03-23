using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PlanIT_SpecFlow.Pages;
using System;
using System.Security.Cryptography.X509Certificates;
using TechTalk.SpecFlow;

namespace PlanIT_SpecFlow.StepDefinitions
{
    [Binding]
    public class ContactPageStepDefinitions
    {
        private IWebDriver driver;
        HomePage homePage;
        ContactPage contactPage;

        //Create an Instance to use the driver
        public ContactPageStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }


        [Given(@"Nevigate to Contact Page from Home Page")]
        public void GivenNevigateToContactPageFromHomePage()
        {
            homePage = new HomePage(driver);
            homePage.gotocontactpage();
            Thread.Sleep(3000);
        }

        [When(@"I enter the mendatory fields like (.*), (.*), (.*)")]
        public void WhenIEnterTheMendatoryFieldsLikeRichaVyas_RichaGmail_ComIWantToKnow_(string Forename, string Email, string Message)
        {
            contactPage = new ContactPage(driver);
            contactPage.EntertheFields(Forename,Email,Message);
            Thread.Sleep(3000);
        }

        [When(@"I click on the Submit button")]
        public void WhenIClickOnTheSubmitButton()
        {
            contactPage = new ContactPage(driver);
            contactPage.clickSubmit();            
            Thread.Sleep(9000);
        }

        [Then(@"Proper submission message should be display for (.*)")]
        public void ThenProperSubmissionMessageShouldBeDisplayForRicha(string Forename)
        {
            string ExpectedMessage = "Thanks " + Forename + ", we appreciate your feedback.";
            string ActualMessage = driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]")).Text;
            Console.WriteLine("Actual:"+ ActualMessage);
            Assert.AreEqual(ExpectedMessage, ActualMessage);
        }

        [When(@"I keep all the mendatory fields empty")]
        public void WhenIKeepAllTheMendatoryFieldsEmpty()
        {
            //No action required
        }

        [When(@"Error message should display")]
        [Then(@"Error message should display")]
        public void ThenErrorMessageShouldDisplay()
        {
            string ActualForenameError = driver.FindElement(By.XPath("//span[@id='forename-err']")).Text;
            Console.WriteLine("ActualForenameError:" + ActualForenameError);
            string ActualEmailError = driver.FindElement(By.XPath("//span[@id='email-err']")).Text;
            Console.WriteLine("ActualEmailError:" + ActualEmailError);
            string ActualMessageError = driver.FindElement(By.XPath("//span[@id='message-err']")).Text;
            Console.WriteLine("ActualEmailError:" + ActualMessageError);
            Assert.Multiple(() =>
            {
                Assert.AreEqual("Forename is required", ActualForenameError);
                Assert.AreEqual("Email is required", ActualEmailError);
                Assert.AreEqual("Message is required", ActualMessageError);
            });
        }

    }
}

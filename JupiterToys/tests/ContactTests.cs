using JupiterToys.pageobjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JupiterToys.tests
{
    [TestClass]
    public class ContactTests : BaseTestSuite
    {
        [TestInitialize]
        public void PreTestSetup()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl("http://jupiter.cloud.planittesting.com");
        }
       
        [TestMethod]
        public void testMandatoryFieldErrorMessages()
        {
            HomePage homePage = new HomePage(driver);
            ContactPage contactPage = homePage.navigateContact();
            contactPage.clickSubmit();

            Assert.AreEqual("Forename is required", contactPage.getFirstNameError());
            Assert.AreEqual("Email is required", contactPage.getEmailError());
            Assert.AreEqual("Message is required", contactPage.getMessageError());

            contactPage.setFirstName("Testing");
            contactPage.setEmail("test@testing.com.au");
            contactPage.setMessage("Welcome to testing!");

            Assert.AreEqual("", contactPage.getFirstNameError());
            Assert.AreEqual("", contactPage.getEmailError());
            Assert.AreEqual("", contactPage.getMessageError());
        }


        [TestMethod]
        public void testInvalidFieldErrorMessages()
        {
            HomePage homePage = new HomePage(driver);
            ContactPage contactPage = homePage.navigateContact();
            
            contactPage.setTelephone("!@#$#$%");
            contactPage.setEmail("testing.com.au");
            
            Assert.AreEqual("Please enter a valid telephone number", contactPage.getTelephoneError());
            Assert.AreEqual("Please enter a valid email", contactPage.getEmailError());
        }

        [TestMethod]
        public void testContactIsSubmittedSuccessfully()
        {
            HomePage homePage = new HomePage(driver);
            ContactPage contactPage = homePage.navigateContact();

            contactPage.setFirstName("Dan");
            contactPage.setEmail("dan@jupiter.com");
            contactPage.setMessage("Welcome to testing!");
            contactPage.clickSubmit();

            Assert.AreEqual("Thanks Dan, we appreciate your feedback.", contactPage.getSuccessMessage());
            
        }

    }
}

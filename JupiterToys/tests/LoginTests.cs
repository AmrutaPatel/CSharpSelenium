using JupiterToys.pageobjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JupiterToys.tests
{
    [TestClass]
    public class LoginTests : BaseTestSuite
    {
        //[Test]
        //     [TestCategory("Smoke")]

        [TestInitialize]
        public void PreTestSetup()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl("http://jupiter.cloud.planittesting.com");
        }


        [TestMethod]
        public void testInvalidLogin(){
            HomePage homePage = new HomePage(driver);
            LoginPage loginPage = homePage.navigateLogin();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
            loginPage.setUsername("XXX");
            loginPage.setPassword("XXX");
            loginPage.clickLogin();
            //  Assert.That(driver.PageSource.Contains("Your login details are incorrect"), Is.EqualTo(true), "Invalid login message is not displayed.");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Your login details are incorrect", loginPage.getLoginError());
        }
        [TestMethod]
        public void testValidLogin() {
            HomePage homePage = new HomePage(driver);
            LoginPage loginPage = homePage.navigateLogin();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
            loginPage.setUsername("user1");
            loginPage.setPassword("letmein");
            loginPage.clickLogin();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
            // Assert.That(driver.PageSource.Contains(loginPage.getWelcomeMessage()), Is.EqualTo(true), "Invalid login message is not displayed.");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Welcome to Jupiter Toys, a magical world for good girls and boys.", loginPage.getWelcomeMessage());
        }

    }
}

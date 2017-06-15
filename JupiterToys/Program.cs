using JupiterToys.pageobjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToys
{
    class Program
    {
        IWebDriver driver = new ChromeDriver();
        static void Main(string[] args)
        {
                  
        }


        [SetUp]
        public void Init() {
            driver.Navigate().GoToUrl("http://jupiter.cloud.planittesting.com");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }


        [Test]
        public void Login() {
            HomePage homePage = new HomePage(driver);
            LoginPage loginPage = homePage.navigateLogin();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            loginPage.setUsername("XXX");
            loginPage.setPassword("XXX");
            loginPage.clickLogin();
            Assert.That(driver.PageSource.Contains("Your login details are incorrect"), Is.EqualTo(true), "Invalid login message is not displayed.");
            Console.WriteLine("Login Test");
           // Assert.assertEquals("Invalid login message is displayed.", "Your login details are incorrect", loginPage.getErrorMessage());



        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();   
        }

    }
}

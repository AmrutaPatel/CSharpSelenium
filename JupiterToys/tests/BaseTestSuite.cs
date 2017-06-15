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
    public abstract class BaseTestSuite
    { 
        protected static IWebDriver driver = new ChromeDriver();
         
        //[SetUp]
        [AssemblyInitialize]
        public static void Init(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext context){
           // driver.Navigate().GoToUrl("http://jupiter.cloud.planittesting.com");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        //[Test]
        //public void LoginTests() {
        //    LoginTests test = new LoginTests();
        //    test.testInvalidLogin();

        //}
        //[Test]
        //public void validLoginTests()
        //{
        //    LoginTests test = new LoginTests();
        //    test.testValidLogin();

        //}
        //[TearDown]
        [AssemblyCleanup]
        public static void CleanUp(){
            driver.Close();
        }
    }
}

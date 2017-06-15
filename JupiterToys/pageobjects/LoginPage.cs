using JupiterToys.supportlibrary;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToys.pageobjects
{
    class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "loginUserName")]
        IWebElement txtUsername { get; set; }

        [FindsBy(How = How.Id, Using = "loginPassword")]
        IWebElement txtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.btn.btn-primary")]
        IWebElement btnLogin { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.btn.btn-cancel")]
        IWebElement btnCancel { get; set; }

        [FindsBy(How = How.Id, Using = "login-error")]
        IWebElement errMessage { get; set; }

        [FindsBy(How = How.Id, Using = "nav-user")]
        IWebElement navigateUser { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div[2]/div/p[1]")]
        IWebElement msgWelcome { get; set; }

        public void setUsername(string username){
            SetControls.EnterText(txtUsername,username);
        }
        public void setPassword(string password){
            SetControls.EnterText(txtPassword, password);
        }
        public void clickLogin(){
            SetControls.Click(btnLogin);
        }
        public void clickCancel(){
            SetControls.Click(btnCancel);
        }
        public string getWelcomeMessage() {
           return GetControls.GetText(msgWelcome);
        }
        public string getLoginError() {
            return GetControls.GetText(errMessage);
        }

    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JupiterToys.supportlibrary;


namespace JupiterToys.pageobjects
{
    class ContactPage
    {
        IWebDriver driver;
        public ContactPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy( How=How.Id, Using = "forename")]
        IWebElement txtForename { get; set; }

        [FindsBy(How=How.Id, Using = "surname")]
        IWebElement txtSurname { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        IWebElement txtEmail { get; set; }

        [FindsBy(How = How.Id, Using = "telephone")]
        IWebElement txtTelephone { get; set; }
        
        [FindsBy(How = How.Id, Using = "message")]
        IWebElement txtMessage { get; set; }

       // @FindBy(css = "body > div.container-fluid > div > form > div > a")
        [FindsBy(How = How.LinkText, Using = "Submit")]
        IWebElement btnSubmit{ get; set; }

        [FindsBy(How = How.Id, Using = "forename-err")]
        IWebElement errForeName { get; set; }

        [FindsBy(How = How.Id, Using = "email-err")]
        IWebElement errEmail { get; set; }
        
        [FindsBy(How = How.Id, Using = "telephone-err")]
        IWebElement errTelephone { get; set; }

        [FindsBy(How = How.Id, Using = "message-err")]
        IWebElement errMessage { get; set; }
        
        [FindsBy(How = How.XPath, Using = "html/body/div[2]/div/a")]
        IWebElement btnGoBack { get; set; }

    
        [FindsBy(How = How.CssSelector, Using = ".alert-success")]
        IWebElement msgSuccess { get; set; }

        public String getFirstNameError()
        {
            return (elementExists(errForeName)) ?  GetControls.GetText(errForeName) : "";
        }
        public String getEmailError()
        {
            return (elementExists(errEmail)) ? GetControls.GetText(errEmail) : "";
        }
        public String getTelephoneError()
        {
            return (elementExists(errTelephone)) ? GetControls.GetText(errTelephone) : "";
        }
        public String getMessageError()
        {
            return (elementExists(errMessage)) ? GetControls.GetText(errMessage) : "";
        }
        public void setFirstName(String name)
        {
            SetControls.Clear(txtForename);
            SetControls.EnterText(txtForename, name);
        }
        public void setLastName(String name)
        {
           SetControls.Clear(txtSurname);
            SetControls.EnterText(txtSurname, name);
        }
        public void setEmail(String email)
        {
            SetControls.Clear(txtEmail);
            SetControls.EnterText(txtEmail, email);
        }
        public void setTelephone(String phone)
        {
            txtTelephone.Clear();
            SetControls.EnterText(txtTelephone, phone);
        }
        public void setMessage(String msg)
        {
            txtMessage.Clear();
            SetControls.EnterText(txtMessage, msg);
        }
        //    public void clickSubmit(){
        //        driver.manage().timeouts().implicitlyWait(3000, TimeUnit.MICROSECONDS);
        //        //   btnSubmit.click();
        //         driver.findElement(btnSubmit).click();
        //         driver.manage().timeouts().implicitlyWait(1000, TimeUnit.MICROSECONDS);
        //    }

        public IWebElement getSubmitElement()
        {
            return driver.FindElement(By.LinkText ("Submit"));
        }

        public void clickSubmit()
        {
            this.getSubmitElement().Click();
        //    SetControls.Click(btnGoBack);
        }

        public void clickGoBack()
        {
            SetControls.Click(btnGoBack);
        }

        public String getSuccessMessage()
        {
             (new WebDriverWait(driver, TimeSpan.FromSeconds(60)))
                    .Until(ExpectedConditions.ElementToBeClickable(msgSuccess));
            return GetControls.GetText(msgSuccess);
        }

        public bool elementExists(IWebElement ele)
        {
            try
            {
                if (ele.Displayed) { return true; }
                else { return false; }
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
            
        }
    }
}

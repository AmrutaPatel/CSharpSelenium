using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using JupiterToys.supportlibrary;

namespace JupiterToys.pageobjects
{
    class BasePage
    {
        //Protected: The type or member can only be accessed by code in the same class or struct, or in a derived class.
        protected static IWebDriver driver;
        public BasePage(IWebDriver driver){
           BasePage.driver = driver;
           PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "nav-home")]
        public IWebElement linkHome { get; set; }

        [FindsBy(How=How.Id, Using = "nav-shop")]
        public IWebElement linkShop { get; set; }

        [FindsBy(How = How.Id, Using = "nav-contact")]
        public IWebElement linkContact { get; set; }

        [FindsBy(How = How.Id, Using = "nav-login")]
        public IWebElement linkLogin { get; set; }

        [FindsBy(How = How.Id, Using = "nav-cart")]
        public IWebElement linkCart { get; set; }

        [FindsBy(How = How.Id, Using = "cart-count")]
        public IWebElement cartCount { get; set; }

        //navigate functions
        public HomePage navigateHome(){
            SetControls.Click(linkHome);
            return new HomePage(BasePage.driver);
        }

        //public ShopPage navigateShop()
        //{
        //    linkShop.click();
        //    return new ShopPage(BasePage.driver);
        //}

        public ContactPage navigateContact()
        {
            SetControls.Click(linkContact);
            return new ContactPage(BasePage.driver);
        }

        public LoginPage navigateLogin(){
            SetControls.Click(linkLogin);
            return new LoginPage(BasePage.driver);
        }

        //public CartPage navigateCart()
        //{
        //    linkCart.click();
        //    return new CartPage(BasePage.driver);
        //}

        //public int getCartCount()
        //{
        //    return Integer.parseInt(cartCount.getText());
        //}


    }
}

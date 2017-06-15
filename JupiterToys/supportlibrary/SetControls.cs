using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToys.supportlibrary
{
    public static class SetControls
    {
        public static void EnterText(this IWebElement element, string value) {
            element.SendKeys(value);
        }
        public static void Click(this IWebElement element) {
            element.Click();
        }
        public static void SelectDropDown(this IWebElement element, string value){
            new SelectElement(element).SelectByText(value);
        }
        public static void Clear(this IWebElement element){
            element.Clear();
        }
    }
}

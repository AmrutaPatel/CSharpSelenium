using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToys.supportlibrary
{
    public static class GetControls
    {
       public static string GetText(IWebElement element){
           // return element.GetAttribute("value");
            return element.Text;
        }

        public static string GetTextFromDDL(IWebElement element){
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }

    }
}

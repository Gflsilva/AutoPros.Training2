using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace AutoPros.Training
{
    class ExibeCombo
    {
        IWebDriver Browser;
        IWebElement element;
        string Campo;

        public ExibeCombo(string Campo, IWebDriver Browser)
        {
            this.Campo = Campo;
            this.Browser = Browser;
        }
        
        public void ExbirCombo()
        {
            element = Browser.FindElement(By.Id(Campo));
            ((IJavaScriptExecutor)Browser).
                ExecuteScript("arguments[0].setAttribute('style', 'visibility: visible;');", element);
        }
    }
}

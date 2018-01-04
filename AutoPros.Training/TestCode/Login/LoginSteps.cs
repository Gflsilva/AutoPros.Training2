using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace AutoPros.Training
{
    [Binding]
    public class LoginSteps
    {
        IWebDriver Browser;
        string URL = "http://h.prosimulador.com.br:9090/";
        string preenchercodigo = "12";
        string preencherlogin = "admin";
        string preenchersenha = "tecno@123";


        [BeforeScenario]
        public void Open()
        {
            this.Browser = new ChromeDriver();
        }

        [AfterScenario]
        public void Clouse()
        {
            this.Browser.Close();
            this.Browser.Dispose();
        }

        [Given(@"Acessar a HOME")]
        public void DadoAcessarAHOME()
        {
            Browser.Navigate().GoToUrl(URL);
        }

        [When(@"Preencher o campo codigo")]
        public void QuandoPreencherOCampoCodigo()
        {
            var codigo = this.Browser.FindElement(By.Id("codigo"));
            var login = this.Browser.FindElement(By.Id("username"));
            var senha = this.Browser.FindElement(By.Id("password"));

            codigo.SendKeys(preenchercodigo);
            login.SendKeys(preencherlogin);
            senha.SendKeys(preenchersenha);
        }

        [Then(@"Clicar no botao login")]
        public void EntaoClicarNoBotaoLogin()
        {
            var btnentrar = this.Browser.FindElement(By.Id("acesso"));
            btnentrar.Click();
            Thread.Sleep(4000);
        }
    }
}

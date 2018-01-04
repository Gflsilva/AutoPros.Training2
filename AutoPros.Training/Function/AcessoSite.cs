using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace AutoPros.Training
{
    class AcessoSite
    {
        IWebDriver Browser;

        string URL = "http://h.prosimulador.com.br:9090/";
        string preenchercodigo = "12";
        string preencherlogin = "admin";
        string preenchersenha = "tecno@123";

        public AcessoSite(IWebDriver Browser)
        {
            this.Browser = Browser;
        }

        public void EfetuaLigin()
        {
            Browser.Navigate().GoToUrl(URL);
            //Efetua login
            var Codigo = this.Browser.FindElement(By.Id("codigo"));
            var Login = this.Browser.FindElement(By.Id("username"));
            var Senha = this.Browser.FindElement(By.Id("password"));
            //
            Codigo.SendKeys(preenchercodigo);
            Login.SendKeys(preencherlogin);
            Senha.SendKeys(preenchersenha);
            //
            var BtnEntrar = this.Browser.FindElement(By.Id("acesso"));
            BtnEntrar.Click();
            Thread.Sleep(4000);

        }
    }
}

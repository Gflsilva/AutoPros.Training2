using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;


namespace AutoPros.Training
{
    [Binding]
    public class UnknownSteps
    {
        IWebDriver Browser;
        GeraCPF GeraCPF;
        ExibeCombo ExibeCombo;
        AcessoSite AcessoSite;
        int sleep = 2000;


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


        [Given(@"Acessar a tela cadastro aluno")]
        public void DadoAcessarATelaCadastroAluno()
        {
            AcessoSite = new AcessoSite(Browser);
            AcessoSite.EfetuaLigin();

            Thread.Sleep(sleep);
            var WaitDropDownCadastro = new WebDriverWait(Browser, TimeSpan.FromSeconds(10));
            WaitDropDownCadastro.Until(drv => drv.FindElement(By.Id("Cadastro")));
            var DropDownCadastro = Browser.FindElement(By.Id("Cadastro"));
            DropDownCadastro.Click();

            Thread.Sleep(sleep);
            new WebDriverWait(Browser, TimeSpan.FromSeconds(5)).
                Until(ExpectedConditions.ElementExists((By.LinkText("Aluno"))));
            var BtnAluno = Browser.FindElement(By.LinkText("Aluno"));
            BtnAluno.Click();

            Thread.Sleep(sleep);
            var WaitBtnNovoAluno = new WebDriverWait(Browser, TimeSpan.FromSeconds(10));
            WaitBtnNovoAluno.Until(drv => drv.FindElement(By.Id("novoAluno")));
            var BtnNovoAluno = Browser.FindElement(By.Id("novoAluno"));
            BtnNovoAluno.Click();
        }

        [When(@"Preencher os campos")]
        public void QuandoPreencherOsCampos()
        {
            var Campo = "";

            GeraCPF = new GeraCPF();


            var CPF = Browser.FindElement(By.Id("CPF"));
            CPF.SendKeys(GeraCPF.GerarCpf());
                        
            var DataNascimento = Browser.FindElement(By.Id("DataNascimento"));
            DataNascimento.SendKeys("13061994");

            var Nome = Browser.FindElement(By.Id("Nome"));
            Nome.SendKeys("Teste Automação");

            var Email = Browser.FindElement(By.Id("Email"));
            Email.SendKeys("gluna@prosimulador.com.br");

            var CEP = Browser.FindElement(By.Id("CEP"));
            CEP.SendKeys("04547-005");

            var Logradouro = Browser.FindElement(By.Id("Logradouro"));
            Logradouro.SendKeys("R. Gomes de Carvalho");

            var Numero = Browser.FindElement(By.Id("Numero"));
            Numero.SendKeys("1356");

            var Complemento = Browser.FindElement(By.Id("Complemento"));
            Complemento.SendKeys("N/D");

            var Bairro = Browser.FindElement(By.Id("Bairro"));
            Bairro.SendKeys("Vila Olimpia");

            var Telefone = Browser.FindElement(By.Id("Telefone"));
            Telefone.SendKeys("1111111111");

            var Celular = Browser.FindElement(By.Id("Celular"));
            Celular.SendKeys("11111111111");

            var DataHabilitacao = Browser.FindElement(By.Id("DataHabilitacao"));
            DataHabilitacao.SendKeys("04012018");

            var IsExcecaoDigital = Browser.FindElement(By.Id("IsExcecaoDigital"));
            IsExcecaoDigital.Click();


            Campo = "UF";
            ExibeCombo = new ExibeCombo(Campo, Browser);
            ExibeCombo.ExbirCombo();
            SelectElement DropDownUF = new SelectElement(Browser.FindElement(By.Id("UF")));
            DropDownUF.SelectByIndex(1);

            Campo = "IdMunicipio";
            ExibeCombo = new ExibeCombo(Campo, Browser);
            ExibeCombo.ExbirCombo();
            SelectElement DropDownMunicipio = new SelectElement(Browser.FindElement(By.Id("IdMunicipio")));
            DropDownMunicipio.SelectByIndex(1);

            Campo = "IdCategoriaHabilitacao";
            ExibeCombo = new ExibeCombo(Campo, Browser);
            ExibeCombo.ExbirCombo();
            SelectElement DropDownCategoriaHabilitacaoo = new SelectElement(Browser.FindElement(By.Id("IdCategoriaHabilitacao")));
            DropDownCategoriaHabilitacaoo.SelectByIndex(1);
        }

        [Then(@"Clicar em salvar")]
        public void EntaoClicarEmSalvar()
        {
            Thread.Sleep(sleep);
            var salvarAluno = Browser.FindElement(By.Id("salvarAluno"));
            salvarAluno.Click();

            Thread.Sleep(sleep);
            new WebDriverWait(Browser, TimeSpan.FromSeconds(5)).
                Until(ExpectedConditions.ElementExists((By.XPath("/html[1]/body[1]/div[7]/div[1]/div[1]/div[2]/button[2]"))));
            var Confirmar = Browser.FindElement(By.XPath("/html[1]/body[1]/div[7]/div[1]/div[1]/div[2]/button[2]"));
            Confirmar.Click();
        }
    }
}

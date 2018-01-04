using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
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

            var WaitDropDownCadastro = new WebDriverWait(Browser, TimeSpan.FromSeconds(10));
            WaitDropDownCadastro.Until(drv => drv.FindElement(By.Id("Cadastro")));
            var DropDownCadastro = Browser.FindElement(By.Id("Cadastro"));
            DropDownCadastro.Click();

            var WaitDropDownAluno = new WebDriverWait(Browser, TimeSpan.FromSeconds(10));
            WaitDropDownAluno.Until(drv => drv.FindElement(By.XPath("id(divCadastro)/ul[1]/li[1]/a[1]")));
            var BtnAluno = Browser.FindElement(By.XPath("id(divCadastro)/ul[1]/li[1]/a[1]"));
            BtnAluno.Click();

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
            CPF.Click();
                        
            var DataNascimento = Browser.FindElement(By.Id("DataNascimento"));
            DataNascimento.Click();
                        
            var Nome = Browser.FindElement(By.Id("Nome"));
            Nome.Click();
                        
            var Email = Browser.FindElement(By.Id("Email"));
            Email.Click();
                        
            var CEP = Browser.FindElement(By.Id("CEP"));
            CEP.Click();
                        
            var Logradouro = Browser.FindElement(By.Id("Logradouro"));
            Logradouro.Click();
                        
            var Numero = Browser.FindElement(By.Id("Numero"));
            Numero.Click();
                        
            var Complemento = Browser.FindElement(By.Id("Complemento"));
            Complemento.Click();
                        
            var Bairro = Browser.FindElement(By.Id("Bairro"));
            Bairro.Click();
                        
            var Telefone = Browser.FindElement(By.Id("Telefone"));
            Telefone.Click();
                        
            var Celular = Browser.FindElement(By.Id("Celular"));
            Celular.Click();
                        
            var DataHabilitacao = Browser.FindElement(By.Id("DataHabilitacao"));
            DataHabilitacao.Click();
                        
            var IsExcecaoDigital = Browser.FindElement(By.Id("IsExcecaoDigital"));
            IsExcecaoDigital.Click();


            Campo = Browser.FindElement(By.Id("IdCategoriaHabilitacao")).ToString();
            ExibeCombo = new ExibeCombo(Campo, Browser);
            ExibeCombo.ExbirCombo();
            SelectElement DropDownIdCategoriaHabilitacao = new SelectElement(Browser.FindElement(By.Id("IdCategoriaHabilitacao")));
            DropDownIdCategoriaHabilitacao.SelectByIndex(1);

            Campo = Browser.FindElement(By.Id("IdCategoriaHabilitacao")).ToString();
            ExibeCombo = new ExibeCombo(Campo, Browser);
            ExibeCombo.ExbirCombo();
            SelectElement DropDownUF = new SelectElement(Browser.FindElement(By.Id("UF")));
            DropDownUF.SelectByIndex(1);

            Campo = Browser.FindElement(By.Id("IdMunicipio")).ToString();
            ExibeCombo = new ExibeCombo(Campo, Browser);
            ExibeCombo.ExbirCombo();
            SelectElement DropDownIdMunicipio = new SelectElement(Browser.FindElement(By.Id("IdMunicipio")));
            DropDownIdMunicipio.SelectByIndex(1);
        }

        [Then(@"Clicar em salvar")]
        public void EntaoClicarEmSalvar()
        {
            var salvarAluno = Browser.FindElement(By.Id("salvarAluno"));
            salvarAluno.Click();

            var IsExcecaoDigital = Browser.FindElement(By.XPath("/html[1]/body[1]/div[7]/div[1]/div[1]/div[2]/button[2]"));
            IsExcecaoDigital.Click();

        }
    }
}

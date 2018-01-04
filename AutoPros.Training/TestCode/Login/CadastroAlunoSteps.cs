using System;
using TechTalk.SpecFlow;

namespace AutoPros.Training.TestCode.Login
{
    [Binding]
    public class CadastroAlunoSteps
    {
        [Given(@"Logar no site")]
        public void DadoLogarNoSite()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Acessar a Aluno")]
        public void EntaoAcessarAAluno()
        {
            ScenarioContext.Current.Pending();
        }
    }
}

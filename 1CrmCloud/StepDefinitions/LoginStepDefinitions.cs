using CRMCloud.Base;
using CRMCloud.Config;
using CRMCloud.Data;
using CRMCloud.Data.JsonDataTemplate;
using CRMCloud.Pages;
using OSDataHubUIProject.Pages;

namespace CRMCloud.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefinitions : BaseStep
    {
        /// <summary>
        /// Creating the mapping between the Gherkin steps and actual automation logic using SpecFlow via regular expression along with assertions
        /// </summary>
        private readonly ParallelConfig _parallelConfig;
        private readonly ScenarioContext _scenarioContext;
        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _parallelConfig = scenarioContext.ScenarioContainer.Resolve<ParallelConfig>();
            _scenarioContext = scenarioContext;
        }

        [Given(@"I log in to the 1CRMCould as a admin registered user")]
        public void GivenILogInToTheCRMCouldAsAAdminRegisteredUser()
        {
            _parallelConfig.Driver.Navigate().GoToUrl(Settings.AUT);
            _parallelConfig.CurrentPage = new CRMCloudLoginPage(_parallelConfig);
            EnterLoginCredentials();
            SuccessfulLoginToApplication();
        }

        private void EnterLoginCredentials()
        {
            JsonDataConfiguration _jsonDataConfiguration = new JsonDataConfiguration();
            var loginDetails = _jsonDataConfiguration.ConfigureJsonData<LoginCredentails>("LoginCredentails");
            _parallelConfig.CurrentPage.As<CRMCloudLoginPage>().EnterLoginCredentails(loginDetails.UserName, loginDetails.Password);
        }

        private void SuccessfulLoginToApplication()
        {
            _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<CRMCloudLoginPage>().SuccessfulLogin();
        }

        [Given(@"I navigated to ""([^""]*)"" under ""([^""]*)""")]
        public void GivenINavigatedToUnder(string subMenuLabelName, string MainMenuLabelName)
        {
            _parallelConfig.CurrentPage.As<HomeDashBoardPage>().ClickMainMenuLabel(MainMenuLabelName);
            _parallelConfig.CurrentPage.As<HomeDashBoardPage>().ClickSubMenuLabel(subMenuLabelName);
        }

        [When(@"I enter new contact details")]
        public void WhenIEnterNewContactDetails()
        {
            //throw new PendingStepException();
        }

        [When(@"I save the contact details")]
        public void WhenISaveTheContactDetails()
        {
           // throw new PendingStepException();
        }

        [Then(@"I recieved contact created confirmation")]
        public void ThenIRecievedContactCreatedConfirmation()
        {
            //throw new PendingStepException();
        }

        [Then(@"I verify the contact details")]
        public void ThenIVerifyTheContactDetails()
        {
            //throw new PendingStepException();
        }

    }
}
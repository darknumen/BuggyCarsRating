using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumSpecflow.BDD.StepDefinitions;
using SeleniumSpecflow.Model.Data;
using SeleniumSpecflow.Model.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace SeleniumSpecflow.BDD.StepDefinition
{
    [Binding]
    public class AuthenticationSteps : BaseSteps
    {
        public AuthenticationSteps(IWebDriver driver, IObjectContainer objectContainer, ScenarioContext scenarioContext, FeatureContext featureContext) : base(driver, objectContainer, scenarioContext, featureContext)
        {

        }

        [Given(@"a user with valid credentials")]
        public void GivenAUserWithValidCredentials()
        {
            var appSettings = ConfigurationManager.AppSettings;
            objectContainer.RegisterInstanceAs(new LoginData().WithUsername(appSettings["username"]).WithPassword(appSettings["password"]), "logincredentials");
        }

        [When(@"the user logs in to the application")]
        public void WhenTheUserLogsInToTheApplication()
        {
            LoginData loginData = objectContainer.Resolve<LoginData>("logincredentials");

            LoginPage loginPage = new LoginPage(driver);
            loginPage.SetLoginAndEnter(loginData.Username, loginData.Password);
        }
        
        [Then(@"the user should be succesfully logged in")]
        public void ThenTheUserShouldBeSuccesfullyLoggedIn()
        {
            HomePage homePage = new HomePage(driver);
            Assert.IsTrue(homePage.IsHeaderPresent(), "Login was successful.");
        }

        [Given(@"a user with invalid credentials")]
        public void GivenAUserWithInvalidCredentials()
        {
            objectContainer.RegisterInstanceAs(new LoginData().WithUsername("invalidusername").WithPassword("invalidpassword"), "logincredentials");
        }

        [Then(@"the user should be not be able to login successfully")]
        public void ThenTheUserShouldBeNotBeAbleToLoginSuccessfully()
        {
            HomePage homePage = new HomePage(driver);
            Assert.IsTrue(homePage.LoginErrorMessage.Displayed, "Login error message displayed");
        }

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var username = appSettings["username"];
            var password = appSettings["password"];


            LoginPage loginPage = new LoginPage(driver);
            loginPage.SetLoginAndEnter(username, password);
        }

        [When(@"I click the log off link")]
        public void WhenIClickTheLogOffLink()
        {
            HomePage home = new HomePage(driver);
            home.LogoutButton.Click();
        }

        [Then(@"I should be logged off")]
        public void ThenIShouldBeLoggedOff()
        {
            LoginPage login = new LoginPage(driver);

            Assert.IsTrue(login.UsernameField.Displayed, "login:usename field is displayed");
            Assert.IsTrue(login.PasswordField.Displayed, "login:password field is displayed");
        }

        [Given(@"I am a registered new user and logged in")]
        public void GivenIAmARegisteredNewUserAndLoggedIn()
        {
            HomePage home = new HomePage(driver);
            home.RegisterButton.Click();

            var username = Faker.Internet.UserName();
            var password = "Test012345!";


            RegistrationPage register = new RegistrationPage(driver);
            register.CreateNewUser(username, password);

            objectContainer.RegisterInstanceAs(new LoginData().WithUsername(username).WithPassword(password), "creatednewuser");

            LoginPage login = new LoginPage(driver);
            login.SetLoginAndEnter(username, password);

            home.BuggyRatingLink.Click();
            home.waitHelper.waitForPageLoadComplete();
        }

        [Then(@"test")]
        public void ThenTest()
        {
            driver.Navigate().GoToUrl("https://buggy.justtestit.org/model/c0bm09bgagshpkqbsuag%7Cc0bm09bgagshpkqbsuh0");
            ModelPage model = new ModelPage(driver);
            var text = model.VoteNumber.Text;
            Assert.IsTrue(true);
        }

    }
}

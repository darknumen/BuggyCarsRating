using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumSpecflow.BDD.StepDefinitions;
using SeleniumSpecflow.Model.Data;
using SeleniumSpecflow.Model.Pages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumSpecflow.BDD.StepDefinition
{
    [Binding]
    public class SiteFunctionalitySteps : BaseSteps
    {
        public SiteFunctionalitySteps(IWebDriver driver, IObjectContainer objectContainer, ScenarioContext scenarioContext, FeatureContext featureContext) : base(driver, objectContainer, scenarioContext, featureContext)
        {

        }

        [When(@"I update my profile and password")]
        public void WhenIUpdateMyProfileAndPassword()
        {
            HomePage home = new HomePage(driver);
            home.ProfileButton.Click();

            ProfilePage profile = new ProfilePage(driver);
            ProfileData data = new ProfileData();

            var login = objectContainer.Resolve<LoginData>("creatednewuser");

            var newpassword = "Test01234567!";
            data = profile.UpdateProfileRandom(login.Password, newpassword);

            Assert.IsTrue(profile.ProfileSaveSuccessMessage.Displayed, "save successfully displayed");

            objectContainer.RegisterInstanceAs(new LoginData().WithUsername(login.Username).WithPassword(newpassword), "updatednewuser");
            objectContainer.RegisterInstanceAs<ProfileData>(data, "profiledata");
        }

        [Then(@"I login using new password and verify profile change was saved")]
        public void ThenILoginUsingNewPasswordAndVerifyProfileChangeWasSaved()
        {
            HomePage home = new HomePage(driver);
            home.LogoutButton.Click();

            var credentials = objectContainer.Resolve<LoginData>("updatednewuser");

            LoginPage login = new LoginPage(driver);
            login.SetLoginAndEnter(credentials.Username, credentials.Password);

            home.ProfileButton.Click();

            var profilesaved = objectContainer.Resolve<ProfileData>("profiledata");

            ProfilePage profilepage = new ProfilePage(driver);
            var profilecurrent = profilepage.GetCurrentProfileInformation();

            Assert.IsTrue(profilesaved.Equals(profilecurrent), "Saved profile and current profile should be the same");
        }

        [When(@"I navigate to the most popular model")]
        public void WhenINavigateToTheMostPopularModel()
        {
            HomePage home = new HomePage(driver);
            home.PopularModelLink.Click();
            home.waitHelper.waitForPageLoadComplete();
        }
        
        [When(@"I made a comment to vote")]
        public void WhenIMadeACommentToVote()
        {
            ModelPage model = new ModelPage(driver);
            scenarioContext.Set(model.VoteNumber.Text, "votecount");

            model.CommentField.SendKeys(Faker.Company.CatchPhrase());
            model.VoteButton.Click();
            model.waitHelper.WaitForJQueryToBeInactive();
        }
        
        [Then(@"check that vote was counted and comment could not be made anymore")]
        public void ThenCheckThatVoteWasCountedAndCommentCouldNotBeMadeAnymore()
        {
            ModelPage model = new ModelPage(driver);
            Assert.AreEqual(model.VoteMessageDone.Text, "Thank you for your vote!", "Vote has been registered");

            var voteafter = int.Parse(model.VoteNumber.Text);
            var votebefore = int.Parse(scenarioContext.Get<string>("votecount"));

            Assert.AreEqual(voteafter, votebefore + 1, "Added vote should be counted");
        }
    }
}

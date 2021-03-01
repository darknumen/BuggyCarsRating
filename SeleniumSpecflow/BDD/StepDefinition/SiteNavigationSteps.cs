using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumSpecflow.BDD.StepDefinitions;
using SeleniumSpecflow.Model.Pages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumSpecflow.BDD.StepDefinition
{
    [Binding]
    public class SiteNavigationSteps : BaseSteps
    {
        public SiteNavigationSteps(IWebDriver driver, IObjectContainer objectContainer, ScenarioContext scenarioContext, FeatureContext featureContext) : base(driver, objectContainer, scenarioContext, featureContext)
        {

        }

        [Then(@"I navigate to Popular Model then confirm model page and back to main page successfully")]
        public void ThenINavigateToPopularModelThenConfirmModelPageAndBackToMainPageSuccessfully()
        {
            HomePage home = new HomePage(driver);

            var popularmodel = home.PopularModelName.Text;
            home.PopularModelLink.Click();

            ModelPage model = new ModelPage(driver);
            Assert.IsTrue(popularmodel.Contains(model.ModelName.Text), "page navigated to correct model");

            model.BuggyRatingLink.Click();
            Assert.AreEqual("https://buggy.justtestit.org/", driver.Url, "Expected to be back on the main page");
        }

        [Then(@"I navigate to Overall Rating then confirm overall page and back to main page succesfully")]
        public void ThenINavigateToOverallRatingThenConfirmOverallPageAndBackToMainPageSuccesfully()
        {
            HomePage home = new HomePage(driver);

            home.OverallLink.Click();
            Assert.AreEqual("https://buggy.justtestit.org/overall", driver.Url, "Expected to be on the overall page");

            home.BuggyRatingLink.Click();
            Assert.AreEqual("https://buggy.justtestit.org/", driver.Url, "Expected to be back on the main page");
        }
    }
}

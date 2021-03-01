using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SeleniumSpecflow.BDD.StepDefinitions
{
    public abstract class BaseSteps
    {
        protected readonly IWebDriver driver;
        protected IObjectContainer objectContainer;
        protected readonly ScenarioContext scenarioContext;
        protected readonly FeatureContext featureContext;

        protected BaseSteps(IWebDriver driver, IObjectContainer objectContainer, ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            this.driver = driver;
            this.objectContainer = objectContainer;
            this.scenarioContext = scenarioContext;
            this.featureContext = featureContext;
        }
    }
}
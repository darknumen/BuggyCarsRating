using OpenQA.Selenium;

namespace SeleniumSpecflow.Driver
{
    public interface IDriverFactory
    {
        IWebDriver GetDriver();

        DriverOptions GetOptions();

        IDriverFactory SetHeadless(bool isHeadless);
    }
}

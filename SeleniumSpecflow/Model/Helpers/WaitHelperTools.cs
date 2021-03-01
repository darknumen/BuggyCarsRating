using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using SELENIUM_EXTRAS = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumSpecflow.Model.Helpers
{
    public class WaitHelperTools
    {
        private WebDriverWait _waitHelper;
        private IWebDriver _driver;

        public WaitHelperTools(IWebDriver driver)
        {
            _waitHelper = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            _driver = driver;
        }

        public WaitHelperTools(IWebDriver driver, double timeSpan)
        {
            _waitHelper = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpan));
            _driver = driver;
        }

        public void WaitForElementClickable(By locator)
        {
            _waitHelper.Until(SELENIUM_EXTRAS.ElementToBeClickable(locator));
        }
        public void WaitForElementClickable(IWebElement element)
        {
            _waitHelper.Until(SELENIUM_EXTRAS.ElementToBeClickable(element));
        }
        public void WaitForElementExists(By locator)
        {
            _waitHelper.Until(SELENIUM_EXTRAS.ElementExists(locator));
        }
        public void WaitForElementVisible(By locator)
        {
            _waitHelper.Until(SELENIUM_EXTRAS.ElementIsVisible(locator));
        }
        public void WaitForElementSelected(IWebElement element)
        {
            _waitHelper.Until(SELENIUM_EXTRAS.ElementToBeSelected(element));
        }
        public void WaitForElementSelected(By locator)
        {
            _waitHelper.Until(SELENIUM_EXTRAS.ElementToBeSelected(locator));
        }
        public void WaitUntilUrlContains(string fraction)
        {
            _waitHelper.Until(SELENIUM_EXTRAS.UrlContains(fraction));
        }

        /* Wait for background page task to finish -- JQuery running */
        public void WaitForJQueryToBeInactive()
        {

            Boolean isJqueryUsed = (Boolean)((IJavaScriptExecutor)_driver).ExecuteScript("return (typeof(jQuery) != 'undefined')");

            if (isJqueryUsed)
            {
                while (true)
                {
                    Boolean ajaxIsComplete = (Boolean)(((IJavaScriptExecutor)_driver).ExecuteScript("return jQuery.active == 0"));
                    if (ajaxIsComplete)
                        break;
                    try
                    {
                        Thread.Sleep(100);
                    }
                    catch (ThreadInterruptedException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        /* Wait for the Page to be loaded after a 'Processing' action - DOM */
        public void waitForPageLoadComplete()
        {
            _waitHelper.Until(_driver => ((IJavaScriptExecutor)_driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}

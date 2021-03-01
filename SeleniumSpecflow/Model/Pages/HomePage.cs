using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace SeleniumSpecflow.Model.Pages
{
    public class HomePage : BasePage
    {
        public IWebElement HeaderLogin => driver.FindElement(By.XPath("//span[contains(text(),'Hi')]"));
        public IWebElement LoginErrorMessage => driver.FindElement(By.XPath("//span[contains(text(), 'Invalid username/password')]"));
        public IWebElement RegisterButton => driver.FindElement(By.XPath("//a[@class='btn btn-success-outline'][text()='Register']"));
        public IWebElement LogoutButton => driver.FindElement(By.XPath("//a[@class='nav-link'][text()='Logout']"));
        public IWebElement ProfileButton => driver.FindElement(By.XPath("//a[@class='nav-link'][text()='Profile']"));
        public IWebElement PopularModelLink => driver.FindElement(By.XPath("//a[contains(@href,'/model/')]"));
        public IWebElement PopularModelName => driver.FindElement(By.CssSelector("div:nth-child(2) > div > div > h3"));
        public IWebElement PopularMakeLink => driver.FindElement(By.XPath("//a[contains(@href,'/make/')]"));
        public IWebElement OverallLink => driver.FindElement(By.XPath("//a[contains(@href,'/overall')]"));


        public HomePage(IWebDriver driver) : base(driver)
        { 
        
        }

        public bool IsHeaderPresent()
        {
            try
            {
                return HeaderLogin.Displayed;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}

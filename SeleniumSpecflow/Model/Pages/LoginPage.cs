using OpenQA.Selenium;
using SeleniumSpecflow.Model.Helpers;

namespace SeleniumSpecflow.Model.Pages
{
    public class LoginPage : BasePage
    {
        public IWebElement UsernameField => driver.FindElement(By.Name("login"));
        public IWebElement PasswordField => driver.FindElement(By.Name("password"));
        public IWebElement SubmitButton => driver.FindElement(By.XPath("//button[@type='submit'][text()='Login']"));


        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public void SetLoginAndEnter(string user, string password)
        {
            waitHelper.WaitForElementClickable(UsernameField);
            UsernameField.SendKeys(user);

            waitHelper.WaitForElementClickable(UsernameField);
            PasswordField.SendKeys(password);

            SubmitButton.Click();
        }
    }
}

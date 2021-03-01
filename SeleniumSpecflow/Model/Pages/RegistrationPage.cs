using OpenQA.Selenium;


namespace SeleniumSpecflow.Model.Pages
{
    class RegistrationPage : BasePage
    {
        public IWebElement LoginField => driver.FindElement(By.Id("username"));
        public IWebElement FirstNameField => driver.FindElement(By.Id("firstName"));
        public IWebElement LastNameField => driver.FindElement(By.Id("lastName"));
        public IWebElement PasswordField => driver.FindElement(By.Id("password"));
        public IWebElement ConfirmPasswordField => driver.FindElement(By.Id("confirmPassword"));
        public By Register => By.XPath("//button[@type='submit'][text()='Register']");
        public IWebElement RegisterButton => driver.FindElement(Register);
        public IWebElement RegistrationSuccessMessage => driver.FindElement(By.XPath("//div[contains(text(),'Registration is successful')]"));

        public RegistrationPage(IWebDriver driver) : base(driver)
        { 
        
        }

        public void CreateNewUser(string user, string password)
        {
            LoginField.SendKeys(user);
            FirstNameField.SendKeys(Faker.Name.First());
            LastNameField.SendKeys(Faker.Name.Last());
            PasswordField.SendKeys(password);
            ConfirmPasswordField.SendKeys(password);

            waitHelper.WaitForElementClickable(Register);
            RegisterButton.Click();
        }
    }
}

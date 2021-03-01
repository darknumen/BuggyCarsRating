using OpenQA.Selenium;


namespace SeleniumSpecflow.Model.Pages
{
    class ModelPage : BasePage
    {
        public IWebElement CommentField => driver.FindElement(By.Id("comment"));
        public IWebElement VoteNumber => driver.FindElement(By.CssSelector("div:nth-child(1) > h4 > strong"));
        public IWebElement VoteButton => driver.FindElement(By.XPath("//button[@class='btn btn-success'][text()='Vote!']"));
        public IWebElement VoteMessageDone => driver.FindElement(By.XPath("//p[@class='card-text']"));
        public IWebElement ModelName => driver.FindElement(By.CssSelector("div:nth-child(2) > h3"));


        public ModelPage(IWebDriver driver) : base(driver)
        { 
        
        }

    }
}

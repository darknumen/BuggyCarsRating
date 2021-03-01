using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

namespace SeleniumSpecflow.Model.Helpers
{
    public class ScreenshotHelper
    {
        private readonly IWebDriver driver;

        public ScreenshotHelper(IWebDriver _driver)
        {
            this.driver = _driver;
        }        

        public void SnapFullScreenshot(string featureTitle, string scenarioTitle)
        {
            try
            {
                VerticalCombineDecorator vcd = new VerticalCombineDecorator(new ScreenshotMaker());
                string ssPath = Path.Combine(Directory.GetCurrentDirectory(), featureTitle.Replace(" ", "_") + "_" + scenarioTitle.Replace(" ", "_") + "_" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + "_fullPage.png");                
                driver.TakeScreenshot(vcd).ToMagickImage().ToBitmap().Save(ssPath);               
                Console.WriteLine($"SCREENSHOTXX file:///{ssPath} XXSCREENSHOT"); // This is so a link to the screenshot appears in the report
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}

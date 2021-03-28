using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Registry_Automated_Test.PageObject
{
    class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        public override string PageUrl { get => "https://mvc-app-node-express.nakov.repl.co/"; }

        //"body > p > b"
        public IWebElement ElementStudentsCount =>
            driver.FindElement(By.CssSelector("body > p > b"));

        public int GetStudentsCount()
        {
            string studentsCountText = this.ElementStudentsCount.Text;
            return int.Parse(studentsCountText);
        }
    }
}

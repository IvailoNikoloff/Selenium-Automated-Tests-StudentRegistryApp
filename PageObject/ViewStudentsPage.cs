using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Student_Registry_Automated_Test.PageObject
{
    class ViewStudentsPage : BasePage
    {
        public ViewStudentsPage(IWebDriver driver) : base(driver)
        {

        }

        public override string PageUrl
        { get => "https://mvc-app-node-express.nakov.repl.co/students"; }

        public ReadOnlyCollection <IWebElement> ListItemsStudents =>
            driver.FindElements(By.CssSelector("body > ul > li"));

        public string[] GetRegisteredStudents()
        {
            var elementStudents = this.ListItemsStudents.Select(s => s.Text).ToArray();
            return elementStudents;
        }


    }
}

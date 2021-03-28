using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Registry_Automated_Test.PageObject
{
    class AddStudentPage : BasePage
    {
        public AddStudentPage(IWebDriver driver) : base(driver)
        {

        }

        public override string PageUrl 
        { get => "https://mvc-app-node-express.nakov.repl.co/add-student"; }

        public IWebElement FieldName =>
            driver.FindElement(By.Id("name"));

        public IWebElement FieldEmail =>
            driver.FindElement(By.Id("email"));

        public IWebElement ButtonSubmit =>
            driver.FindElement(By.CssSelector("body > form > button"));

        public IWebElement ElementErrorMsg =>
            driver.FindElement(By.XPath("//div[contains(@style,'background:red')]"));

        public void AddStudent(string name, string email)
        {
            this.FieldName.SendKeys(name);
            this.FieldEmail.SendKeys(email);
            this.ButtonSubmit.Click();
    }
    }    
}


using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Student_Registry_Automated_Test.PageObject;

namespace Student_Registry_Automated_Test.Tests
{
    public class TestsHomePage : BaseTest
    {     

        [Test]
        public void Test_HomePage_Content()
        {
            var page = new HomePage(driver);
            page.Open();
            Assert.AreEqual("MVC Example", page.GetPageTitle());
            Assert.AreEqual("Students Registry", page.GetPageHeadingText());
            page.GetStudentsCount();
            Assert.Pass();
        }

        [Test]
        public void Test_HomePage_Links()
        {
            var page = new HomePage(driver);

            page.Open();
            page.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            page.Open();
            page.LinkAddStudentPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());

            page.Open();
            page.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());

        }


    }
}
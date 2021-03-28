using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Student_Registry_Automated_Test.PageObject;
using System;

namespace Student_Registry_Automated_Test.Tests
{
    public class TestsAddStudentPage : BaseTest
    {      

        [Test]
        public void Test_AddStudentPage_Content()
        {
            var page = new AddStudentPage(driver);
            page.Open();
            Assert.AreEqual("Add Student", page.GetPageTitle());
            Assert.AreEqual("Register New Student", page.GetPageHeadingText());
            Assert.AreEqual("", page.FieldName.Text);
            Assert.AreEqual("Add", page.ButtonSubmit.Text);
        }

        [Test]
        public void Test_AddStudentPage_Links()
        {
            var addStudentPage = new AddStudentPage(driver);

            addStudentPage.Open();
            addStudentPage.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            addStudentPage.Open();
            addStudentPage.LinkAddStudentPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());

            addStudentPage.Open();
            addStudentPage.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());

        }

        [Test]
        public void Test_AddStudentPage_AddValidStudent()
        {
            var page = new AddStudentPage(driver);
            page.Open();
            string name = "Pesho" + DateTime.Now.Ticks;
            string email = "Pesho" + DateTime.Now.Ticks + "@gmail.com";
            page.AddStudent(name, email);
            var viewStudentsPage = new ViewStudentsPage(driver);

            Assert.That(viewStudentsPage.IsOpen);

            var students = viewStudentsPage.GetRegisteredStudents();
            string newStudent = name + " (" + email + ")";
            Assert.Contains(newStudent, students);
        }

        [Test]
        public void Test_AddStudentPage_AddInvalidStudent()
        {
            var page = new AddStudentPage(driver);
            page.Open();
            string name = "";
            string email = "Pesho" + DateTime.Now.Ticks + "@gmail.com";
            page.AddStudent(name, email);
          

            Assert.IsTrue(page.IsOpen());
            Assert.IsTrue(page.ElementErrorMsg.Text.Contains
                ("Cannot add student. Name and email fields are required!"));
        }
    }
}
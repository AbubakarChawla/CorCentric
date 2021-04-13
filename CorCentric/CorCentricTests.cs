using CorCentric.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CorCentric
{
    public class CorCentricTests
    {
        IWebDriver driver;
        Homepage homePage;
        Forms forms;
        PracticeForm practiceForm;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            homePage = new Homepage(driver);
            homePage.OpenPage();
            forms = homePage.OpenForms();
            practiceForm = forms.OpenPracticeForm();
        }

        //Case1
        [Test]
        public void FormSubmit()
        {
            practiceForm.FillForm(Student.Create("Ali", "Ahmed", "Male", "34401234567"));
            practiceForm.Submit();
            Assert.AreEqual(true, practiceForm.IsSubmissionSuccessful());
        }

        //Case2
        [TestCase]
        public void ValidateFields()
        {
            var InvalidFieldColor = "rgb(220, 53, 69)";
            practiceForm.Submit();
            Assert.AreEqual(InvalidFieldColor, practiceForm.GetFirstNameColor()); //Validate FirstName
            Assert.AreEqual(InvalidFieldColor, practiceForm.GetLastNameColor()); //Validate LastName
            Assert.AreEqual(true, practiceForm.IsGenderValidated());//Validate Gender
        }

        [TearDown]
        public void Close()
        {
            practiceForm.CloseWindow();
        }
    }
}
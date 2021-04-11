using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CorCentric
{
    public class CorCentricTests
    {
        IWebDriver driver;
        PracticeForm practiceForm;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Users\Hp\Downloads\chromedriver_win32");
            practiceForm = new PracticeForm(driver);
        }

        static object[] Student =
        {
            new object[] { "Ali", "Ahmed", "34401234567", "Male"},
            new object[] { "Kashif", "ALi", "3001234567", "Female"},
            new object[] { "Kashif", "ALi", "3001234567", "Others"}
        };

        //Case1
        [TestCaseSource("Student")]
        public void FormSubmit(string firstName, string lastName, string mobileNumber, string Gender)
        {

            practiceForm.OpenPage();
            practiceForm.OpenForms();
            practiceForm.OpenPracticeForm();
            practiceForm.FillForm(firstName, lastName, mobileNumber, Gender);
            practiceForm.Submit();
            Assert.AreEqual(true, practiceForm.IsLoginSuccessful());
        }

        //Case2
        [TestCase]
        public void ValidateFields()
        {
            var InvalidFieldColor = "rgb(220, 53, 69)";
            practiceForm.OpenPage();
            practiceForm.OpenForms();
            practiceForm.OpenPracticeForm();
            practiceForm.FillForm(string.Empty, string.Empty, string.Empty, string.Empty);
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
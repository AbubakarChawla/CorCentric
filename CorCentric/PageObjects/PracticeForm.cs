using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace CorCentric
{
    public class PracticeForm
    {
        private IWebDriver driver;

        public PracticeForm(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "firstName")]
        private IWebElement FirstName;
        [FindsBy(How = How.Id, Using = "lastName")]
        private IWebElement LastName;
        [FindsBy(How = How.Id, Using = "userNumber")]
        private IWebElement UserNumber;

        [FindsBy(How = How.XPath, Using = @"//*[@id=""genterWrapper""]/div[2]/div[1]")]
        private IWebElement Male;
        [FindsBy(How = How.XPath, Using = @"//*[@id=""genterWrapper""]/div[2]/div[2]")]
        private IWebElement Female;
        [FindsBy(How = How.XPath, Using = @"//*[@id=""genterWrapper""]/div[2]/div[3]")]
        private IWebElement OtherGender;

        [FindsBy(How = How.XPath, Using = @"//*[@id=""genterWrapper""]/div[2]/div[1]/label")]
        private IWebElement MaleRadioButton;
        [FindsBy(How = How.XPath, Using = @"//*[@id=""genterWrapper""]/div[2]/div[2]/label")]
        private IWebElement FemaleRadioButton;
        [FindsBy(How = How.XPath, Using = @"//*[@id=""genterWrapper""]/div[2]/div[3]/label")]
        private IWebElement OtherRadioButton;
        [FindsBy(How = How.XPath, Using = @"//*[@id=""genterWrapper""]/div[2]/div[2]")]

        [FindsBy(How = How.XPath, Using = @"//*[@id=""userForm""]/div[11]/div")]
        private IWebElement FormSubmit;
        [FindsBy(How = How.XPath, Using = @"/html/body/div[3]/div/div")]
        private IWebElement Submitted;

        public void FillForm(Student student)
        {
            FirstName.SendKeys(student.FirstName);
            LastName.SendKeys(student.LastName);
            UserNumber.SendKeys(student.MobileNumber);

            if (student.Gender == "Male")
            {
                Male.Click();
            }

            else if (student.Gender == "Female")
            {
                Female.Click();
            }

            else if (student.Gender == "Others")
            {
                OtherGender.Click();
            }
        }

        public void Submit()
        {
            FormSubmit.Submit();
            Thread.Sleep(2000);
        }

        public bool IsSubmissionSuccessful()
        {
            return Submitted.Displayed;
        }

        public void CloseWindow()
        {
            driver.Close();
        }

        public string GetFirstNameColor()
        {
            return FirstName.GetCssValue("border-color");
        }

        public string GetLastNameColor()
        {
            return FirstName.GetCssValue("border-color");
        }

        public bool IsGenderValidated()
        {
            var InvalidFieldColor = "rgb(220, 53, 69)";
            return MaleRadioButton.GetCssValue("border-color") == InvalidFieldColor && FemaleRadioButton.GetCssValue("border-color") == InvalidFieldColor && OtherRadioButton.GetCssValue("border-color") == InvalidFieldColor; ;
        }
    }
}

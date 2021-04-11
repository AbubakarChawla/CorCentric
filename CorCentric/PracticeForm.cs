using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace CorCentric
{
    class PracticeForm
    {
        private IWebDriver driver;
        public PracticeForm(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = @"//*[@id=""app""]/div/div/div[2]/div/div[2]/div")]
        private IWebElement Forms;
        [FindsBy(How = How.XPath, Using = @"//*[@id=""app""]/div/div/div[2]/div[1]/div/div/div[2]/div")]
        private IWebElement PracticeFormXpath;

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

        [FindsBy(How =How.XPath, Using = @"//*[@id=""genterWrapper""]/div[2]/div[1]/label")]
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

        public void OpenPage()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/");
        }

        public void OpenForms()
        {
            Forms.Click();
        }

        public void OpenPracticeForm()
        {
            PracticeFormXpath.Click();
        }

        public void FillForm(string firstName, string lastName, string mobileNumber, string Gender)
        {
            FirstName.SendKeys(firstName);
            LastName.SendKeys(lastName);
            UserNumber.SendKeys(mobileNumber);

            if(Gender=="Male")
            {
                Male.Click();
            }

            else if(Gender=="Female")
            {
                Female.Click();
            }
            
            else if(Gender == "Others")
            {
                OtherGender.Click();
            }
        }

        public void Submit()
        {
            FormSubmit.Submit();
            Thread.Sleep(2000);
        }

        public bool IsLoginSuccessful()
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

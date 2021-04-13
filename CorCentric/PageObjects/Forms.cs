using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorCentric.PageObjects
{
    public class Forms
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = @"//*[@id=""app""]/div/div/div[2]/div[1]/div/div/div[2]/div")]
        private IWebElement PracticeForm;

        public Forms(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public PracticeForm OpenPracticeForm()
        {
            PracticeForm.Click();
            return new PracticeForm(driver);
        }
    }
}

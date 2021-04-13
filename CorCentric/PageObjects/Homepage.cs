using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CorCentric.PageObjects
{
    public class Homepage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = @"//*[@id=""app""]/div/div/div[2]/div/div[2]/div")]
        private IWebElement Forms;

        public Homepage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/");
        }

        public Forms OpenForms()
        {
            Forms.Click();
            return new Forms(driver);
        }
    }
}

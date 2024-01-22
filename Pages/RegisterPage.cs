using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;

namespace TMZR_QA.Pages
{
    public class RegisterPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private int num = 0;

        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Random rnd = new Random();
            num = rnd.Next(24, 100);
        }

        // Web Element Locators
        string registerForm = "//*[@data-testid='registerForm']";
        By registerButton = By.CssSelector("button[type='submit']");
        By alert = By.XPath("//li[@role='status']");

        public void inputText(string fieldName, string text)
        {
            // For Dynamic value = Append a random number
            if (fieldName == "email")
            {
                text = text.Replace("{0}", num.ToString());
            }
            else if (fieldName == "username")
            {
                text = text.Replace("{0}", num.ToString());
            }

            driver.FindElement(By.XPath($"//*[@data-testid='{fieldName}']")).SendKeys(text);
        }

        public void setPreferredLanguage(string languageCode)
        {
            // Find and click the option with the desired value
            SelectElement lang = new SelectElement(driver.FindElement(By.XPath(registerForm + "//select")));
            if (lang != null)
            {
                lang.SelectByValue(languageCode);
            }
        }

        public void clickOnSubmitButton()
        {
            driver.FindElement(registerButton).Click();
        }

        public void fieldValidationMessageDisplayed(string message, string fieldName)
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[@data-testid='{fieldName}']/following-sibling::p")));
            Assert.AreEqual(message, element.Text);
        }

        public void formValidationMessageDisplayed(string message)
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(alert));
            Assert.IsTrue(element.Text.Contains(message));
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TMZR_QA.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // WEB ELEMENT LOCATOR VARIABLES
        string loginForm = "//*[@data-testid='loginForm']";
        By loginButton = By.CssSelector("button[type='submit']");
        By alert = By.XPath("//li[@role='status']");

        public void navigateToLoginPage()
        {
            driver.Navigate().GoToUrl("https://teamzeroweb.azurewebsites.net/login");
        }

        /// <summary>
        /// Will look for an input field and input a text
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        public void inputText(string fieldName, string text)
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[@data-testid='{fieldName}']")));
            element.Click();
            element.SendKeys(text);
        }
        public void clickOnSubmitButton()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(loginButton).Click();
        }

        // ASSERTIONS SECTION

        /// <summary>
        /// Display an inline message below the field being validated
        /// </summary>
        /// <param name="message"></param>
        /// <param name="field"></param>
        public void fieldValidationMessageDisplayed(string message, string field)
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[@data-testid='{field}']/following-sibling::p")));
            Assert.AreEqual(message, element.Text);
        }

        /// <summary>
        /// Display a pop-up alert if login is unsuccesfull
        /// </summary>
        /// <param name="message"></param>
        public void formValidationMessageDisplayed(string message)
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(alert));
            Assert.IsTrue(element.Text.Contains(message));
        }

        public void redirectUserToLoginPage(string expectedUrl)
        {
            // Wait for the redirect to complete
            wait.Until(d => d.Url.StartsWith(expectedUrl, StringComparison.OrdinalIgnoreCase));

            // Get the current URL after the redirect
            string currentUrl = driver.Url;

            // Assert that the current URL is the expected URL
            Assert.IsTrue(currentUrl.StartsWith(expectedUrl, StringComparison.OrdinalIgnoreCase),
                "The user was not redirected to the expected URL. Expected: " + expectedUrl + ". Actual: " + currentUrl);
        }
    }
}

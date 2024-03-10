using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TMZR_QA.Pages;

namespace TMZR_QA.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private IWebDriver driver;
        LoginPage loginPage;
        HomePage homePage;

        /// <summary>
        /// This will pull the driver from the Hooks.cs
        /// </summary>
        /// <param name="driver"></param>
        public LoginStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
        }

        [Given(@"User is the login page")]
        public void GivenUserIsTheLoginPage()
        {
            // Modify this once environment is already available
            loginPage.navigateToLoginPage();
        }

        [When(@"User enter '([^']*)' value in Login Page '([^']*)' text field")]
        public void WhenUserEntersValueInLoginPageTextField(string value, string fieldName)
        {
            loginPage.inputText(fieldName, value);
        }

        [When(@"User clicks the login button")]
        public void WhenUserClicksTheLoginButton()
        {
            loginPage.clickOnSubmitButton();
        }

        [Then(@"User is succesfully logged in")]
        public void ThenUserIsSuccesfullyLoggedIn()
        {
            homePage.userIsLoggedIn();
        }

        [Then(@"Field validation '(.*)' should appear for Login Page '(.*)' field")]
        public void ThenFieldValidationShouldAppearForLoginPageField(string message, string field)
        {
            loginPage.fieldValidationMessageDisplayed(message, field);
        }

        [Then(@"Login Form validation alert '([^']*)' should appear")]
        public void ThenLoginFormValidationAlertShouldAppear(string message)
        {
            loginPage.formValidationMessageDisplayed(message);
        }

        [Then(@"User is redirected to Login Page '([^']*)'")]
        public void ThenUserIsRedirectedToLoginPage(string expectedUrl)
        {
            loginPage.redirectUserToLoginPage(expectedUrl);
        }

    }
}

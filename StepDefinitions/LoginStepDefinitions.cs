using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Xml.Linq;
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
            driver.Navigate().GoToUrl("http://localhost:3000/login");
        }

        [When(@"User enter a valid email '([^']*)'")]
        public void WhenUserEnterAValidEmail(string email)
        {
            loginPage.inputEmail(email);
        }

        [When(@"User enter a valid password '([^']*)'")]
        public void WhenUserEnterAValidPassword(string password)
        {
            loginPage.inputPassword(password);
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

        [Then(@"An error alert message should appear")]
        public void ThenAnErrorAlertMessageShouldAppear()
        {
            loginPage.alertErrorMessageDisplayed();
        }

    }
}

using OpenQA.Selenium;
using TMZR_QA.Pages;

namespace TMZR_QA.StepDefinitions
{
    [Binding]
    public class RegisterStepDefinition
    {
        private IWebDriver driver;
        RegisterPage registerPage;

        public RegisterStepDefinition (IWebDriver driver)
        {
            this.driver = driver;
            registerPage = new RegisterPage(driver);
        }

        [Given(@"User is the register page")]
        public void GivenUserIsTheRegisterPage()
        {
            driver.Navigate().GoToUrl("http://localhost:3000/register");
        }

        [When(@"User enter '(.*)' value in Register Page '(.*)' text field")]
        public void WhenUserEntersValueInRegisterPageTextField(string value, string fieldName)
        {
            registerPage.inputText(fieldName, value);
        }

        [When(@"User selects a '([^']*)' option in language droplist")]
        public void WhenUserSelectsAOptionInLanguageDroplist(string language)
        {
            registerPage.setPreferredLanguage(language);
        }

        [When(@"User clicks the register button")]
        public void WhenUserClicksTheRegisterButton()
        {
            registerPage.clickOnSubmitButton();
        }

        [Then(@"User successully registers an account with message '([^']*)'")]
        public void ThenUserSuccessullyRegistersAnAccountWithMessage(string message)
        {
            
        }

        [Then(@"Field validation '([^']*)' should appear for Register Page '([^']*)' field")]
        public void ThenFieldValidationShouldAppearForRegisterPageField(string message, string fieldName)
        {
            throw new PendingStepException();
        }

        [Then(@"Register Form validation alert '([^']*)' should appear")]
        public void ThenLoginFormValidationAlertShouldAppear(string message)
        {
            registerPage.formValidationMessageDisplayed(message);
        }

    }
}

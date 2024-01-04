using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMZR_QA.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By emailInputField = By.XPath("//*[@data-testid='email']");
        By passwordInputField = By.XPath("//*[@data-testid='password']");
        By loginButton = By.CssSelector("button[type='submit']");
        By alert = By.XPath("//li[@role='status']");

        public void inputEmail(String email)
        {
            driver.FindElement(emailInputField).SendKeys(email);
        }

        public void inputPassword(String password)
        {
            driver.FindElement(passwordInputField).SendKeys(password);
        }

        public void clickOnSubmitButton()
        {
            driver.FindElement(loginButton).Click();
        }

        public void alertErrorMessageDisplayed()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(alert));
            Assert.IsTrue(element.Displayed);
        }
    }
}

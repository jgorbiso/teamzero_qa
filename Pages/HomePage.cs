using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TMZR_QA.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        WebDriverWait wait;

        public HomePage (IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        By userAvatarIcon = By.ClassName("aspect-square");

        public void userIsLoggedIn()
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(userAvatarIcon));
            Assert.IsTrue(element.Displayed);
        }
    }
}

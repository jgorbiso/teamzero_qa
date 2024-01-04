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
    public class HomePage
    {
        private IWebDriver driver;
        WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By userAvatarIcon = By.ClassName("aspect-square");

        public void userIsLoggedIn()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(userAvatarIcon));
            Assert.IsTrue(element.Displayed);
        }
    }
}

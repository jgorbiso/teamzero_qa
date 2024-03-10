using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace TMZR_QA.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _container;
        private IWebDriver _driver = null;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario("@login")]
        public void BeforeScenarioWithTag()
        {
            Console.WriteLine("Running inside tagged hooks in SpecFlow");
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            // TODO: Optimize & Organize Codes: // Create Test Runner and AppSettings

            // Chrome Browser
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--headless=new"); // Run Test in headless browser
            _driver = new ChromeDriver(chromeOptions);
            _container.RegisterInstanceAs(_driver, typeof(IWebDriver));

            // Firefox Browser
            /*var ffOptions = new FirefoxOptions();
            //ffOptions.AddArgument("-headless"); // Run Test in headless browser
            _driver = new FirefoxDriver(ffOptions);
            _container.RegisterInstanceAs(_driver, typeof(IWebDriver));*/
        }

        [BeforeStep] public void FirstStep()
        {
            var driver = _container.Resolve<IWebDriver>();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();

            // if dirver is open, then close it
            if (driver != null)
            {
                driver.Close();
                driver.Quit();
            }
        }

    }
}
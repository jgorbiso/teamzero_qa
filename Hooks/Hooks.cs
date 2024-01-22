using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TMZR_QA.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _container;

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
            var options = new ChromeOptions();
            //options.AddArgument("--headless=new");
            IWebDriver driver = new ChromeDriver(options);
            _container.RegisterInstanceAs(driver);
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
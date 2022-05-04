using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


//[assembly: LevelOfParallelism(3)]
namespace EPAM_LAb_Rozetka.Tests
{
    //[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class BaseTest
    {
        public IWebDriver driver;
        private string url = "https://rozetka.com.ua/ua/";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}

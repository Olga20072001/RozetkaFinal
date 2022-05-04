using log4net;
using log4net.Config;
using log4net.Repository;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;


[assembly: LevelOfParallelism(3)]
namespace EPAM_LAb_Rozetka.Tests
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class BaseTest
    {
        public IWebDriver driver;
        private string url = "https://rozetka.com.ua/ua/";

        public static readonly ILog logger = LogManager.GetLogger(typeof(CheckSumInTheCartTest));
        private static readonly ILoggerRepository repository = LogManager.GetRepository(Assembly.GetCallingAssembly());

        [SetUp]
        public void Setup()
        {
            var logConfiguration = new FileInfo(@"Log4net.config");
            XmlConfigurator.Configure(repository, logConfiguration);
            BasicConfigurator.Configure();

            logger.Info("Browser open ... ");
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [TearDown]
        public void TearDown()
        {
            logger.Info("Browser closed ... ");
            driver.Quit();
        }
    }
}

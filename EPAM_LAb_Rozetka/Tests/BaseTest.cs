using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
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

        public static ExtentReports extent = new ExtentReports();

        public static ExtentReports extend;
        static ExtentHtmlReporter htmlReporter;
        public static ExtentTest test;

        static string dataFile = @"\Logs\index.html";
        string path = Directory.GetCurrentDirectory();

       
        [SetUp]
        public void Setup()
        {
            var logConfiguration = new FileInfo(@"Log4net.config");
            XmlConfigurator.Configure(repository, logConfiguration);
            BasicConfigurator.Configure();

            path = path[0..^24];
            path += dataFile;
            htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Config.DocumentTitle = "Test Report | Melnyk Olha";
            htmlReporter.Config.ReportName = "Test Report | Melnyk Olha";
            extend = new ExtentReports();
            extend.AttachReporter(htmlReporter);


            logger.Info("Browser open ... ");
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [TearDown]
        public void TearDown()
        {
            extend.Flush();
            logger.Info("Browser closed ... ");
            driver.Quit();
        }
    }
}

using OpenQA.Selenium;
using System;

namespace EPAM_LAb_Rozetka.PageObject.Pages
{
    public class HomePage:BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        private readonly By searchField = By.XPath("//input[@name='search']");
        private readonly By searchButton = By.XPath("//button[contains(text(),'Знайти')]");

        public SearchResultPage SearchByKeyword(String keyword)
        {
            driver.FindElement(searchField).SendKeys(keyword);
            driver.FindElement(searchButton).Click();
            return new SearchResultPage(driver);
        }
    }
}

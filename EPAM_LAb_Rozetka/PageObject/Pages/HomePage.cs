using EPAM_LAb_Rozetka.Decorator;
using OpenQA.Selenium;
using System;

namespace EPAM_LAb_Rozetka.PageObject.Pages
{
    public class HomePage:BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        private readonly By searchField = By.XPath("//input[@name='search']");
        private readonly By searchButton = By.XPath("//button[contains(text(),'Знайти')]");

        public ClickDecorator clickSearchButton => new ClickDecorator(driver.FindElement(searchButton));
        public SendKeysDecorator sendKeysInSearchField => new SendKeysDecorator(driver.FindElement(searchField));

        public SearchResultPage SearchByKeyword(string keyword)
        {
            sendKeysInSearchField.SendKeys(keyword);
            clickSearchButton.Click();
            return new SearchResultPage(driver);
        }
    }
}

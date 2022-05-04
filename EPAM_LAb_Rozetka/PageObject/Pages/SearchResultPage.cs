using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace EPAM_LAb_Rozetka.PageObject.Pages
{
    public class SearchResultPage:BasePage
    {
        public SearchResultPage(IWebDriver driver) : base(driver) { }

        private readonly By brandFilter = By.XPath("//span[contains(text(),'Бренд')]//..//..//a[@class='checkbox-filter__link']");
        private readonly By brandSearchField = By.XPath("//input[@name='searchline']");
        private readonly By orderBySelect = By.XPath("//select[contains(@class,'select-css')]");
        private readonly By itemList = By.XPath("//a[@class='goods-tile__picture ng-star-inserted']");

        public void SearchBrandName(string filterName)
        {
            WaitUntilPageLoad();
            WaitUntilElementExists(brandSearchField);
            driver.FindElement(brandSearchField, timeToWait).SendKeys(filterName);
            CheckButtonChecked(filterName);
        }

        public void CheckButtonChecked(string filterName)
        {
            IList<IWebElement> brandList = driver.FindElements(brandFilter, timeToWait);
            for (int i = 0; i < brandList.Count; i++)
            {
                WaitUntilElementExists(brandFilter);
                brandList = driver.FindElements(brandFilter, timeToWait);
                string Value = brandList.ElementAt(i).GetAttribute("data-id");
                if (Value.Equals(filterName))
                {
                    WaitUntilElementExists(brandFilter);
                    brandList = driver.FindElements(brandFilter, timeToWait);
                    brandList.ElementAt(i).Click();
                    break;
                }
            }
        }

        public void OrderBy()
        {
            WaitUntilPageLoad();
            IWebElement selectObj = driver.FindElement(orderBySelect);
            selectObj.Click();
            var selectObject = new SelectElement(selectObj);
            selectObject.SelectByValue("2: expensive");
        }

        public ProductPage getItemByIndex(int index)
        {
            WaitUntilPageLoad();
            WaitUntilElementExists(itemList);
            driver.FindElements(itemList).ElementAt(index).Click();
            return new ProductPage(driver);
        }

    }
}

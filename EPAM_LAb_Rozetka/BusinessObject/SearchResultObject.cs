using EPAM_LAb_Rozetka.PageObject.Pages;
using OpenQA.Selenium;

namespace EPAM_LAb_Rozetka.BusinessObject
{
    public class SearchResultObject
    {
        public SearchResultPage searchResultPage;

        public SearchResultObject(IWebDriver driver) { searchResultPage = new SearchResultPage(driver); }

        public void GetProduct(string filterName, int index)
        {
            searchResultPage.SearchBrandName(filterName);
            searchResultPage.OrderBy();
            searchResultPage.getProductByIndex(index);
        }
    }
}

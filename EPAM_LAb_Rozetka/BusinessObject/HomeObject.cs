using EPAM_LAb_Rozetka.PageObject.Pages;
using OpenQA.Selenium;

namespace EPAM_LAb_Rozetka.BusinessObject
{
    public class HomeObject
    {
        public HomePage homePage;
        
        public HomeObject(IWebDriver driver) { homePage = new HomePage(driver); }

        public void SearchByKeyword(string keyword)
        {
            homePage.SearchByKeyword(keyword);
        }
    }
}

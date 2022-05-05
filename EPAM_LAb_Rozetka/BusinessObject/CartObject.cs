using EPAM_LAb_Rozetka.PageObject.Pages;
using OpenQA.Selenium;

namespace EPAM_LAb_Rozetka.BusinessObject
{
    public class CartObject
    {
        public CartPage cartPage;

        public CartObject(IWebDriver driver) { cartPage = new CartPage(driver); }

        public double GetTotalSumFromPage()
        {
            return cartPage.GetTotalSumFromPage();
        }
    }
}

using EPAM_LAb_Rozetka.PageObject.Pages;
using OpenQA.Selenium;

namespace EPAM_LAb_Rozetka.BusinessObject
{
    public class ProductObject
    {
        public ProductPage productPage;

        public ProductObject(IWebDriver driver) { productPage = new ProductPage(driver); }

        public void BuyProduct()
        {
            productPage.ClickBuyButton();
            productPage.ClickCartButton();
        }

    }
}

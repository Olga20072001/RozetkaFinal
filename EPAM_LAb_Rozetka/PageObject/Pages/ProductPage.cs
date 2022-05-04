using OpenQA.Selenium;

namespace EPAM_LAb_Rozetka.PageObject.Pages
{
    public class ProductPage:BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        private readonly By buyButton = By.XPath("//button[contains(@class,'buy-button')]//span[contains(text(),'Купити')]");
        private readonly By cartButton = By.XPath("//li[contains(@class,'item--cart')]//button");

        public void ClickBuyButton()
        {
            WaitUntilPageLoad();
            WaitUntilElementExists(buyButton);
            driver.FindElement(buyButton).Click();
        }

        public CartPage ClickCartButton()
        {
            WaitUntilElementExists(cartButton);
            driver.FindElement(cartButton).Click();
            return new CartPage(driver);
        }
    }
}

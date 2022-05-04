using EPAM_LAb_Rozetka.Decorator;
using OpenQA.Selenium;

namespace EPAM_LAb_Rozetka.PageObject.Pages
{
    public class ProductPage:BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        private readonly By buyButton = By.XPath("//button[contains(@class,'buy-button')]//span[contains(text(),'Купити')]");
        private readonly By cartButton = By.XPath("//li[contains(@class,'item--cart')]//button");

        public ClickDecorator clickBuyButton => new ClickDecorator(driver.FindElement(buyButton));
        public ClickDecorator clickCartButton => new ClickDecorator(driver.FindElement(cartButton));

        public void ClickBuyButton()
        {
            WaitUntilPageLoad();
            WaitUntilElementExists(buyButton);
            clickBuyButton.Click();
        }

        public CartPage ClickCartButton()
        {
            WaitUntilElementExists(cartButton);
            clickCartButton.Click();
            return new CartPage(driver);
        }
    }
}

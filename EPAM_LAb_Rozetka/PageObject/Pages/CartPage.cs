using EPAM_LAb_Rozetka.Decorator;
using OpenQA.Selenium;
using System;

namespace EPAM_LAb_Rozetka.PageObject.Pages
{
    public class CartPage:BasePage
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        private readonly By totalSum = By.XPath("//div[@class='cart-receipt__sum-price']//span[not(@class)]");

        public TextDecorator totalSumText => new TextDecorator(driver.FindElement(totalSum));

        public double GetTotalSumFromPage()
        {
            WaitUntilElementExists(totalSum);
            string sum = totalSumText.Text;
            return Convert.ToDouble(sum);
        }
    }
}

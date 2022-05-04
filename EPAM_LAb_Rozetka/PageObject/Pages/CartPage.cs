using OpenQA.Selenium;
using System;

namespace EPAM_LAb_Rozetka.PageObject.Pages
{
    public class CartPage:BasePage
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        private readonly By totalSum = By.XPath("//div[@class='cart-receipt__sum-price']//span[not(@class)]");

        public double GetTotalSumFromPage()
        {
            WaitUntilPageLoad();
            WaitUntilElementExists(totalSum);
            string sum = driver.FindElement(totalSum).Text;
            return Convert.ToDouble(sum);
        }
    }
}

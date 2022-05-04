using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace EPAM_LAb_Rozetka.Decorator
{
    public class ClickDecorator : WebElementDecorator
    {
        public ClickDecorator(IWebElement element) : base(element) { }

        public override void Click()
        {
            base.Click();
        }
    }
}

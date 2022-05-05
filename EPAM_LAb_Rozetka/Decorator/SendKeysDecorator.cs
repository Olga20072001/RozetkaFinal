using OpenQA.Selenium;

namespace EPAM_LAb_Rozetka.Decorator
{
    public class SendKeysDecorator:WebElementDecorator
    {
        public SendKeysDecorator(IWebElement element):base(element) { }

        public override void SendKeys(string text)
        {
            base.SendKeys(text);
        }
    }
}

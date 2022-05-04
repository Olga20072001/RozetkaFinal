using OpenQA.Selenium;

namespace EPAM_LAb_Rozetka.Decorator
{
    public class TextDecorator:WebElementDecorator
    {
        public TextDecorator(IWebElement element):base(element) { }

        public override string Text => base.Text;
    }
}

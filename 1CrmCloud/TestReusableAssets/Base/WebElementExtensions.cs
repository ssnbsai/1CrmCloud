using OpenQA.Selenium;
using CRMCloud.Constants;

namespace PGSAEndToEndBaseProject.Extensions
{
    public static class WebElementExtensions
    {

        public static void Click(IWebElement element)
        {
          element.Click();
        }

        public static void ClickAndWait(this IWebDriver driver, IWebElement element, TimeSpan? timeout = null)
        {
            if (timeout == null)
            {
                timeout = TimeSpan.FromSeconds(30);
            }
            Click(element);
            driver.Manage().Timeouts().ImplicitWait = (TimeSpan)timeout;
        }

        public static bool WaitForElementIsVisible(this IWebElement element, int timeoutInSeconds = TimeoutInSeconds.ControlTimeout)
        {
            var result = false;
            var timeout = 0;
            while (result == false)
            {
                if (timeout >= timeoutInSeconds)
                {
                    break;
                }

                Thread.Sleep(TimeoutInSeconds.OneSecond);
                timeout += 1;
                result = element.Displayed;
            }
            return result;
        }

    }
}

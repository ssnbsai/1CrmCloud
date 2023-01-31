using OpenQA.Selenium;
using CRMCloud.Constants;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;
using System.Threading;

namespace CRMCloud.Base
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

        public static IWebElement WaitForElementIsVisible(this IWebDriver driver, By locator, int timeoutInSeconds = TimeoutInSeconds.ControlTimeout)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));

        }

        public static void MoveToElement(this IWebDriver driver, IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
            driver.Manage().Timeouts().ImplicitWait = (TimeSpan)TimeSpan.FromSeconds(5);
        }

    }
}

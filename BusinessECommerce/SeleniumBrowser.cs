using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BusinessECommerce.Core;

namespace BusinessECommerce.Orchestration
{
    internal class SeleniumBrowser : IBrowser
    {
        private  readonly IWebDriver _driver;

        public SeleniumBrowser(IWebDriver driver) => _driver = driver;
        
        public void Navigate(string url) => _driver.Navigate().GoToUrl(url);
        public string Url => _driver.Url;

        public IWebElement? FindElement(By by) => _driver.FindElement(by);

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }

    public class SeleniumBrowserFactory : IBrowserFactory
    {
        public IBrowser Create(bool headless = false)
        {
            var options = new ChromeOptions();
            if (headless) options.AddArgument("--headless=new");
            
            return new SeleniumBrowser(new ChromeDriver(options));
        }
    }
}
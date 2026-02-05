using System;
using BusinessECommerce.Core;


namespace BusinessECommerce.Orchestration
{
    public class AutomationWeb
    {
        private readonly IBrowser _browser;
        

        public AutomationWeb(IBrowserFactory browserFactory, bool headless = false)
        {
            if(browserFactory is null) throw new ArgumentNullException(nameof(browserFactory));
            _browser = browserFactory.Create(headless);
        }

        public void TestWeb()
        {
            try
            {
                _browser.Navigate("https://www.google.com/");
                
                var campoBusca = _browser.FindElement(OpenQA.Selenium.By.Name("q"));
                if(campoBusca is null)
                {
                    throw new Exception("Search field not found");
                }
                campoBusca.Click();
                campoBusca.SendKeys("Hello World");
                campoBusca.Submit();
                
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
            finally
            {
                _browser.Dispose();
            }
        }
    }
}

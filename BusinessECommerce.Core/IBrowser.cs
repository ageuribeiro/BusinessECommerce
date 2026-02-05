using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessECommerce.Core
{
    public interface IBrowser : IDisposable
    {
        void Navigate(string url);
        string Url { get; }
        OpenQA.Selenium.IWebElement? FindElement(OpenQA.Selenium.By by);
    }
}
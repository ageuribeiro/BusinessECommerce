using System;

namespace BusinessECommerce.Core
{
    public abstract class Base : IDisposable
    {
        protected IBrowser? Browser;
        private readonly IBrowserFactory _factory;

        protected Base(IBrowserFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        
        public  virtual void Start(bool headless = false)
        {
            Browser = _factory.Create(headless);
        }
        public void Dispose()
        {
            
            Browser?.Dispose();
        }
    }
}

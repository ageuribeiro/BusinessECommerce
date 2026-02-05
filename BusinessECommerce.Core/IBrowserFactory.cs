using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessECommerce.Core
{
    public interface IBrowserFactory
    {
        IBrowser Create(bool headless = false);
    }
}

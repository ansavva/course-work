using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Logic.Contracts
{
    public interface IConfigurationSettings
    {
        string Settings(string key);
    }
}

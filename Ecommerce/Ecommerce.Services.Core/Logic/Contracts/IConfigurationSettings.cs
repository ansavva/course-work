using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Core.Logic.Contracts
{
    public interface IConfigurationSettings
    {
        string Settings(string key);
    }
}

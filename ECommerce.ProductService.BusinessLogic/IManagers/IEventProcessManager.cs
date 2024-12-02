using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.BusinessLogic.IManagers
{
    public interface IEventProcessManager
    {
        void ProcessEvent(string message);
    }
}

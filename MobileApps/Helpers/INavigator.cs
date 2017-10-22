using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Helpers
{
   public interface INavigator
   {
        string getNextStep(string currentPage);

   }
}

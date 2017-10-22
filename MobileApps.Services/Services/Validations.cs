
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MobileApps.Services.Services
{
    class Validations
    { 

    public static bool validEmail(string email)
    {

        if (Regex.IsMatch(email, "^([/w/./-]+)@([/w/-]+)((/.(/w){2,3})+)$"))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public static bool validPhone(string phone)
    {
        if (Regex.IsMatch(phone, "/(?/d{3}/)?[. -]? */d{3}[. -]? *[. -]?/d{4}"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    }
}

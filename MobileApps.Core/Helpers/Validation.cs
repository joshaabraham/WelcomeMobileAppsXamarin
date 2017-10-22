using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MobileApps.Core.Helpers
{
    static public class ValidationLogic
    {
        public static bool IsAlphabeticalOnly(string str)
        {
			Regex nominationRegex = new Regex(@"^[A-Za-z '-]+[A-Za-z ]+$");

			if (nominationRegex.IsMatch(str)) return true;
		    return false;
		}

        public static bool IsDigitsOnly(string str)
        {
            char[] characters = str.ToCharArray();
            return characters.All(char.IsDigit);
        }

        public static bool IsNotEmpty(string str)
        {
            return str != string.Empty;
        }

        public static bool IsEmailFormat(string str)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return !string.IsNullOrWhiteSpace(str) && emailRegex.IsMatch(str);
        }
        public static bool IsPhoneFormat(string str)
        {
            return str.Length == 10 && IsDigitsOnly(str);
        }

        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source != null && toCheck != null && source.IndexOf(toCheck, comp) >= 0;
        }

    }
}

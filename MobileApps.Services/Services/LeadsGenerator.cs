using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Services.Services
{
    class LeadsGenerator
    {
        //Lead[] DummyLeads = { };

        //Lead LeadOne = new Lead(new Organization("Dawson"));
        //public class ContactGenerator
        //{
        //    private static List<string> FirstNames = new List<string> {
        //    "Aiden", "Liam", "Lucas", "Noah", "Mason", "Ethan", "Caden", "Jacob", "Logan", "Jayden", "Elijah", "Jack", "Luke", "Michael", "Benjamin",
        //    "Alexander", "James", "Jayce", "Caleb", "Connor", "William", "Carter", "Ryan", "Oliver", "Matthew", "Daniel", "Gabriel", "Henry", "Owen",
        //    "Grayson", "Lincoln", "Jordan", "Tristan", "Jason", "Josiah", "Xavier", "Camden", "Chase", "Declan", "Carson", "Colin", "Brody", "Asher",
        //    "Jeremiah", "Micah", "Easton", "Xander", "Ryder", "Nathaniel", "Elliot", "Sean"
        //};

        //    private static List<string> LastNames = new List<string> {
        //    "SMITH", "JOHNSON", "WILLIAMS", "BROWN", "JONES", "MILLER", "DAVIS", "GARCIA", "RODRIGUEZ", "WILSON", "MARTINEZ", "ANDERSON", "TAYLOR", "THOMAS HERNANDEZ",
        //    "RICHARDSON", "WOOD", "WATSON", "BROOKS", "BENNETT GRAY", "JAMES", "REYES", "CRUZ", "HUGHES", "PRICE", "MYERS", "LONG", "FOSTER SANDERS", "ROSS",
        //    "MORALES", "POWELL", "SULLIVAN", "RUSSELL ORTIZ", "JENKINS", "GUTIERREZ", "PERRY", "BUTLER", "BARNES FISHER", "HENDERSON", "COLEMAN", "SIMMONS", "PATTERSON",
        //    "JORDAN", "REYNOLDS"
        //};

        //    public static List<Contact> CreateContacts()
        //    {

        //        var random = new Random();
        //        List<Contact> contacts = new List<Contact>();

        //        for (int i = 0; i < 25; i++)
        //        {
        //            string first = FirstNames[random.Next(FirstNames.Count - 1)];
        //            string last = LastNames[random.Next(LastNames.Count - 1)];
        //            first = InitCap(first);
        //            last = InitCap(last);
        //            Contact contact = new Contact();
        //            contact.FirstName = first;
        //            contact.LastName = last;
        //            contact.Email = first + "@gmail.com";
        //            contact.Favorite = random.Next() % 2 == 0 ? true : false;
        //            contacts.Add(contact);
        //        }
        //        return contacts;
        //    }

        //    private static string InitCap(string value)
        //    {
        //        char[] array = value.ToCharArray();

        //        for (int i = 1; i < array.Length; i++)
        //        {
        //            array[i] = char.ToLower(array[i]);
        //        }

        //        if (array.Length >= 1)
        //        {
        //            array[0] = char.ToUpper(array[0]);
        //        }

        //        for (int i = 1; i < array.Length; i++)
        //        {
        //            if (array[i - 1] == ' ')
        //            {
        //                array[i] = char.ToUpper(array[i]);
        //            }
        //        }
        //        return new string(array);
        //    }
        //}
    }
}

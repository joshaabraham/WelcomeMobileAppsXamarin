using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Models.Models
{
    public class Organization
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Organization(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Organization(string name)
        {
            Id = new Guid();
            Name = name;
        }
        public Organization()
        { }
    }
}

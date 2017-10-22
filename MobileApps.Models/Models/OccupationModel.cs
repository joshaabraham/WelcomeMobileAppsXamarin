using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Models.Models
{
    public class OccupationModel
    {
        private int _OccupationID;
        private string _Name;


        public int OccupationID
        {
            get { return _OccupationID; }
            set { _OccupationID = value; }
        }


        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }
}

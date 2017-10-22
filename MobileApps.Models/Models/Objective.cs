using System.Collections.Generic;

namespace MobileApps.Models.Models
{
    public class Objective : BaseModel
    {
        private int _VisitGoalID;
        private string _Name;
        private string _MoreInfo;

        public int VisitGoalID
        {
            get { return _VisitGoalID; }
            set { _VisitGoalID = value; }
        }

        public string MoreInfo
        {

            get { return _MoreInfo; }
            set { _MoreInfo = value; }
        }

        public class ObjectiveComparer : IEqualityComparer<Objective>
        {
            public bool Equals(Objective x, Objective y)
            {
                return (x.VisitGoalID == y.VisitGoalID) && (x.Language == y.Language);
            }

            public int GetHashCode(Objective obj)
            {
                int hashObjectiveName = obj.Name == null ? 0 : obj.Name.GetHashCode();
                int hashObjectiveGuid = obj.VisitGoalID.GetHashCode();
                return hashObjectiveName ^ hashObjectiveGuid;
            }
        }
    }
}

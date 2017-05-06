using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.Database.Entity.BusinessLayer;
using TotalizatorWebApp.Database.Models.UserLayer;

namespace TotalizatorWebApp.Database.Models.BusinessLayer
{
    public class TotalizatorWithUsersView
    {
        public int TotalizatorId { get; set; }

        public string Name { get; set; }

        public string OrganaizerLogin { get; set; }

        public string Stage { get; set; }

        public string League { get; set; }

        public string Access { get; set; }

        public DateTime Validity { get; set; }

        public PointsAnalysisView PointsAnalysis { get; set; }

        public List<UserView> Users { get; set; }
    }
}

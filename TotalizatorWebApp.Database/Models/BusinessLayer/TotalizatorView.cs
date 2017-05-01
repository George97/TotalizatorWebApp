using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotalizatorWebApp.Database.Models.BusinessLayer
{
    public class TotalizatorView
    {
        public int TotalizatorId { get; set; }

        public string Name { get; set; }

        public int  OrganaizerId { get; set; }

        public string OrganaizerName { get; set; }

        public int StageId { get; set; }

        public bool isPublic { get; set; }

        public DateTime Validity { get; set; }

    }
}
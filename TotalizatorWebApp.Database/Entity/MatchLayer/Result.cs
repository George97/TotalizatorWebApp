﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalizatorWebApp.Database.Entity.MatchLayer
{
    public class Result
    {
        public int MatchId { get; set; }

        public int HomeTeamGoals { get; set; }

        public int GuestTeamGoals { get; set; }

        public virtual Match Match { get; set; }
    }
}

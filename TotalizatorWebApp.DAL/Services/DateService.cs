using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.Database.Context;

namespace TotalizatorWebApp.DAL.Services
{
    public class DateService
    {
        public static DateTime getValidDate(int stageId, TotalizatorContext context)
        {
            var matches = context.Matches.Where(m => m.StageId == stageId).ToList();
            DateTime validDate = DateTime.MaxValue;
            foreach (var m in matches)
            {
                if (m.Date < validDate)
                {
                    validDate = m.Date;
                }
            }
            return validDate;
        }
    }
}

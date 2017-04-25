using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalizatorWebApp.Database.Entity.Abstract
{
    public interface IEntity<IModel>
    {
        IModel Parse();
    }
}

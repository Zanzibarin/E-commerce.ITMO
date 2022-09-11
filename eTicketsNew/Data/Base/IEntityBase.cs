using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eTicketsNew.Data.Base
{
    public interface IEntityBase
    {
        int Id { get; set; }
    }
}

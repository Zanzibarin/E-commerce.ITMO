using eTicketsNew.Data.Base;
using eTicketsNew.Models;

namespace eTicketsNew.Data.Services
{
    public class DirectorsService : EntityBaseRepository<Director>, IDirectorsService
    {
        public DirectorsService(AppDbContext context) : base(context)
        {

        }
    }
}

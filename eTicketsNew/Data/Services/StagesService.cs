using eTicketsNew.Data.Base;
using eTicketsNew.Models;

namespace eTicketsNew.Data.Services
{
    public class StagesService: EntityBaseRepository<Stage>, IStagesService
    {
        public StagesService(AppDbContext context) : base(context)
        {

        }
    }
}

using eTicketsNew.Data.Base;
using eTicketsNew.Data.ViewModels;
using eTicketsNew.Models;
using System.Threading.Tasks;

namespace eTicketsNew.Data.Services
{
    public interface IPlaysService : IEntityBaseRepository<Play>
    {
        Task<Play> GetPlayByIdAsync(int id);
        Task<NewPlayDropdownsVM> GetNewPlayDropdownsValues();
        Task AddNewPlayAsync(NewPlayVM data);
        Task UpdatePlayAsync(NewPlayVM data);
    }
}

using eTicketsNew.Data.Base;
using eTicketsNew.Data.ViewModels;
using eTicketsNew.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketsNew.Data.Services
{
    public class PlaysService : EntityBaseRepository<Play>, IPlaysService
    {
        private readonly AppDbContext _context;

        public PlaysService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Play> GetPlayByIdAsync(int id)
        {
            var playDetails = await _context.Plays
                .Include(s => s.Stage)
                .Include(d => d.Director)
                .Include(ap => ap.Actors_Plays).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return playDetails;
        }

        public async Task<NewPlayDropdownsVM> GetNewPlayDropdownsValues()
        {
            var response = new NewPlayDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Stages = await _context.Stages.OrderBy(n => n.Name).ToListAsync(),
                Directors = await _context.Directors.OrderBy(n => n.FullName).ToListAsync(),
            };

            return response;
        }

        public async Task AddNewPlayAsync(NewPlayVM data)
        {
            var newPlay = new Play()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                StageId = data.StageId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                PlayCategory = data.PlayCategory,
                DirectorId = data.DirectorId
            };
            await _context.Plays.AddAsync(newPlay);
            await _context.SaveChangesAsync();


            //Add Play Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorPlay = new Actor_Play()
                {
                    PlayId = newPlay.Id,
                    ActorId = actorId
                };
                await _context.Actors_Plays.AddAsync(newActorPlay);
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePlayAsync(NewPlayVM data)
        {
            var dbPlay = await _context.Plays.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbPlay != null)
            {

                dbPlay.Name = data.Name;
                dbPlay.Description = data.Description;
                dbPlay.Price = data.Price;
                dbPlay.ImageURL = data.ImageURL;
                dbPlay.StageId = data.StageId;
                dbPlay.StartDate = data.StartDate;
                dbPlay.EndDate = data.EndDate;
                dbPlay.PlayCategory = data.PlayCategory;
                dbPlay.DirectorId = data.DirectorId;
                
                await _context.SaveChangesAsync();
            }


            //Remove existing actors
            var existingActorsDb = _context.Actors_Plays.Where(n => n.PlayId == data.Id).ToList();
            _context.Actors_Plays.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();


            //Add Play Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorPlay = new Actor_Play()
                {
                    PlayId = data.Id,
                    ActorId = actorId
                };
                await _context.Actors_Plays.AddAsync(newActorPlay);
            }
            await _context.SaveChangesAsync();
        }
    }
}

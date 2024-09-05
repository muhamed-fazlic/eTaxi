using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Rating;
using eTaxi.Application.DTOs.ToDo;
using eTaxi.Domain;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Persistence.Repositories
{
    
    public class ToDoRepository : GenericRepository<ToDo4924, ToDoSearchDto>, IToDoRepository
    {
        public ToDoRepository(TaxiDatabaseContext context) : base(context)
        {
        }

        public async override Task<IReadOnlyList<ToDo4924>> GetAsync(ToDoSearchDto search = null)
        {
            var entity = _context.ToDo.Include(x=>x.User).AsQueryable();

            if (search.UserId != null)
            {
                entity = entity.Where(x => x.UserId == search.UserId);
            }
          
            if (!search.Status.IsNullOrEmpty())
            {
                entity = entity.Where(x => x.Status == search.Status);
            }
            if (search.DatumVazenja != null)
            {
                entity = entity.Where(x => x.KrajnjiRok <= search.DatumVazenja);
            }

            return await entity.ToListAsync();

        }
    }
}

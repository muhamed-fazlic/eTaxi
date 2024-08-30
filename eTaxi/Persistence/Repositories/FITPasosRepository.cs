using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.FITPasos;
using eTaxi.Domain;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Persistence.Repositories
{
    public class FITPasosRepository : GenericRepository<FITPasos, FITPasosSearchDto>, IFITPassosRepository
    {
        public FITPasosRepository(TaxiDatabaseContext context) : base(context)
        {
        }

        public override async Task<IReadOnlyList<FITPasos>> GetAsync(FITPasosSearchDto search = null)
        {
            var pasosList = _context.FitPasos.AsQueryable();

            if (search != null)
            {
              
                if (search.IsValid != null)
                {
                    pasosList = pasosList.Where(pasos => pasos.IsValid == search.IsValid);
                }
               
                if (search.UserId != null)
                {
                    pasosList = pasosList.Where(pasos => pasos.UserId == search.UserId);
                }
                if (search.UserName != null)
                {
                    pasosList = pasosList.Where(pasos => pasos.User.FirstName.Contains(search.UserName)||pasos.User.LastName.Contains(search.UserName));
                }

                if (search.From != null)
                {
                    pasosList = pasosList.Where(pasos => pasos.DatumIzdavanja >= search.From);
                }
                if (search.To != null)
                {
                    pasosList = pasosList.Where(pasos => pasos.DatumIzdavanja  <= search.To);
                }

            }

            return await pasosList.ToListAsync();
        }
    }
}

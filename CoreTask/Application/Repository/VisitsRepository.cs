using CoreTask.Application.InterFaces;
using CoreTask.Domain;
using CoreTask.Domain.View;
using CoreTask.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTask.Application.Repository
{
    public class VisitsRepository : IVisits 
    {
        readonly TaskDBContext _Context;

        public VisitsRepository(TaskDBContext Context)
        {
            _Context = Context;
        }

        public async Task<Visits> SaveVisit(Visits visits)
        {
            try
            {
                visits.VisitDate = DateTime.Now;
                await _Context.Visits.AddAsync(visits);
                await _Context.SaveChangesAsync();
                return visits;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Visits>> GetAll()
        {
            return await _Context.Visits.ToListAsync();
        }

        public async Task<Visits> UpdateVisit(Visits visits)
        {
            try
            {
                var obj = await _Context.Visits.FindAsync(visits.Serial);
                obj.VisitSummary = visits.VisitSummary;
                _Context.Visits.Update(obj);
                await _Context.SaveChangesAsync();
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteVisit(int Serial)
        {
            var obj = await _Context.Visits.FindAsync(Serial);
            if (obj == null)
            {
                return false;
            }
            _Context.Visits.Remove(obj);
            await _Context.SaveChangesAsync();
            return true;
        }

        public async Task<List<VisitView>> GetSalesVisits(int SalesID)
        {
            return await (from V in _Context.Visits
                          join S in _Context.Sales on V.SalesID equals S.ID
                          join C in _Context.Customer on V.CustomerID equals C.ID
                          where V.SalesID == SalesID
                          select new VisitView
                          {
                              CustomerID = V.CustomerID,
                              CustomerName = C.Name,
                              SalesID = V.SalesID,
                              Serial = V.Serial,
                              VisitDate = V.VisitDate,
                              VisitSummary = V.VisitSummary,
                          }).ToListAsync();
        }
    }
}

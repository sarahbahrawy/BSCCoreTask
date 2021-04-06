using CoreTask.Domain;
using CoreTask.Domain.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTask.Application.InterFaces
{
   public interface IVisits
    {
        Task<List<VisitView>> GetSalesVisits(int SalesID);

        Task<Visits> SaveVisit(Visits visits);
       
        Task<Visits> UpdateVisit(Visits visits);
        
        Task<List<Visits>> GetAll();

        Task<bool> DeleteVisit(int Serial);
    }
}

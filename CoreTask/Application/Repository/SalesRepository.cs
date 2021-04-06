using CoreTask.Application.InterFaces;
using CoreTask.Domain;
using CoreTask.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTask.Application.Repository
{
    public class SalesRepository : ISales
    {
        readonly TaskDBContext _Context;

        public SalesRepository(TaskDBContext Context)
        {
            _Context = Context;
        }

        public async Task<List<Sales>> GetAll()
        {
            return await _Context.Sales.ToListAsync();
        }
    }
}

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
    public class CustomerRepository : ICustomer
    {
        readonly TaskDBContext _Context;

        public CustomerRepository(TaskDBContext Context)
        {
            _Context = Context;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _Context.Customer.ToListAsync();
        }
    }
}

using CoreTask.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTask.Application.InterFaces
{
   public interface ISales
    {
        Task<List<Sales>> GetAll();
    }
}

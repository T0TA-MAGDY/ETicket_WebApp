using ticketer.Data.Base;
using ticketer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ticketer.Data;
using ticketer.Data.Services;
namespace ticketer.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext context) : base(context)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ticketer.Data.Base;
using ticketer.Data.Services;
using ticketer.Data;
using ticketer.Models;

namespace ticketer.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context)
        {
        }
    }
}

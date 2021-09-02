using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.Training.Entities;
using Worker.Data;
using Microsoft.EntityFrameworkCore;
using Worker.Training.Contexts;

namespace Worker.Training.Repositories
{
   public  class StockPriceRepository :  Repository<StockPrice,int >, IStockPriceRepository
    {
        public StockPriceRepository(IWorkerDbContext context):
            base((DbContext)context)
        {

        }
    }
}

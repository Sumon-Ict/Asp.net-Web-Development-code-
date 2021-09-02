using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.Data;
using Worker.Training.Contexts;
using Worker.Training.Repositories;

namespace Worker.Training.UnitOfWorks
{
    public class ServiceUnitOfWork : UnitOfWork, IServiceUnitOfWork
    {
        public ICompanyRepository Companies { get; private set; }

        public IStockPriceRepository StockPrices { get; private set; }

        public ServiceUnitOfWork(IWorkerDbContext context, ICompanyRepository companies
            , IStockPriceRepository stockprices): base((DbContext)context)
        {
            Companies = companies;
            StockPrices = stockprices;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.Data;
using Worker.Training.Repositories;

namespace Worker.Training.UnitOfWorks
{
    public interface IServiceUnitOfWork : IUnitOfWork
    {
        ICompanyRepository Companies { get; }
        IStockPriceRepository StockPrices { get;}

    }
}

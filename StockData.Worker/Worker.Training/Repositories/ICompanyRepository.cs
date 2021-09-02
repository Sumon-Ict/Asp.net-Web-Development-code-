using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.Data;
using Worker.Training.Entities;
namespace Worker.Training.Repositories
{
    public interface ICompanyRepository : IRepository<Company,int >
    {

    }
}

﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.Data;
using Worker.Training.Contexts;
using Worker.Training.Entities;

namespace Worker.Training.Repositories
{
   public class CompanyRepository :  Repository<Company,int >, ICompanyRepository
    {
        public CompanyRepository(IWorkerDbContext workerDbContext)
            :base((DbContext)workerDbContext)
        {

        }
    }
}

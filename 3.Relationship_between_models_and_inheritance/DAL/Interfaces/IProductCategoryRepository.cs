﻿using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProductCategoryRepository : IBaseRepository<Category>
    {
        Task<Category> GetByName(string name);
    }
}

﻿using Cavardi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cavardi.Entities.Repositories
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        void Update(Category category);


    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EY4J5D_HFT_2021221.Models;

namespace EY4J5D_HFT_2021221.Repository
{
    public interface IRepository<T> where T : class
    {
        //CRUD
        T Create();
        T ReadOne(int id);
        IQueryable<T> ReadAll();
        T Update(int id);
        T Delete(int id);
    }
}
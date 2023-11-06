﻿using DataBase.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<T> GetGenericRepository<T>() where T : class;
        IEngagementRepository engagements { get; }
        int Complete();
    }
}

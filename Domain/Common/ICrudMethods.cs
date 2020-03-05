﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abc.Domain.Common
{
    public interface ICrudMethods<T>
    {
        Task<List<T>> Get();
        Task<T> Get(string ID);
        Task Delete(string ID);
        Task Add(T obj);
        Task Update(T obj);
    }
}
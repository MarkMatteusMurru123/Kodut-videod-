﻿namespace Abc.Domain.Common
{
    public interface IRepository<T> : ICrudMethods<T>, IPaging, IFiltering, ISorting
    {


    }
}
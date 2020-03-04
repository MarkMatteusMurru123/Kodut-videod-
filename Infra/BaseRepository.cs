﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abc.Data.Common;
using Abc.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infra
{
    public abstract class BaseRepository<TDomain, TData> : ICrudMethods<TDomain>
        where TData: PeriodData, new()
        where TDomain : Entity<TData>, new()
    {
        protected internal DbContext db;
        protected internal DbSet<TData> dbSet;


        protected BaseRepository(DbContext c, DbSet<TData> s)
        {
            db = c;
            dbSet = s;
        }
        public virtual async Task<List<TDomain>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<TDomain> Get(string ID)
        {
            if (ID is null) return new TDomain();
            var d = await GetData(ID);
            var obj = new TDomain
            {
                Data = d
            };
            return obj;

        }

        protected abstract Task<TData> GetData(string id);

        public async Task Delete(string ID)
        { 
            if (ID is null) return; 
            var v = await dbSet.FindAsync(ID);
            if (v is null) return;
            dbSet.Remove(v); 
            await db.SaveChangesAsync();
        }

        public async Task Add(TDomain obj)
        {
            if (obj?.Data is null) return;
            dbSet.Add(obj.Data);
            await db.SaveChangesAsync();
        }

        public async Task Update(TDomain obj)
        {
            db.Attach(obj.Data).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!MeasureViewExists(MeasureView.ID))
                //{
                //     return NotFound();
                //}
                //else
                //{
                throw;
                // }
            }

        }
    }
}
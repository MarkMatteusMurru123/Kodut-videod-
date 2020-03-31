using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        protected internal DbContext Db;
        protected internal DbSet<TData> DbSet;


        protected BaseRepository(DbContext c, DbSet<TData> s)
        {
            Db = c;
            DbSet = s;
        }
        public virtual async Task<List<TDomain>> Get()
        {
            var query = CreateSqlQuery(); //loome query
            var set = await RunSqlQueryAsync(query);
            return ToDomainObjectsList(set);
        }

        internal List<TDomain> ToDomainObjectsList(List<TData> set) => set.Select(ToDomainObject).ToList();
        

        protected internal abstract TDomain ToDomainObject(TData periodData);
        internal async Task<List<TData>> RunSqlQueryAsync(IQueryable<TData> query) => await query.AsNoTracking().ToListAsync();
        

        protected internal virtual IQueryable<TData> CreateSqlQuery()
        {
            var query = from s in DbSet select s; //tehakse sql päring
            return query;
        }

        public async Task<TDomain> Get(string id)
        {
            if (id is null) return new TDomain();
            var d = await GetData(id);
            var obj = new TDomain
            {
                Data = d
            };
            return obj;

        }

        protected abstract Task<TData> GetData(string id);

        public async Task Delete(string id)
        { 
            if (id is null) return; 
            var v = await DbSet.FindAsync(id);
            if (v is null) return;
            DbSet.Remove(v); 
            await Db.SaveChangesAsync();
        }

        public async Task Add(TDomain obj)
        {
            if (obj?.Data is null) return;
            DbSet.Add(obj.Data);
            await Db.SaveChangesAsync();
        }

        public async Task Update(TDomain obj)
        {
            if (obj is null) return;
            var v = await DbSet.FindAsync(GetId(obj));
            if (v is null) return;
            DbSet.Remove(v);
            DbSet.Add(obj.Data);
            await Db.SaveChangesAsync();

        }

        protected abstract string GetId(TDomain entity);

    }
}
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Abc.Data.Common;
using Abc.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infra
{
    public abstract class SortedRepository<TDomain, TData> : BaseRepository<TDomain, TData>, ISorting
        where TData : PeriodData, new()
        where TDomain : Entity<TData>, new()

    {
    public string SortOrder { get; set; }
    public string DescendingString => "_desc";

    protected SortedRepository(DbContext c, DbSet<TData> s) : base(c, s)
    {
    }

    protected internal IQueryable<TData> SetSorting(IQueryable<TData> data)
    {
        var expression = CreateExpression();
        if (expression is null) return data;
        return SetOrderBy(data, expression);

    }

    internal Expression<Func<TData, object>> CreateExpression()
    {
        var property = FindProperty();
        if (property is null) return null;
        return LambdaExpression(property);
    }

    internal Expression<Func<TData, object>> LambdaExpression(PropertyInfo p)
    {
        var param = Expression.Parameter(typeof(TData));
        var property = Expression.Property(param, p);
        var body = Expression.Convert(property, typeof(object));
        return Expression.Lambda<Func<TData, object>>(body, param);


    }

    internal PropertyInfo FindProperty()
    {
        var name = GetName();
        return typeof(TData).GetProperty(name);
    }

    internal string GetName()
    {
        if (string.IsNullOrEmpty(SortOrder)) return string.Empty;
        var idx = SortOrder.IndexOf(DescendingString, StringComparison.Ordinal);
        if (idx > 0) return SortOrder.Remove(idx);
        return SortOrder;
    }
    //kirjutab sql lause, milles on sortimine sees

    internal IQueryable<TData> SetOrderBy(IQueryable<TData> data, Expression<Func<TData, object>> e)
        => IsDescending() ? data.OrderByDescending(e) : data.OrderBy(e);


    internal bool IsDescending()
    {
        return SortOrder.EndsWith(DescendingString);
    }
    }
}   
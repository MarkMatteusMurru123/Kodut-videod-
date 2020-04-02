using System;
using Abc.Aids;
using Abc.Data.Common;
using Abc.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Infra
{
    [TestClass]
    public abstract class RepositoryTests<TRepository, TObject, TData>
        : BaseTests
        where TRepository : IRepository<TObject>
        where TObject : Entity<TData>
        where TData : PeriodData, new()

    {
    private TData _data;
    protected TRepository Obj;

    public virtual void TestInitialize()
    {
        Type = typeof(TRepository);
        _data = GetRandom.Object<TData>(); //loon objekti
    }

    [TestMethod] public void IsSealedTest() => Assert.IsTrue(Type.IsSealed);
    [TestMethod] public void IsInheritedTest() => Assert.AreEqual(GetBaseType().Name, Type?.BaseType?.Name);
    protected abstract Type GetBaseType();

    [TestMethod] public void GetTest()=>TestGetList();
    protected abstract void TestGetList();
    [TestMethod] public void GetByIdTest()=>AddTest();

    [TestMethod]
    public void DeleteTest()
    {
        AddTest();
        var id = GetId(_data);
        var expected = Obj.Get(id).GetAwaiter().GetResult();
        TestArePropertyValuesEqual(_data, expected.Data);
        Obj.Delete(id).GetAwaiter();
        expected = Obj.Get(id).GetAwaiter().GetResult(); //vastandtehe addiga.
        Assert.IsNull(expected.Data);


    }

    protected abstract string GetId(TData d);

    [TestMethod]
    public void AddTest()
    {
        var id = GetId(_data);
        var expected = Obj.Get(id).GetAwaiter().GetResult(); //andmebaasist measure objekt kätte id järgi
        Assert.IsNull(expected.Data);
        Obj.Add(GetObject(_data)).GetAwaiter(); //Lisan measureobjekti andmebaasi, enam pole null.
        expected = Obj.Get(id).GetAwaiter().GetResult(); //andmebaasist measure objekt kätte
        TestArePropertyValuesEqual(_data, expected.Data);
    }

    protected abstract TObject GetObject(TData d);

    [TestMethod]
    public void UpdateTest()
    {
        AddTest();
        var id = GetId(_data);
        var newData = GetRandom.Object<TData>(); //loob uue randomi.
        SetId(newData,id);
        Obj.Update(GetObject(newData)).GetAwaiter();
        var expected = Obj.Get(id).GetAwaiter().GetResult();
        TestArePropertyValuesEqual(newData, expected.Data);
    }

    protected abstract void SetId(TData d, string id);
    }
    
    
}

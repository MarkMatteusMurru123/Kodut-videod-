using System;
using System.Collections.Generic;
using System.Linq;
using Abc.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests
{
    public abstract class BaseTest<TClass, TBaseClass>
    {
        private const string NotTested = "<{0}> is not tested";
        private const string NotSpecified = "Clas is not specified"; 
        private List<string> members { get; set; }
        protected TClass obj;
        protected Type type;
       

        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(TClass);  
        }
        [TestMethod]
        public void IsInheritedTest()
        {
            Assert.AreEqual(typeof(TBaseClass), type.BaseType);
        }

        [TestMethod]
        public void IsTested()
        {
            if(type == null) Assert.Inconclusive(NotSpecified);
            var m = GetClass.Members(type, PublicBindingFlagsFor.DeclaredMembers);
            members = m.Select(e => e.Name).ToList();
            RemoveTested();
            if (members.Count == 0) return;
            Assert.Fail(NotTested, members[0]);
        }

        private void RemoveTested()
        {
            var tests = GetType().GetMembers().Select(e => e.Name).ToList();
            for (var i = members.Count; i > 0; i--)
            {
                var m = members[i - 1] + "Test";
                var isTested = tests.Find(o => o == m);
                if (string.IsNullOrEmpty(isTested)) continue;
                members.RemoveAt(i - 1);
            }
        }
        protected static void IsNullableProperty<T>(Func<T> get, Action<T> set)
        {
            IsProperty(get, set);   
            set(default);
            Assert.IsNull(get());
            //set(null);
            //Assert.IsNull(get());
        }
        protected static void IsProperty<T>(Func<T> get, Action<T> set)
        {
            var d = (T)GetRandom.Value(typeof(T));
            Assert.AreNotEqual(d, get());
            set(d);
            Assert.AreEqual(d, get());
            
        }

        protected static void IsReadOnlyProperty(object o, string name, object expected)
        {
            var property = o.GetType().GetProperty(name);
            Assert.IsNotNull(property);
            Assert.IsFalse(property.CanWrite);
            Assert.IsTrue(property.CanRead);
            var actual = property.GetValue(o);
            Assert.AreEqual(expected, actual);
        }
    }
}
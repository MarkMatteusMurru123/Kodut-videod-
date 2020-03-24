using System;
using System.Collections.Generic;
using System.Reflection;

namespace Abc.Aids {


    public static class CreateNew {
        public static T Instance<T>() {
            T Function() {
                var type = typeof(T);
                var instance = Instance(type);
                var value = (T) instance;
                return value;
            }
            var def = default(T);
            var result = Safe.Run(Function, def);
            return result;
        }
        public static object Instance(Type t) {
            return Safe.Run(() => {
                var constructor = GetFirstOrDefaultConstructorInfo(t);
                var parameters = constructor.GetParameters();
                var values = SetRandomParameterValues(parameters);
                return InvokeConstructor(constructor, values);
            }, null);
        }
        private static object InvokeConstructor(ConstructorInfo ci, object[] values) {
            return values.Length == 0 ? ci.Invoke(null) : ci.Invoke(values);
        }
        private static object[] SetRandomParameterValues(ParameterInfo[] parameters) {
            var values = new List<object>();
            foreach (var p in parameters) {
                var t = p.ParameterType;
                var value = GetRandom.Value(t);
                values.Add(value);
            }
            return values.ToArray();
        }
        private static ConstructorInfo GetFirstOrDefaultConstructorInfo(Type t) {
            var constructors = t.GetConstructors();
            return constructors.Length == 0 ? null : constructors[0];
        }
    }
}




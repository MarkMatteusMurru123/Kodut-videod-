
using System;

namespace Abc.Aids {
    public static class Safe {
        private static readonly object Key = new object();
        public static T Run<T>(Func<T> function, T valueOnExeption,
            bool useLock = false) {
            return useLock 
                ? LockedRun(function, valueOnExeption) 
                : Run(function, valueOnExeption);
        }
        public static void Run(Action action, bool useLock = false) {
            if (useLock) LockedRun(action);
            else Run(action);
        }

        private static T Run<T>(Func<T> function, T valueOnExeption) {
            try {
                return function(); 
            } catch (Exception e) {
                Log.Exception(e);
                return valueOnExeption;
            }
        }

        private static T LockedRun<T>(Func<T> function, T valueOnExeption) {
            lock (Key) { return Run(function, valueOnExeption); }
        }
        private static void Run(Action action) {
            try { action(); } catch (Exception e) { Log.Exception(e); }
        }
        private static void LockedRun(Action action) {
            lock (Key) { Run(action); }
        }
    }
}



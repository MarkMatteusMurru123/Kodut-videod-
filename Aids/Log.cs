using System;

namespace Abc.Aids {

    public static class Log {
        internal static ILogBook LogBook;

        public static void Message(string message) {
            LogBook?.WriteEntry(message);
        }

        public static void Exception(Exception e) {
            LogBook?.WriteEntry(e);
        }
    }

}




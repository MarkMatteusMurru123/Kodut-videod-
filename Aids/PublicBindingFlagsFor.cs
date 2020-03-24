using System.Reflection;

namespace Abc.Aids {

    public static class PublicBindingFlagsFor {
        private const BindingFlags p = BindingFlags.Public;
        private const BindingFlags i = BindingFlags.Instance;
        private const BindingFlags s = BindingFlags.Static;
        private const BindingFlags d = BindingFlags.DeclaredOnly;
        public const BindingFlags allMembers = p | i | s;
        public const BindingFlags instanceMembers = p | i;
        public const BindingFlags staticMembers = p | s;
        public const BindingFlags declaredMembers = p | d | i | s;
    }

}





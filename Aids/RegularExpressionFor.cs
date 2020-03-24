
namespace Abc.Aids {
    public static class RegularExpressionFor {
        public const string englishCapitalsOnly = @"^[A-Z]+[A-Z]*$";
        public const string englishTextOnly = @"^[A-Z]+[a-zA-Z""'\s-]*$";
        public const string englishCapitalsAndNumbersOnly = @"^[A-Z]+[A-Z,0-9]*$";
    }
}


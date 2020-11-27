namespace MoneyToWordConversion.Common
{
    public static class MoneyUtilities
    {
        public static string[] NumbersToWordsUpto20 = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight",
        "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen", "Twenty"};

        public static string[] MultipleOfTenInWords = { "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty",
            "Ninety","Hundred"};

        public static string HundredString = " Hundred";
        public static string ThousandString = " Thousand";
        public static string MillionString = " Million";

        public static int[] Denominators = { 1000000, 1000 };
        public static int[] HundredDenominators = { 100, 10 };
    }
}

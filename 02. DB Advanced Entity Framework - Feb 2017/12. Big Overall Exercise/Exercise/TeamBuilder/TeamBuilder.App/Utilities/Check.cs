namespace TeamBuilder.App.Utilities
{
    using System;

    public static class Check
    {
        public static void CheckLenght(int expectedLenght, string[] array)
        {
            if (expectedLenght != array.Length)
            {
                throw new FormatException(Constants.ErrorMessages.InvalidArgumentsCount);
            }
        }
    }
}
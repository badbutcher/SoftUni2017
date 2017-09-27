namespace _007.Logic
{
    public static class TagTransformer
    {
        public static string Transform(string tag)
        {
            var result = tag.Replace(" ", string.Empty);

            if (!result.StartsWith("#"))
            {
                result = "#" + result;
            }

            if (result.Length > 20)
            {
                result = result.Substring(0, 20);
            }

            return result;
        }
    }
}
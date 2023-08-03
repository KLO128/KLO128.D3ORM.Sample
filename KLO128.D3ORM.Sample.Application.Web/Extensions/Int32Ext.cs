namespace KLO128.D3ORM.Sample.Application.Web.Extensions
{
    public static class Int32Ext
    {
        public static bool IsPowerOfTwo(this int number)
        {
            var pairModulo = (decimal)Math.Log2(number);
            return decimal.Truncate(pairModulo) == pairModulo;
        }
    }
}

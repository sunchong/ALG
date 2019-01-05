using System;
using System.Threading;

namespace StackDataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            int c = 0;
            int new_c = Interlocked.Increment(ref c);

        }

        void GetProduct()
        {
            BaseProduct p;
            string sourceCode;
            p = new Product();
            sourceCode = p.GetCode();
            sourceCode = Product.GetNewCode(sourceCode);
        }
    }

    public class BaseProduct
    {
        public string GetCode()
        {
            string maxCode = "001";
            return maxCode;
        }

        public virtual string Trim(string source)
        {
            return source.Trim();
        }
    }

    public class Product : BaseProduct
    {
        private static string _type = "PI";

        public override string Trim(string source)
        {
            return source.Replace(" ", string.Empty);
        }

        public static string GetNewCode(string parentCode)
        {
            string currentMaxCode = "001001001";
            string newCode = $"{parentCode}{currentMaxCode}";
            return newCode;

        }
    }

}

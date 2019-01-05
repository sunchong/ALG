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
    }
}

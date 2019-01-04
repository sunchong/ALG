using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ArrayDataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            // 数组连续的内存地址
            //Address();

            // 数组越界
            OverFlow();
        }

        private static void Address()
        {
            int index = 0;

            int[] arr = new int[3];
            arr.Reverse();

            for (; index < arr.Count(); index++)
            {
                arr[index] = 0;
                var ptr = Marshal.UnsafeAddrOfPinnedArrayElement(arr, index);
                Console.WriteLine($"arr[{index}]={arr[index]}  =>  {ptr}");
            }
        }

        unsafe private static void OverFlow()
        {
            int arr_count = 3;

            int index = 0;

            int* index_stack = &index;

            int* over_stack = stackalloc int[arr_count];

            for (; index <12 ; index++)
            {
                over_stack[index] = index;
                Console.WriteLine($"over_stack[index]={over_stack[index]}");
                Console.WriteLine(arr_count);
            }
            Console.ReadKey();
        }


    }
}

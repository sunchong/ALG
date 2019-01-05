using System;
using System.Collections;
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
            //Over();

            OutOfIndex();

            // .NET下的数组
            //CreateAbstractArray();

            //CreateArrayList();

            Console.ReadKey();

        }

        private static void Address()
        {
            Console.WriteLine("-------------------------------------");
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

        unsafe private static void Over()
        {
            Console.WriteLine("-------------------------------------");
            int total_break = 0;

            int arr_count = 3;

            

            Int32* index = stackalloc Int32[1];
            index[0] = 0;
            //index[0] = 1;

            //double* d = stackalloc double[1];
            //d[0] = 0.01;

            int* over_stack = stackalloc int[arr_count];

            for (; index[0] <= arr_count; index[0]++)
            {
                if (total_break >= 20)
                    break;

                over_stack[index[0]] = 0;

                Console.WriteLine($"【次数 {total_break}】>>> over_stack[{index[0]}]={over_stack[index[0]]}");
                Console.WriteLine($"index[0] = {index[0]}");                
                total_break++;

            }
        }

        unsafe private static void OutOfIndex()
        {
            int* i = stackalloc int[1];

            i[0] = 0;
            i[0] = 1;

            double* d = stackalloc double[1];
            d[0] = 0.01;


            int* a = stackalloc int[3];

            for (; i[0] <= 3; i[0]++)
            {

                a[i[0]] = 0;

                Console.WriteLine(i[0]);


                Console.WriteLine(a[i[0]]);
            }

        }

        private static void CreateAbstractArray()
        {
            Console.WriteLine("-------------------------------------");
            int index = 0;
            int[] int32_arr = new int[4];
            Console.WriteLine("int[] int32_arr = new int[4];");
            Console.WriteLine(int32_arr.GetType());
            foreach (var item in int32_arr)
            {
                Console.WriteLine($">>> arr[{index}]={item}");
                index++;
            }

            Console.WriteLine("-------------------------------------");

            index = 0;
            string[] string_arr = { "00", "01", "02" };
            Console.WriteLine("string[] string_arr = { \"00\",\"01\", \"02\" };");
            Console.WriteLine(string_arr.GetType());
            foreach (var item in string_arr)
            {
                Console.WriteLine($">>> string_arr[{index}]={item}");
                index++;
            }

            Console.WriteLine("-------------------------------------");

            // 0基数组
            index = 0;
            Array arr_0_instance = Array.CreateInstance(typeof(int), 4);
            Console.WriteLine("Array arr_0_instance = Array.CreateInstance(typeof(int), 4);");
            Console.WriteLine(arr_0_instance.GetType());
            foreach (var item in arr_0_instance)
            {
                Console.WriteLine($">>> arr_instance[{index}]={item}");
                index++;
            }

            Console.WriteLine("-------------------------------------");

            // 1基数组
            index = 0;
            Array arr_1_instance = Array.CreateInstance(typeof(int), new int[] { 0 }, new int[] { 1 });
            Console.WriteLine("Array arr_1_instance = Array.CreateInstance(typeof(int), new int[] { 0 }, new int[] { 1 });");
            Console.WriteLine(arr_1_instance.GetType());
            int arr_1_count = arr_1_instance.Length;
            for (int arr_1_index = 0; index < arr_1_count; arr_1_index++)
            {
                Console.WriteLine($">>> arr_1_instance[{arr_1_index}]={arr_1_instance.GetValue(arr_1_index)}");
            }

            Console.ReadKey();
        }

        private static void CreateArrayList()
        {
            ArrayList arrs = new ArrayList();
            arrs.Add("string");
            arrs.Add(0);
            arrs.Add(new int[] { 0, 1, 2 });

            foreach (var item in arrs)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}

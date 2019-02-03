using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("排序");
            int[] arrs = RandomItems();
            Stopwatch time = new Stopwatch();

            time.Start();
            BubbleSort(arrs);
            time.Stop();
            Console.WriteLine($"冒泡排序时间{time.Elapsed}");
            time.Reset();

            arrs = RandomItems();
            time.Start();
            InsertionSort(arrs);
            time.Stop();
            Console.WriteLine($"插入排序时间{time.Elapsed}");
            time.Reset();

            arrs = RandomItems();
            time.Start();
            SelectionSort(arrs);
            time.Stop();
            Console.WriteLine($"选择排序时间{time.Elapsed}");
            time.Reset();



            Console.ReadKey();

        }

        //排序 — 冒泡排序
        private static void BubbleSort(int[] source)
        {
            if (source.Length <= 1)
                return;

            bool isChanged = false;
            for (int i = 0; i < source.Length; i++)
            {
                for (int j = 0; j < source.Length - i - 1; j++)
                {
                    var left = source[j];
                    var right = source[j + 1];
                    Console.WriteLine("【比较】");
                    if (left <= right)

                        continue;

                    source[j] = right;
                    source[j + 1] = left;
                    isChanged = true;
                    Console.WriteLine("{交换}");
                }
                if (!isChanged)
                    break;
            }
            Printf(source);
        }

        //排序 — 插入排序
        private static void InsertionSort(int[] source)
        {
            if (source == null || source.Length <= 0)
                return;

            for (int i = 1; i < source.Length; i++)
            {// 未排序区
                var sorting = source[i];
                int j = i - 1;

                for (; j >= 0; j--)
                {// 已排序区

                    // 比较
                    if (sorting >= source[j])
                    {
                        break;
                    }

                    // 后移
                    source[j + 1] = source[j];
                }

                // 入坑
                source[j + 1] = sorting;
            }
            Printf(source);
        }

        //排序 — 选择排序
        private static void SelectionSort(int[] source)
        {
            if (source.Length <= 1)
                return;

            for (int i = 0; i < source.Length - 1; i++)
            {// 已排序
                var minIndex = i;
                
                for (int j = i+1; j < source.Length; j++)
                {//未排序

                    if (source[minIndex] > source[j])
                    {
                        minIndex = j;
                    }
                }
                if (i != minIndex)
                {
                    int tmp = source[i];
                    source[i] = source[minIndex];
                    source[minIndex] = tmp;
                }
            }

            Printf(source);
        }

        private static void Printf(int[] source)
        {
            foreach (int item in source)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>");
        }

        private static int[] RandomItems(int count=1000)
        {
            int[] arr =new int[count];

            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                arr[i] = random.Next();
            }

            return arr;
        }
    }
}

using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 11, 8, 3, 9, 7, 1, 2, 5 };
            MergrSortInternally(arr, 0, arr.Length - 1);

            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();

        }

        /// <summary>
        /// 递归调用
        /// </summary>
        /// <param name="a">原始数组</param>
        /// <param name="p">分割点</param>
        /// <param name="r">结束位置</param>
        public static void MergrSortInternally(int[] a, int p, int r)
        {
            //结束条件
            if (p >= r)
                return;

            //切割点
            int q = p + (r - p) / 2;

            //分而治之
            MergrSortInternally(a, p, q);

            MergrSortInternally(a, q + 1, r);

            //合并  A(a, p, q) 和  A(a, q + 1, r)          
            Merage(a, p, q, r);

        }

        /// <summary>
        /// 合并
        /// </summary>
        /// <param name="a">原始数组</param>
        /// <param name="p">起始点</param>
        /// <param name="q">切割点</param>
        /// <param name="r">结束点</param>
        public static void Merage(int[] a, int p, int q, int r)
        {
            // i 和 j = 两个数组的游标
            int i = p;
            int j = q + 1;

            // 临时数组的游标
            int k = 0;

            // 临时数组
            int[] temp = new int[r - p + 1];

            //最小入队，直到其中一个空空如也为止
            while (i <= q && j <= r)
            {
                if (a[i] <= a[j])
                {
                    temp[k] = a[i];
                    ++k;
                    ++i;
                }
                else
                {
                    temp[k] = a[j];
                    ++k;
                    ++j;
                }
            }

            // 找到另一个不为空的，找到剩下的元素
            int start = i;
            int end = q;

            if (j <= r)
            {
                start = j;
                end = r;
            }

            // 剩余数组拷贝到临时数组 temp
            while (start <= end)
            {
                temp[k++] = a[start++];
            }

            // 将temp覆盖到a[p...r]
            for (i = 0; i <= r - p; ++i)
            {
                a[p + i] = temp[i];
            }
        }
    }
}

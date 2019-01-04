using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALG
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;

            FormatWriteLineMsg("时间复杂度-常量阶: O(1)");
            N1(n);

            FormatWriteLineMsg("时间复杂度-线性阶: O(n)");
            N(n);

            FormatWriteLineMsg("时间复杂度-X方阶: O(n^x)");
            NxN(n);

            FormatWriteLineMsg("时间复杂度-对数阶: O(log n)");
            LogN(n);

            FormatWriteLineMsg("最好情况时间复杂度");
            string best = "8";
            Best_Worst_Avg_CaseTime(best);

            FormatWriteLineMsg("最坏情况时间复杂度");
            string worst = "10";
            Best_Worst_Avg_CaseTime(worst);

            FormatWriteLineMsg("平均情况时间复杂度");
            string avg = "6";
            Best_Worst_Avg_CaseTime(avg);

            Console.ReadKey();
        }

        /// <summary>
        /// 时间复杂度=O(1)
        /// </summary>
        /// <param name="n"></param>
        public static void N1(int n)
        {
            int i_index = 0;
            Console.WriteLine($"时间复杂度-常量阶-i ：{i_index + 1}");
        }

        /// <summary>
        /// 时间复杂度=O(n)
        /// </summary>
        /// <param name="n"></param>
        public static void N(int n)
        {
            int i_index = 0;

            for (; i_index < n; i_index++)
            {
                int num = i_index * 2;

                decimal sum = num + i_index;

                Console.WriteLine($"时间复杂度-线性阶-i ：{i_index + 1}");
            }
        }

        /// <summary>
        /// 时间复杂度=O(n^2)
        /// </summary>
        /// <param name="n"></param>
        public static void NxN(int n)
        {
            int i_index = 0;
            for (; i_index < n; i_index++)
            {
                int j_todo = 0;
                for (; j_todo < n; j_todo++)
                {
                    Console.WriteLine($"时间复杂度-X方阶 ：i*j ={i_index + 1} *{j_todo + 1}");
                }
            }
        }

        /// <summary>
        /// 时间复杂度=O(log n)
        /// </summary>
        /// <param name="n"></param>
        public static void LogN(int n)
        {
            double flag = 1;
            double step = 2;
            int forCount = 0;
            while (flag <= n)
            {
                forCount++;
                flag = flag * step;
                Console.WriteLine($"时间复杂度-对数阶：{forCount}   ==>   {step}^{Math.Log(flag, step)}");
            }
        }

        /// <summary>
        /// 最好/最坏情况时间复杂度
        /// </summary>
        /// <param name="search"></param>
        public static void Best_Worst_Avg_CaseTime(string search)
        {
            string source = "8,4,5,6,2,3,1,9,0,7";
            string[] data = source.Split(',').ToArray();
            Console.WriteLine($"Source ={source} | find =>{search}");
            Console.WriteLine();

            int count = data.Count();
            int search_index = -1;

            int i_index = 0;
            for (; i_index < count; i_index++)
            {
                Console.WriteLine($"todo：{i_index + 1}");
                if (search == data[i_index])
                {
                    search_index = i_index;
                    break;
                }
            }

            if (i_index == 0)
            {
                Console.WriteLine($">>>>>>>>>>>>>>>>>Best：O(1)");
                Console.WriteLine();
            }
            else
            {
                if (search_index == -1)
                {
                    Console.WriteLine($">>>>>>>>>>>>>>>>>Worst：O(n)");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($@">>>>>>>>>>>>>>>>>Other：
                        => O( 1+2+...+n+n / n+1 ) 
                        => O( 2n / n+1 ) 
                        => O(n)");

                    Console.WriteLine($@">>>>>>>>>>>>>>>>>Avg: 
                        =>O( 1*(1/n)*(1/2)+...n*(1/2n)+n*(1/2) ) 
                        => O( 3n/4 ) 
                        => O(n)");
                    Console.WriteLine();
                }
            }

        }

        /// <summary>
        /// 格式化展示
        /// </summary>
        /// <param name="msg"></param>
        private static void FormatWriteLineMsg(string msg)
        {
            Console.WriteLine();
            Console.WriteLine($"*****************{msg}********************");
        }
    }
}

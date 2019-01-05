using System;
using System.Collections.Generic;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> links = new LinkedList<string>();
            LinkedListNode<string> node1 = new LinkedListNode<string>("公共");
            LinkedListNode<string> node2 = new LinkedListNode<string>("共享");
            LinkedListNode<string> node3 = new LinkedListNode<string>("测试");
            LinkedListNode<string> node4 = new LinkedListNode<string>("产品");

            //节点串联
            links.AddFirst(node1);
            links.AddAfter(node1, node2);
            links.AddAfter(node2, node3);

            foreach (var link in links)
            {
                Console.WriteLine(link.ToString());
            }
            Console.ReadKey();
            
        }
    }
}

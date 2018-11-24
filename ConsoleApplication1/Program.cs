using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (!string.IsNullOrEmpty(Console.ReadLine()))
            {
                int[] arrInt = { 85, 86, 87, 88, 89, 90 };
                arrInt = arrInt.OrderBy(c => Guid.NewGuid()).ToArray<int>();
                foreach (var item in arrInt)
                {
                    Console.Write(item+"  ");
                }
                Console.WriteLine();
            }
            
            Console.ReadKey();
        }
    }
}

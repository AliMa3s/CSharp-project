using System;
using System.Collections.Generic;
using System.Globalization;

namespace ForTest {
    class Program {
        static void Main(string[] args) {
            Console.Write("Geef eerste num: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Geef tweede num: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.Write("Geef derde num: ");
            int num3 = int.Parse(Console.ReadLine());
            //Console.Write("Geef vierde num: ");
            //int num4 = int.Parse(Console.ReadLine());


            Console.WriteLine("Result of specified numbers {0},{1} and {2}·z is {3} and x·y + y·z is {4}\n\n",
                num1,num2,num3, ((num1+num2)*num3),(num1*num2+num2*num3));
        }
    }
}

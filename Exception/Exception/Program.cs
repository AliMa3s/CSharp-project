using System;
using System.Collections.Generic;

namespace Exceptions {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            Person p1 = new Person("Jan", "Jansens", 48);
            Person p2 = new Person("Janine", "Pieters", 42);
            Person p3 = new Person("Lowie", "Jansens", 18);
            List<Person> persons = new List<Person>() { p1, p2, p3 };

            ProcessAction pa = new ProcessAction(persons);
            Console.WriteLine("***************************************addKid*************");
            pa.doStuff("addKid");
            Console.WriteLine("***************************************updateAge*************");
            pa.doStuff("updateAge");
            Console.WriteLine("***************************************initFromString1*************");
            pa.doStuff("initFromString1");
            Console.WriteLine("***************************************initFromString2*************");
            pa.doStuff("initFromString2");
        }
    }
}
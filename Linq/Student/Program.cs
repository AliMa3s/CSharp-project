using System;
using System.Collections.Generic;
using System.Linq;

namespace Student {
    class Program {
        static void Main(string[] args) {
            showFilter1();
            showFilter2();
            //order1();
            //order2();
            //order3();
            //order4();
            //select1();
            //select2();
            select3();
            select4();
            select5();
        }

        public static List<Cursussen> c = new List<Cursussen>() {
        new Cursussen("Programmeren 1" , 6),
        new Cursussen("Web 1", 3),
        new Cursussen("Databank", 4),
        new Cursussen("Labo", 3),
        };


            public static List<Student> studentList = new List<Student>(){
            new Student() { studentId = 1, naam = "john", leeftijd = 18, cursussen = {c[0] } },
            new Student() { studentId = 2, naam = "Steven", leeftijd = 20, cursussen = {c[0], c[1] } },
            new Student() { studentId = 3, naam = "Bill", leeftijd = 22,cursussen = {c[0], c[2] } },
            new Student() { studentId = 4, naam = "Ram", leeftijd = 24,cursussen = {c[0], c[3], c[1] } },
            new Student() { studentId = 5, naam = "Ron", leeftijd = 25 }};

        public static void showFilter1() {
            Console.WriteLine("Filter1");
            var filteredResult = studentList.Where(s => s.leeftijd > 18 && s.naam.Length > 3);
                foreach (var std in filteredResult) {
                    Console.WriteLine(std.naam);
                }
            
        }
        public static void showFilter2() {
            Console.WriteLine("Filter 2");
            var filteredResult = studentList.Where((s, i) => {
                if (i % 2 == 0)//if its even element
                    return true;
                return false;
            });
        }

        public static  void order1() {
            Console.WriteLine("order 1");
            var stundsInAsOrder = studentList.OrderBy(s => s.naam);
            foreach (var x in stundsInAsOrder) {
                Console.WriteLine(x);
            }
            Console.WriteLine("------------------");
        }
        public static void order2() {
            Console.WriteLine("order 2");
            var stundsInAsOrder = studentList.OrderByDescending(s => s.naam);
            foreach (var x in stundsInAsOrder) {
                Console.WriteLine(x);
            }
            Console.WriteLine("------------------");
        }
        public static void order3() {
            Console.WriteLine("order 3");
            var stundsInAsOrder = studentList.OrderBy(s => s.leeftijd).ThenBy(s=>s.naam);
            foreach (var x in stundsInAsOrder) {
                Console.WriteLine(x);
            }
            Console.WriteLine("------------------");
        }
        public static void order4() {
            Console.WriteLine("order 4");
            var stundsInAsOrder = studentList.OrderBy(s => s.leeftijd).ThenBy(s => s.naam).Reverse();
            foreach (var x in stundsInAsOrder) {
                Console.WriteLine(x);
            }
            Console.WriteLine("------------------");
        }

        public static void select1() {
            Console.WriteLine("select1 ---------------");
            var sel = studentList.Select(s => s.naam);
            foreach (var x in sel) {
                Console.WriteLine(x);
            }
            Console.WriteLine("---------------");
        }
        public static void select2() {
            Console.WriteLine("select2 ---------------");
            var sel = studentList.Select(s => new { naam = s.naam, aantalCursussen = s.cursussen.Count()});
            foreach (var x in sel) {
                Console.WriteLine(x);
            }
            Console.WriteLine("---------------");
        }


        public static void select3() {
            Console.WriteLine("select3 ---------------");
            var sel = studentList.SelectMany(s => s.cursussen);
            foreach (var x in sel) {
                Console.WriteLine(x);
            }
            Console.WriteLine("---------------");
        }



        public static void select4() {
            Console.WriteLine("select4 ---------------");
            var sel = studentList.SelectMany(s => s.cursussen).Distinct();
            foreach (var x in sel) {
                Console.WriteLine(x);
            }
            Console.WriteLine("---------------");
        }

        public static void select5() {
            Console.WriteLine("select4 ---------------");
            var sel = studentList.SelectMany(s => s.cursussen, (Student, program)=> new { naam = Student.naam, cursusNaam = program});
            foreach (var x in sel) {
                Console.WriteLine(x);
            }
            Console.WriteLine("---------------");
        }

        public void group1() {
            Console.WriteLine("group1 -----------");
            var groupResult = studentList.GroupBy(s => s.leeftijd);
            Console.WriteLine(groupResult.GetType());
            foreach (var ageGroup in groupResult) {
                Console.WriteLine("Age Group: {0}", ageGroup.key); //Each group has a key
                foreach (Student s in ageGroup) { //Each group has a inner collection
                    Console.WriteLine("Student name: {0}", s.naam);
                }
            }
        }

    }
}


        


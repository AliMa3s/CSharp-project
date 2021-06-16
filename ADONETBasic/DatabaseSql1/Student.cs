using System;
using System.Collections.Generic;
using System.Text;

namespace ADONETsqlserver
{
    public class Student
    {
        public Student(string naam, Klas klas) {
            this.naam = naam;
            this.klas = klas;
            this.cursussen = new List<Cursus>();
        }

        public Student(int studentId, string naam, Klas klas) {
            this.studentId = studentId;
            this.naam = naam;
            this.klas = klas;
            this.cursussen = new List<Cursus>();
        }

        public int studentId { get; set; }
        public string naam { get; set; }
        public List<Cursus> cursussen { get; private set; }
        public Klas klas { get; set; }
        public void voegCursusToe(Cursus c) {
            cursussen.Add(c);
        }
        public void ShowStudent() {
            Console.WriteLine($"{studentId},{naam},{klas}");
            foreach (Cursus c in cursussen) {
                Console.WriteLine($"{c}");
            }
        }
    }
}

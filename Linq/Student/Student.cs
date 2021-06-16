using System;
using System.Collections.Generic;
using System.Text;

namespace Student {
   public class Student {
        public int studentId { get; set; }
        public string naam { get; set; }
        public int leeftijd { get; set; }
        public List<Cursussen> cursussen { get; set; }

        public Student() {
            this.studentId = studentId;
            this.naam = naam;
            this.leeftijd = leeftijd;
            this.cursussen = new List<Cursussen>();
        }


        

        public override string ToString() {
            return $"Student id: {studentId}, Studennaam {naam}, Age {leeftijd}";
        }
    }
}

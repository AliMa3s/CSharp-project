using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions {
    public class Person {
        public Person(string info) {
            string[] s = info.Split(';');
            firstname = s[0];
            lastname = s[1];
            age = Int16.Parse(s[2]);
        }
        public Person(string firstname, string lastname, int age) {
            this.firstname = firstname;
            this.lastname = lastname;
            this.age = age;
        }
        public string firstname { get; set; }
        public string lastname { get; set; }
        private int age { get; set; }
        public List<Person> kids { get; set; }
        public void addKid(Person p) {
            kids.Add(p);
        }
        public void initKidsList() {
            kids = new List<Person>();
        }
        public void UpdateAge(int age) {
            if (age < 0)
                throw new ArgumentException($"Age [{age}] can not be negative!");
            else
                this.age = age;
        }
    }
}

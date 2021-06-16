using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions {
    public class ProcessAction {
        public ProcessAction(List<Person> persons) {
            this.persons = persons;
        }

        public static void ShowExceptionDetails(Exception e) {
            Console.WriteLine("-----------");
            Console.WriteLine($"Type: {e.GetType()}");
            Console.WriteLine($"Source: {e.Source}");
            Console.WriteLine($"TargetSite: {e.TargetSite.GetType()}");
            Console.WriteLine($"Message: {e.Message}");
            Console.WriteLine("-----------");
        }
        private List<Person> persons { get; set; }
        public void doStuff(string actie) {
            try {
                switch (actie) {
                    case "addKid": persons[0].addKid(persons[2]); break;
                    case "updateAge": persons[0].UpdateAge(-5); break;
                    case "initFromString1": Person p1 = new Person("Greg;Van Avermaet,34"); break;
                    case "initFromString2": Person p2 = new Person("Greg;Van Avermaet;34q"); break;
                }
            } catch (ArgumentException ex) {
                Console.WriteLine("ArgumentException");
                ShowExceptionDetails(ex);
                Console.WriteLine(ex.Message);
            } catch (NullReferenceException ex) {
                Console.WriteLine("NullReferenceException");
                ShowExceptionDetails(ex);
                Console.WriteLine(ex.Message);
            } catch (Exception ex) {
                Console.WriteLine("Exception");
                ShowExceptionDetails(ex);
                Console.WriteLine(ex.Message);
            } finally {
                Console.WriteLine("Time to quit");
            }
        }
    }
}
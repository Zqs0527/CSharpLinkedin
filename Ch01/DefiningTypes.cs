using System;

namespace Ch01
{
    public interface IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public int Id {get; set;}
        public Age Age {get; set;}
    }

    public struct Age
    {
        public DateTime BirthDate {get; set;}
        public int YearOld {get;set;}
    }
    public class Employee: IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set ; }
        public Age Age { get; set; }

        public Employee()
        {

        }

        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = new Random().Next(1, 10);
        }
    }


    public class Manager: Employee,IPerson
    {
        public Manager(string firstName, string lastName):base(firstName, lastName)
        {

        }
        public int NumberOfDirectReports{get;set;}
    }

}
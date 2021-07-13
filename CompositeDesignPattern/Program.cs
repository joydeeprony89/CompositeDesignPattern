using System;
using System.Collections.Generic;

namespace CompositeDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            CompositeEmployee principle = new CompositeEmployee("Principle","College Trust");
            CompositeEmployee mathDept = new CompositeEmployee("Math HOD", "Math Dept");
            CompositeEmployee computerDept = new CompositeEmployee("Compoter HOD", "Computer Dept");

            Employee mathTeacher1 = new Employee("Math teacher 1", "Math Dept");
            Employee mathTeacher2 = new Employee("Math teacher 2", "Math Dept");

            Employee computerTeacher1 = new Employee("Computer teacher 1", "Computer Dept");
            Employee computerTeacher2 = new Employee("Computer teacher 2", "Computer Dept");
            Employee computerTeacher3 = new Employee("Computer teacher 3", "Computer Dept");

            principle.Add(mathDept);
            principle.Add(computerDept);

            mathDept.Add(mathTeacher1);
            mathDept.Add(mathTeacher2);

            computerDept.Add(computerTeacher1);
            computerDept.Add(computerTeacher2);
            computerDept.Add(computerTeacher3);

            Console.WriteLine("Printing individual employee");
            mathTeacher1.Print();
            computerTeacher2.Print();

            Console.WriteLine("Printing Empployee tree structure");
            principle.Print();

            Console.WriteLine("One of the employee from computer dept has left the college");
            computerDept.Remove(computerTeacher2);

            Console.WriteLine("Printing Empployee tree structure");
            principle.Print();
        }
    }


    public interface IEmployee
    {
        void Print();
    }

    // Teacher
    public class Employee : IEmployee
    {
        public string Name { get; set; }
        public string Dept { get; set; }
        public Employee(string Name, string Dept)
        {
            this.Name = Name;
            this.Dept = Dept;
        }
        public void Print()
        {
            Console.WriteLine($"I am {this.Name} and works for {this.Dept}");
        }
    }

    public class CompositeEmployee : IEmployee
    {
        public string Name { get; set; }
        public string Dept { get; set; }
        public List<IEmployee> Employees { get; set; }
        public CompositeEmployee(string Name, string Dept)
        {
            this.Name = Name;
            this.Dept = Dept;
            Employees = new List<IEmployee>();
        }
        public void Print()
        {
            Console.WriteLine($"Employee {this.Name} belongs to {this.Dept}");
            foreach(IEmployee employee in Employees)
            {
                employee.Print();
            }
        }

        public void Add(IEmployee employee)
        {
            Employees.Add(employee);
        }

        public void Remove(IEmployee employee)
        {
            Employees.Remove(employee);
        }
    }
}

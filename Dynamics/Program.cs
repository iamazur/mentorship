using System;

namespace Dynamics
{
    class Program
    {

        //Dynamic should be used only when not using it is painful.
        //Like in MS Office libraries.
        //In all other cases it should be avoided as compile type checking is beneficial.

        static void Main(string[] args)
        {
            dynamic x = 3; // x -> int
            Console.WriteLine($"{x} -> {x.GetType()}");

            x = "Hello world"; // x -> string
            Console.WriteLine($"{x} -> {x.GetType()}");

            x = new Person() { Name = "Tom", Age = 23, Salary = 100000 }; // x -> Person
            Console.WriteLine($"{x} -> {x.GetType()}");
            Console.WriteLine(x.FormatSalary("int"));

            dynamic p = new Person() { Name = "Bill", Age = 25, Salary = "One hundred" };
            Console.WriteLine($"{x} -> {x.GetType()}");
            Console.WriteLine(p.FormatSalary("string"));

            Console.ReadLine();
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public dynamic Salary { get; set; }

        public dynamic FormatSalary(string format)
        {
            if (format == "string")
            {
                return Salary + " USD";
            }
            else if (format == "int")
            {
                return Salary;
            }
            else
            {
                return 0.0;
            }
        }

        public override string ToString()
        {
            return Name + ", " + Age.ToString();
        }
    }
}

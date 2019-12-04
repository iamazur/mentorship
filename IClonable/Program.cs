using System;

namespace IClonable_TEST
{
    class X
    {
        public int a;
        public X(int x)
        { 
            a = x;
        }
    }

    class Test : ICloneable
    {
        public string Name { get; set; } = string.Empty;
        public X O { get; set; }
        public int B { get; set; }
        public Test(int x, int y)
        {
            O = new X(x);
            B = y;
        }
        public void Show()
        {
            Console.Write($"Object {Name} : ");
            Console.WriteLine($"o.a: {O.a}, b: {B}");
        }

        public object Clone()
        {
            Test temp = new Test(O.a, B);
            return temp;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Test ob1 = new Test(10, 20);
            ob1.Name = "ob1";
            ob1.Show();

            Console.WriteLine();
            Console.WriteLine("ob2 is a reference of ob1.");
            Test ob3 = ob1;
            ob3.Show();
            //ob3.Name = "ob3";

            Console.WriteLine();
            Console.WriteLine("ob2 is a copy of ob1.");
            Test ob2 = (Test)ob1.Clone();
            ob2.Show();
            ob2.Name = "ob2";
            ob2.Show();

            Console.WriteLine();
            Console.WriteLine("Change ob1.о.а to 99, and ob1.b — 88.");
            ob1.O.a = 99;
            ob1.B = 88;
            ob1.Show();
            ob2.Show();
            ob3.Show();

            Console.ReadKey();
        }
    }
}

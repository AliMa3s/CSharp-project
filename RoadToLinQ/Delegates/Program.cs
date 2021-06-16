using System;

namespace Delegates {
    class Program {
        public delegate double MathFunction(double value1, double value2);
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            double x = 12.0;
            double y = 7.5;
            MathFunction DoStuff = Plus;


            Console.WriteLine($"x={x},y={y},function result={Plus(x, y)}");
            Console.WriteLine($"x={x},y={y},function result={DoStuff(x, y)}");

            DoStuff = new MathFunction(Min); //assignment syntax 2
            Console.WriteLine($"x={x},y={y},function result={DoStuff(x, y)}");

            DoStuff = new MathFunction(Maal);
            Console.WriteLine($"x={x},y={y},function result={DoStuff.Invoke(x, y)}"); //invoking delegate

            //delegate as parameter
            Console.WriteLine($"x={x},y={y},function result={Bereken(Deel, x, y)}");



        }
        public static double Plus(double a, double b) {
            Console.WriteLine($"Plus: {a},{b}");
            return a + b;
        }
        public static double Min(double a, double b) {
            Console.WriteLine($"Min: {a},{b}");
            return a - b;
        }
        public static double Maal(double a, double b) {
            Console.WriteLine($"Maal: {a},{b}");
            return a * b;
        }
        public static double Deel(double a, double b) {
            Console.WriteLine($"Deel: {a},{b}");
            return a / b;
        }

        public static double Bereken(MathFunction f, double x, double y) {
            return f(x, y);
        }
    }
}

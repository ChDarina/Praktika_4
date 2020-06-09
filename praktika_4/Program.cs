using System;

namespace praktika_4
{
    class Program
    {
        static public double InputNumber(string ForUser)
        {
            bool ok = true;
            double number = 0;
            do
            {
                Console.WriteLine(ForUser);
                try
                {
                    string buf = Console.ReadLine();
                    number = Convert.ToDouble(buf);
                    ok = false;
                }
                catch
                {
                    Console.WriteLine("Неверный ввод числа!");
                }
            } while (ok);
            return number;
        }
        static double Function(double x)
        {
            return (2 * Math.Pow(Math.Sin(x), 2)) / 3 - (3 * Math.Pow(Math.Cos(x), 2)) / 4;
        }
        static double Del(ref double x0, ref double x1)
        {
            double x2 = (x0 + x1) / 2;
            if (Function(x2) * Function(x0) <= 0) x1 = x2;
            else x0 = x2;
            return x2;
        }
        static void Main(string[] args)
        {
            double e = InputNumber("Введите погрешность e:");
            double left = 0;
            double right = Math.PI / 2;
            double center = (left + right) / 2;
            do
            {
                center = Del(ref left, ref right);
            } while (Math.Abs(Function(center)) >= e);
            Console.WriteLine("Приближенное значение выражения = " + center);
            Console.ReadKey();
        }
    }
}

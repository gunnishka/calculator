using System;

namespace Calculator
{
    class Program
    {
        private static double memory = 0;

        static void Main(string[] args)
        {
            string value;
            do
            {
                double result = 0;
                double num1, num2;

                Console.Write("Введите операцию: ");
                string oper = Console.ReadLine();

                switch (oper)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "%":
                    case "/":
                        Console.Write("Введите первое число: ");
                        num1 = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Введите второе число: ");
                        num2 = Convert.ToDouble(Console.ReadLine());
                        result = BinaryOperation(num1, num2, oper);
                        break;

                    case "1/x":
                    case "x^2":
                    case "sqrt":
                        Console.Write("Введите число: ");
                        num1 = Convert.ToDouble(Console.ReadLine());
                        result = UnaryOperation(num1, oper);
                        break;

                    case "M+":
                        Console.Write("Введите число для добавления в память: ");
                        num1 = Convert.ToDouble(Console.ReadLine());
                        memory += num1;
                        Console.Write("Значение было добавлено в память. Текущая память:", memory);
                        break;

                    case "M-":
                        Console.Write("Введите число для вычитания из памяти: ");
                        num1 = Convert.ToDouble(Console.ReadLine());
                        memory += num1;
                        Console.Write("Значение было вычтено из памяти. Текущая память:", memory);
                        break;

                    case "MR":
                        result = memory;
                        Console.Write("Память:", memory);
                        break;

                    default:
                        Console.Write("Неизвестная операция ");
                        result = 0;
                        break;
                }

                if (oper != "M+" && oper != "M-")
                {
                    Console.Write($"Ваш результат: {result} \n");
                }
                Console.Write("Хотите продолжить? (y/n): ");
                value = Console.ReadLine();
            }

            while (value == "y" || value == "Y");
        }

        static double BinaryOperation(double a, double b, string oper)
        {
            return oper switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
                "/" => CheckDivision(a, b),
                "%" => a * b / 100,
                _ => 0
            };
        }

        static double UnaryOperation(double a, string oper)
        {
            return oper switch
            {
                "1/x" => CheckReciprocal(a),
                "x^2" => Math.Pow(a, 2),
                "root" => CheckSquareRoot(a),
                _ => 0
            };
        }

        static double CheckDivision(double a, double b)
        {
            if (b != 0)
            {
                return a / b;
            }
            Console.Write("Делить на ноль нельзя! ");
            return 0;
        }

        static double CheckReciprocal(double a)
        {
            if (a != 0)
            {
                return 1 / a;
            }
            Console.Write("На ноль делить нельзя! ");
            return 0;
        }

        static double CheckSquareRoot(double a)
        {
            if (a >= 0)
            {
                return Math.Sqrt(a);
            }
            Console.Write("Квадратный корень из отрицательного числа невозможен ");
            return 0;
        }
    }
}
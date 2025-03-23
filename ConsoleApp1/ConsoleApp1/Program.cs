using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nВиберіть опцію:");
            Console.WriteLine("1 - Обчислення середнього заробітку");
            Console.WriteLine("2 - Побудова графіку зірочками");
            Console.WriteLine("3 - Генерація простих чисел");
            Console.WriteLine("4 - Перевірка паролю");
            Console.WriteLine("5 - Генерація фібоначчівської послідовності");
            Console.WriteLine("6 - Калькулятор оплати праці за годину");
            Console.WriteLine("7 - Генерація таблиці множення");
            Console.WriteLine("8 - Перевірка на простоту");
            Console.WriteLine("0 - Вихід");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 8)
            {
                Console.WriteLine("Невірний вибір. Спробуйте знову.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CalculateAverageSalary();
                    break;
                case 2:
                    StarChart();
                    break;
                case 3:
                    GeneratePrimes();
                    break;
                case 4:
                    PasswordCheck();
                    break;
                case 5:
                    FibonacciSequence();
                    break;
                case 6:
                    HourlyWageCalculator();
                    break;
                case 7:
                    MultiplicationTable();
                    break;
                case 8:
                    PrimeCheck();
                    break;
                case 0:
                    Console.WriteLine("Вихід із програми.");
                    return;
                default:
                    Console.WriteLine("Невірний вибір.");
                    break;
            }
        }
    }

    static void CalculateAverageSalary()
    {
        List<double> salaries = new List<double>();
        while (true)
        {
            Console.Write("Введіть зарплату працівника (або 'стоп' для завершення): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "стоп")
                break;
            if (double.TryParse(input, out double salary))
                salaries.Add(salary);
            else
                Console.WriteLine("Будь ласка, введіть число.");
        }

        double average = salaries.Count > 0 ? salaries.Average() : 0;
        Console.WriteLine($"Середній заробіток: {average:F2}");
    }

    static void StarChart()
    {
        Console.Write("Введіть кількість рядків графіка: ");
        if (int.TryParse(Console.ReadLine(), out int rows))
        {
            for (int i = 1; i <= rows; i++)
            {
                Console.WriteLine(new string('*', i));
            }
        }
        else
        {
            Console.WriteLine("Будь ласка, введіть ціле число.");
        }
    }

    static void GeneratePrimes()
    {
        Console.Write("Введіть число: ");
        if (int.TryParse(Console.ReadLine(), out int limit))
        {
            for (int num = 2; num <= limit; num++)
            {
                bool isPrime = true;
                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                    Console.WriteLine(num);
            }
        }
        else
        {
            Console.WriteLine("Будь ласка, введіть ціле число.");
        }
    }

    static void PasswordCheck()
    {
        Console.Write("Введіть пароль: ");
        string password = Console.ReadLine();

        bool isValid = password.Length >= 8 &&
                       Regex.IsMatch(password, @"\d") &&
                       Regex.IsMatch(password, @"[!@#$%^&*]");

        Console.WriteLine(isValid ? "Пароль прийнятний" : "Пароль не прийнятний");
    }

    static void FibonacciSequence()
    {
        Console.Write("Введіть кількість чисел Фібоначчі: ");
        if (int.TryParse(Console.ReadLine(), out int n))
        {
            int a = 0, b = 1;

            Console.WriteLine(a);
            if (n > 1) Console.WriteLine(b);

            for (int i = 2; i < n; i++)
            {
                int next = a + b;
                Console.WriteLine(next);
                a = b;
                b = next;
            }
        }
        else
        {
            Console.WriteLine("Будь ласка, введіть ціле число.");
        }
    }

    static void HourlyWageCalculator()
    {
        Console.Write("Кількість годин за день: ");
        if (double.TryParse(Console.ReadLine(), out double hours))
        {
            Console.Write("Розмір годинної ставки: ");
            if (double.TryParse(Console.ReadLine(), out double rate))
            {
                double dailyPay = hours * rate;
                Console.WriteLine($"Оплата за день: {dailyPay:F2}");
            }
            else
            {
                Console.WriteLine("Будь ласка, введіть коректне значення для ставки.");
            }
        }
        else
        {
            Console.WriteLine("Будь ласка, введіть коректне значення для годин.");
        }
    }

    static void MultiplicationTable()
    {
        Console.Write("Введіть число: ");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{number} x {i} = {number * i}");
            }
        }
        else
        {
            Console.WriteLine("Будь ласка, введіть ціле число.");
        }
    }

    static void PrimeCheck()
    {
        Console.Write("Введіть число: ");
        if (int.TryParse(Console.ReadLine(), out int num))
        {
            bool isPrime = num > 1;

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            Console.WriteLine(isPrime ? "Число просте" : "Число не просте");
        }
        else
        {
            Console.WriteLine("Будь ласка, введіть ціле число.");
        }
    }
}

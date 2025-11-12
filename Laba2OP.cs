using System;

namespace Laba2_Var1
{
    class Program
    {
        static void Main()
        {
            int choice;
            bool Exitprog = false;

            while (!Exitprog)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Отгадай ответ");
                Console.WriteLine("2. Об авторе");
                Console.WriteLine("3. Выход");

                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Ошибка ввода. Введите число от 1 до 3.");
                }

                switch (choice)
                {
                    case 1:
                        MainGame();
                        break;
                    case 2:
                        Showinfo();
                        break;
                    case 3:
                        Exitprog = Exit();
                        break;
                }
            }
        }

        static void MainGame()
        {
            Console.Clear();
            double a = 0, b = 0;
            int attempts = 3;
            bool correct = false;

            Console.WriteLine("Добро пожаловать в игру: <Отгадай ответ>");
            Console.Write("Введите значение a: ");
            while (!double.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Ошибка ввода. Введите число.");
                Console.Write("Введите значение a: ");
            }
            Console.Write("Введите значение b: ");
            while (!double.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Ошибка ввода. Введите число.");
                Console.Write("Введите значение b: ");
            }

            if (a == b)
            {
                Console.WriteLine("Ошибка! Значения a и b не должны быть равны.");
                Console.WriteLine("Нажмите любую клавишу, чтобы вернуться обратно в меню");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            double result = Calculate(a, b);
            while (attempts > 0 && !correct)

            {
                double otvet;
                Console.Write($"Введите ваш ответ (осталось попыток: {attempts}): ");
                while (!double.TryParse(Console.ReadLine(), out otvet))
                {
                    Console.WriteLine("Ошибка ввода. Введите число.");
                    Console.Write("Введите ваш ответ: ");
                }

                if (Math.Round(otvet, 2) == Math.Round(result, 2))
                {
                    Console.WriteLine("Ответ верный!");
                    correct = true;
                }
                else
                {
                    Console.WriteLine("Ответ неверный.");
                    attempts--;
                }
            }

            if (!correct)
            {
                Console.WriteLine($"Вы проиграли. Правильный ответ: {Math.Round(result, 2)}");
            }
        }

        static double Calculate(double a, double b)
        {
            return Math.Pow(Math.Log(b), 2) / (Math.Cos(a) - 1);
        }

        static void Showinfo()
        {
            Console.Clear();
            Console.WriteLine("Об авторе:");
            Console.WriteLine("ФИО: Попович Егор Дмитриевич");
            Console.WriteLine("Группа: 6105-090301D");
            Console.Write("---Для выхода в меню нажмите любую клавишу...---");
            Console.ReadKey();
            Console.Clear();
        }

        static bool Exit()
        {
            int attempt = 3;
            Console.Clear();
            while (attempt >= 0)
            {
                Console.Write("Вы уверены, что хотите выйти? Введите <д> или <н>: ");
                string input = Console.ReadLine().ToLower();
                if (input != "д" && input != "н")
                {
                    Console.WriteLine("Ошибка ввода. Введите 'д' или 'н'.");
                }

                if (input == "д")
                {
                    return true;
                }

                else if (input == "н")
                {
                    Console.Clear();
                    Console.WriteLine("Выход отменен");
                    return false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Ошибка, у вас осталось {attempt} попытки");
                    attempt--;
                }
            }

            Console.WriteLine("Превышено количество попыток. Нажмите любую клавишу для выхода...");
            Console.ReadKey();
            Console.Clear();
            return false;
        }
    }
}
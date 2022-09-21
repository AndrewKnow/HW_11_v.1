using System;

namespace ДЗ_11_v._1
{
    class Program
    {
        static void Main()
        {

            var dictionary = new OtusDictionary();


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Ошибки ввода:");
            Console.ResetColor();
            dictionary.Add(1, null);
            dictionary.Add(59, "59 текст");
            dictionary.Add(2, "2 текст");
            dictionary.Add(1, "1 текст");
            dictionary.Add(32, "32 текст");
            dictionary.Add(3, "3 текст");
            dictionary.Add(33, "33 текст");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Проверка по ключам:");
            Console.ResetColor();
            Console.WriteLine(dictionary.Get(59));
            Console.WriteLine(dictionary.Get(100));
            Console.WriteLine(dictionary.Get(1));
            Console.WriteLine(dictionary.Get(2));
            Console.WriteLine(dictionary.Get(3));
            Console.WriteLine(dictionary.Get(4));
            Console.WriteLine(dictionary.Get(32));
            Console.WriteLine(dictionary.Get(33));

        }
    }
}

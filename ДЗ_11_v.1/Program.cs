using System;

namespace ДЗ_11_v._1
{
    class Program
    {
        static void Main()
        {

            var dictionary = new OtusDictionary();

            Console.WriteLine("Ввод:");

            dictionary.Add(1, null);
            dictionary.Add(3, "3 текст");
            dictionary.Add(2, "2 текст");
            dictionary.Add(1, "1 текст");
            dictionary.Add(4, "4 текст");
            dictionary.Add(5, "5 текст");
            dictionary.Add(8, "8 текст");
            dictionary.Add(6, "6 текст");
            dictionary.Add(7, "7 текст");


            Console.WriteLine("Проверка по ключам:");

            Console.WriteLine(dictionary.Get(1));
            Console.WriteLine(dictionary.Get(2));
            Console.WriteLine(dictionary.Get(3));
            Console.WriteLine(dictionary.Get(4));
            Console.WriteLine(dictionary.Get(33));
            Console.WriteLine(dictionary.Get(34));
            Console.WriteLine(dictionary.Get(35));
            Console.WriteLine(dictionary.Get(200));
            //dictionary.ArrEnum();




        }
    }
}

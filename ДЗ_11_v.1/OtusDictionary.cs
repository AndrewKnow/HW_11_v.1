using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ_11_v._1
{
    public class OtusDictionary
    {
        int sizeArr = 32;
        DictArr[] dictArr;

        public const int MaxValue = int.MaxValue;
        public const int MinValue = int.MinValue;

        public OtusDictionary()
        {
            dictArr = new DictArr[sizeArr];
        }

        class DictArr
        {
            public int Key { get; set; }
            public string Value { get; set; }
        }

        int GetHashCode(int key)
        {
            int hashKey = key % sizeArr;
            return hashKey;
        }

        public void Add(int key, string value)
        {
            try
            { 
                if (value == null) 
                    throw new ArgumentNullException(nameof(value));

                int hashKey = GetHashCode(key);

                if (dictArr[hashKey] != null)
                {
                    dictArr = IncreaseArr(sizeArr);
                }
                dictArr[key % sizeArr] = new DictArr { Key = key, Value = value };
            }
            catch (ArgumentNullException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Пустое значение value с ключом {key}");
                Console.ResetColor();
            }
        }

       public string Get(int key)
       {
           int hashKey = GetHashCode(key);
           if (dictArr[hashKey] == null)
           {
               return $"Запись с ключом {key} не существет";
           }
           else
           {
               return $"Key: {dictArr[hashKey].Value} Value:{dictArr[hashKey].Value}";
           }
       }

        DictArr[] IncreaseArr(int size)
        {
            try
            {
                sizeArr = size * 2 + 1;

                if (sizeArr >= MaxValue || sizeArr <= MinValue)
                    throw new ArgumentOutOfRangeException();

                var increaseArr = new DictArr[sizeArr];

                foreach (var dict in dictArr)
                {
                    if (dict == null)
                    {
                        continue;
                    }
                    increaseArr[dict.Key % sizeArr] = new DictArr { Key = dict.Key, Value = dict.Value };
                }

                return increaseArr;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Превышен размер хэш функции");
                Console.ResetColor();
            }
            return null;
        }

        public string this[int key]
        {
            get => Get(key);
            set => Add(key, value);
        }
    }
}


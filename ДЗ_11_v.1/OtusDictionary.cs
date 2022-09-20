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

        public OtusDictionary()
        {
            dictArr = new DictArr[sizeArr];
        }

        class DictArr
        {
            public int Key { get; set; }
            public string Value { get; set; }
        }

        public void Add(int key, string value)
        {
            try
            {
                if (value == null) 
                    throw new ArgumentNullException(nameof(value));

                int hashKey = key % sizeArr;

                if (hashKey == 0)
                {
                    dictArr = IncreaseArr(sizeArr);
                }

                if (dictArr[key] != null)
                {
                    dictArr = IncreaseArr(sizeArr);
                    throw new ArgumentOutOfRangeException(nameof(key));
                }
                else
                {
                    dictArr[hashKey] = new DictArr() { Key = key, Value = value };
                }
            }

            catch (ArgumentNullException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Пустое значение value с ключом {key}");
                Console.ResetColor();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Запись с ключом {key} существет");
                Console.ResetColor();
            }
        }
        public string СheckingNullKey(int key)
        {
            try
            {
                if (dictArr[key] != null)
                {
                    return dictArr[key].Value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(key));
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Запись с ключом {key} не существет");
                Console.ResetColor();
            }
            return null;
        }

        public string Get(int key)
        {
            int hashKey = key % sizeArr;
            try
            {
                if (dictArr.Length < key)
                    throw new ArgumentOutOfRangeException(nameof(key));

                СheckingNullKey(key);

                if (dictArr[hashKey] != null)
                {
                    return $"key: {dictArr[hashKey].Key} value: {dictArr[hashKey].Value}";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Запись с ключом {key} не существет");
                Console.ResetColor();
            }
            return null;
        }

        DictArr[] IncreaseArr(int size)
        {
            sizeArr = size * 2;
            var increaseArr = new DictArr[sizeArr];

            int hashKey;

            for (int i = 0; i < dictArr.Length; i++)
            {
                if (dictArr[i] != null)
                {
                    hashKey = dictArr[i].Key;
                    if (increaseArr[hashKey] != null)
                    {
                        IncreaseArr(size);
                    }
                    increaseArr[hashKey] = dictArr[i];
                }
            }
            return increaseArr;
        }

        public string this[int key]
        {
            get => Get(key);
            set => Add(key, value);
        }
    }
}


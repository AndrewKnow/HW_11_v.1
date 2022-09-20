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
                {
                    throw new MyExp1();
                }
                // Ограничение индексов размером массива
                int hashKey = key % sizeArr;

                if (dictArr[hashKey] != null)
                {
                    // увелчиение массива
                    dictArr = IncreaseArr(sizeArr);
                    throw new MyExp2();
                }

                dictArr[hashKey] = new DictArr() { Key = key, Value = value };

            }
            catch (MyExp1)
            {
                Console.WriteLine("Пустое значение value");
            }
            catch (MyExp2)
            {
                Console.WriteLine($"Запись с ключом {key % sizeArr} существет, массив увеличен");
            }

        }
        public string Get(int key)
        {

            int hashKey = key % sizeArr;

            try
            {
                if (dictArr[hashKey] == null)
                {
                    throw new MyExp3();
                }
                if (dictArr[hashKey] != null)
                {
                    return $"key: {dictArr[hashKey].Key} value: {dictArr[hashKey].Value}";
                }
            }
            catch (MyExp3)
            {
                Console.WriteLine($"Ключ {hashKey} не надйен");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Ключ {hashKey} за рамками дипазона");
            }

            return null;
        }

        DictArr[] IncreaseArr(int size)
        {

            sizeArr = size * 2;
            var increaseArr = new DictArr[sizeArr];

            int hashKey;
            // передаем данные из dictArr в increaseArr
            for (int i = 0; i < dictArr.Length; i++)
            {
                if (dictArr[i] != null)
                {
                    hashKey = dictArr[i].Key % sizeArr;
                    increaseArr[hashKey] = dictArr[i];
                }
            }

            return increaseArr;
        }

        public string this[int key]
        {
            get { return Get(key); }
            set { Add(key, value); }
        }
    }

    internal class MyExp1 : Exception
    {
    }
    internal class MyExp2 : Exception
    {
    }
    internal class MyExp3 : Exception
    {
    }
}

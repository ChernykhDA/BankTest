using System;
using System.Collections.Generic;
using System.Linq;

namespace BankTest
{
    internal class Program
    {
        public static Dictionary<int, int> Сhanging(int amount, Dictionary<int, int> nominals)
        {

            if (amount == 0)
                return new Dictionary<int, int>();
            if (nominals.Count == 0)
                return null;

            var first = nominals.FirstOrDefault();
            var aviable = nominals[first.Key];

            var number = Math.Min(aviable, amount / first.Key);

            for(int i = number; i >= 0; i--)
            {
                var result = Сhanging(amount - i * first.Key, nominals.Skip(1).ToDictionary(obj => obj.Key, obj => obj.Value));

                if (result != null)
                {
                    if (i != 0)
                    {
                        result.Add(first.Key, i);
                        return result;
                    }
                    else
                        return result;
                }
            }

            return null;
        }


        static void Main(string[] args)
        {
            int amount = 0;

            var nominal = new Dictionary<int, int>();

            nominal.Add(1000, 15);
            nominal.Add(100, 2);
            nominal.Add(50, 45);

            //Сортируем по номиналу
            nominal = nominal
                .OrderByDescending(key => key.Key)
                .ToDictionary(obj => obj.Key, obj => obj.Value);

            var result = Сhanging(amount, nominal);

            if (result == null || result.Count == 0)
                Console.WriteLine("Не удалось разменять");
            else
            {
                //Сортируем для красоты
                result = result.OrderByDescending(x => x.Key).ToDictionary(obj => obj.Key, obj => obj.Value);
                foreach (var el in result)
                {
                    Console.WriteLine($"Номинал: {el.Key}  Количество: {el.Value}");
                }
            }
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace kuud4osa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kuud.txt");

            // 1. Проверка: если файл не существует — создаём
            if (!File.Exists(path))
            {
                File.WriteAllLines(path, new string[] { "Jaanuar", "Veebruar", "Märts", "Aprill", "Mai", "Juuni", "Juuli", "August", "September", "Oktoober", "November", "Detsember" });
                Console.WriteLine("Algandmetega on loodud uus Kuud.txt fail.");
            }

            // 2. Чтение строк из файла
            List<string> kuude_list = new List<string>();
            try
            {
                foreach (string rida in File.ReadAllLines(path))
                {
                    kuude_list.Add(rida);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga, ei saa faili lugeda");
                return;
            }

            // 3. Удаляем "Juuni"
            kuude_list.Remove("Juuni");

            // 4. Меняем первый элемент
            if (kuude_list.Count > 0)
                kuude_list[0] = "Veeel kuuu";

            // 5. Вывод всех месяцев
            Console.WriteLine("-----------Kõik kuud listis-----------");
            foreach (string kuu in kuude_list)
            {
                Console.WriteLine(kuu);
            }

            // 6. Поиск месяца
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Sisesta kuu nimi, mida otsida:");
            string otsitav = Console.ReadLine();

            if (kuude_list.Contains(otsitav))
                Console.WriteLine("Kuu " + otsitav + " on olemas.");
            else
                Console.WriteLine("Nisugune kuu ei ole.");

            // 7. Сохранение изменений
            try
            {
                File.WriteAllLines(path, kuude_list);
                Console.WriteLine("Salvastamine..");
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga!");
            }
        }
    }
}
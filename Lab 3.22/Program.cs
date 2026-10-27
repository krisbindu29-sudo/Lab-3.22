using System;
using System.Collections.Generic;
using System.IO;

namespace Lab3_Task2
{
    
    class Program
    {
        // Метод зчитує файл за допомогою StreamReader і будує масив a[i]
        static int[] GetLineLengthsFromFile(string filePath)
        {
            List<int> lengthsList = new List<int>();

            // Робота з потоком читання файлу StreamReader (згідно з методичкою)
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                // Читаємо файл построково до досягнення кінця файлу (null)
                while ((line = sr.ReadLine()) != null)
                {
                    // Додаємо довжину поточного рядка до списку
                    lengthsList.Add(line.Length);
                }
            }

            // Перетворюємо список у цілочисловий масив a[i]
            return lengthsList.ToArray();
        }

        // Автоматичне створення тестового файлу input.txt у разі його відсутності
        static void PrepareDefaultFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine("Перший рядок тексту.");
                    sw.WriteLine("C# та .NET Framework");
                    sw.WriteLine("Лабораторна робота №3 з програмування.");
                    sw.WriteLine("Чернівці");
                }
                Console.WriteLine($"\n[ІНФО] Створено новий тестовий файл: {Path.GetFullPath(filePath)}");
            }
        }

        
        static void Main(string[] args)
        {
            // Налаштування UTF-8 кодування консолі
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string defaultFileName = "task2_input.txt";
            PrepareDefaultFile(defaultFileName);

            while (true)
            {
                
                Console.WriteLine("ЗАВДАННЯ 2");
                
                Console.WriteLine($"Натисніть Enter для обробки файлу '{defaultFileName}'");
                Console.WriteLine("або введіть шлях до власного файлу (введіть 0 для виходу):");
                

                string input = Console.ReadLine();

                // Вихід з програми при введенні 0
                if (input.Trim() == "0")
                {
                    Console.WriteLine("\nЗавершення роботи програми.");
                    break;
                }

                string filePath = string.IsNullOrWhiteSpace(input) ? defaultFileName : input.Trim();

                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"\nПомилка! Файл '{filePath}' не знайдено.");
                    continue;
                }

                try
                {
                    // Формування цілочислового масиву a[i]
                    int[] a = GetLineLengthsFromFile(filePath);

                    Console.WriteLine($"\nФайл успішно прочитано за допомогою StreamReader.");
                    Console.WriteLine($"Всього рядків у файлі: {a.Length}\n");
                    Console.WriteLine("Сформований цілочисловий масив a[i] (кількість символів у кожному рядку):");
                   

                    for (int i = 0; i < a.Length; i++)
                    {
                        Console.WriteLine($"a[{i}] = {a[i]} (символів у рядку №{i + 1})");
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nВиникла помилка під час читання файлу: {ex.Message}");
                }
            }
        }
    }
}
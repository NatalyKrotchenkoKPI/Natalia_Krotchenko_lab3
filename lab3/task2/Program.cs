using System;
using System.Collections.Generic;
using System.Linq;

namespace ЛР3_2_
{
    class Song
    {
        //створюємо поля класу
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public double Length { get; set; }
    }

    //класи, які наслідують клас Song
    class HipHop : Song { }
    class Rock : Song { }
    class Classical : Song { }
    class Pop : Song { }
    class Electronic : Song { }
    class Jazz : Song { }

    class Program
    {
        static void Main(string[] args)
        {
            //створюємо змінні і присвоюємо значення всіх полів
            var hipHop = new HipHop
            {
                Name = "Lose Yourself",
                Author = "Eminem",
                Genre = "Hip Hop",
                Length = 5.26
            };
            var hip_Hop = new HipHop
            {
                Name = "It Was a Good Day",
                Author = "Ice Cube",
                Genre = "Hip Hop",
                Length = 4.2
            };
            var pop = new Pop
            {
                Name = "Shape of You",
                Author = "Ed Sheeran",
                Genre = "Pop",
                Length = 3.01
            };
            var classical = new Classical
            {
                Name = "Andante Festivo",
                Author = "Sibelius",
                Genre = "Classical",
                Length = 5.09
            };
            var electronic = new Electronic
            {
                Name = "Faded",
                Author = "Alan Walker",
                Genre = "Electronic",
                Length = 3.33
            };
            var jazz = new Jazz
            {
                Name = "What a Wonderful World",
                Author = "Louis Armstrong",
                Genre = "Jazz",
                Length = 2.2
            };
            var rock = new Rock
            {
                Name = "Eye of the Tiger",
                Author = "Survivor",
                Genre = "Rock",
                Length = 4.04
            };

            //створюємо список, в який будемо записувати пісні для колекції
            List<Song> collection = new List<Song>();

            //для користувача
            Console.WriteLine("Виберiть пiснi, якi хочете записати:");
            Console.WriteLine($"1 - {hipHop.Name}, 2 - {hip_Hop.Name}, 3 - {pop.Name}, 4 - {classical.Name}, " +
                $"5 - {electronic.Name}, 6 - {jazz.Name}, 7 - {rock.Name}");

            //створюємо змінну choice, в яку записуємо вибір користувача
            string choice;
            do
            {
                choice = Console.ReadLine();

                //перевіряємо, що вибрав користувач і зберігаємо відповідну пісню в колекцію
                if (choice == "1")
                {
                    SaveToCollection(collection, hipHop);
                }
                else if (choice == "2")
                {
                    SaveToCollection(collection, hip_Hop);
                }
                else if (choice == "3")
                {
                    SaveToCollection(collection, pop);
                }
                else if (choice == "4")
                {
                    SaveToCollection(collection, classical);
                }
                else if (choice == "5")
                {
                    SaveToCollection(collection, electronic);
                }
                else if (choice == "6")
                {
                    SaveToCollection(collection, jazz);
                }
                else if (choice == "7")
                {
                    SaveToCollection(collection, rock);
                }
                else if (choice == "")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Такої пiснi немає!");
                }
            } while (choice != "");

            //виводимо колекцію
            ShowCollection(collection);

            //сортуємо колекцію
            SortCollection(collection);

            //шукаємо по довжині
            FindSongByLength(collection);
        }

        //метод збереження до колекції
        static void SaveToCollection(List<Song> collection, Song choice)
        {
            collection.Add(choice);
        }

        //метод, який виводить колекцію
        static void ShowCollection(List<Song> collection)
        {
            //дробова змінна, в яку записується загална тривалість колекції
            double duration = 0;
            for (int i = 0; i < collection.Count; i++)
            {
                //вивід на консоль
                Console.WriteLine($"{i + 1}. {collection[i].Author} - {collection[i].Name}, " +
                    $"жанр: {collection[i].Genre}, тривалiсть: {collection[i].Length}");
                
                //сумується тривалість
                duration += collection[i].Length;
            }
            Console.WriteLine($"Загальна тривалiсть: {Math.Round(duration, 2)}\n");
        }

        //метод, який сортує колекцію по жанру
        static void SortCollection(List<Song> collection)
        {
            //список жанрів, які є в колекції
            List<string> genres = new List<string>();
            for (int i = 0; i < collection.Count; i++)
            {
                genres.Add(collection[i].Genre);
            }
            genres = genres.Distinct().ToList(); //видаляємо однакові жанри
            for (int i = 0; i < genres.Count; i++)
            {
                Console.WriteLine($"{genres[i]}"); //виводимо
            }

            Console.WriteLine("Введiть вiдносно якого жанру ви хочете вiдсортувати колекцiю");
            string choice = Console.ReadLine(); //вибір жанру, по якому буде сортуватися колекція
            bool rightChoice = false;
            for (int i = 0; i < genres.Count; i++)
            {
                //перевірка, чи є введений користувачем жанр в колекції
                if (choice == genres[i])
                {
                    rightChoice = true;
                    break;
                }
            }

            if (rightChoice == true) //якщо жанр є в колекції
            {
                //сортуємо по жанру
                collection = collection.OrderByDescending(x => x.Genre == choice).ToList();

                //виводимо відсортовану колекцію
                ShowCollection(collection);
            }
            else //якщо немає
            {
                Console.WriteLine("Такого жанру немає!");
            }
        }

        //метод, в якому знаходимо пісні по заданій тривалості
        static void FindSongByLength(List<Song> collection)
        {
            Console.WriteLine("Пошук пiснi по її довжинi\nВведiть дiапазон довжини треку");

            //змінні мінімальної та максимальної довжини
            double min = double.Parse(Console.ReadLine()), max = double.Parse(Console.ReadLine());

            //колекція пісень, які підходять по заданій довжині
            List<Song> newCollection = new List<Song>();
            for (int i = 0; i < collection.Count; i++)
            {
                //перевірка, чи входить пісня в межі
                if (collection[i].Length > min && collection[i].Length < max)
                {
                    newCollection.Add(collection[i]); //додаємо
                }
            }

            if (newCollection.Count == 0) //якщо ніяка пісня не входить в межі
            {
                Console.WriteLine("Такої пiснi немає!");
            }
            else //якщо якась входить
            {
                ShowCollection(newCollection); //показуємо
            }
        }
    }
}

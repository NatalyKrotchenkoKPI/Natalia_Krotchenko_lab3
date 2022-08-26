using System;

namespace ЛР3_1_
{
    class Bird
    {
        //створюємо поля класу
        public string Name { get; set; } 
        public bool IsSitting { get; set; }
        public bool IsFlying { get; set; }
        public bool IsFighting { get; set; }

        //перевизначаємо метод ToString
        public override string ToString()
        {
            return $"Птах: {Name}";
        }

        //метод сидіти
        public void Sit()
        {
            IsSitting = true; //присвоюємо для булевих змінних відповідні значення
            Console.WriteLine($"{Name} сидить");
            IsFlying = false;
            IsFighting = false;
        }

        //метод атакувати
        public void Attack()
        {
            IsFighting = true; //присвоюємо для булевих змінних відповідні значення

            //перевіряємо як птах буде атакувати
            if (IsFlying == false)
            {
                Console.WriteLine($"{Name} атакує");
            }
            else
            {
                Console.WriteLine($"{Name} атакує в повiтрi");
            }
            IsSitting = false;
            IsFlying = false;
        }

        public class Wings
        {
            //метод літати
            public void Fly(Bird bird)
            {
                bird.IsFlying = true; //присвоюємо для булевих змінних відповідні значення
                Console.WriteLine($"{bird.Name} летить");
                bird.IsFighting = false;
                bird.IsSitting = false;
            }
        }

        public class Beak
        {
            //метод їсти
            public void Eat(Bird bird)
            {
                //превіряємо, в якому стані знаходиться птах
                if (bird.IsSitting == true)
                {
                    Console.WriteLine($"{bird.Name} їсть");
                }
                else if (bird.IsFighting == true)
                {
                    Console.WriteLine($"{bird.Name} атакує, спочатку потрiбно сiсти!");
                }
                else if (bird.IsFlying == true)
                {
                    Console.WriteLine($"{bird.Name} летить, спочатку потрiбно сiсти!");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //створюємо змінну птах, типу Bird і присвоюємо поле Name
            var bird = new Bird
            {
                Name = "Лелека"
            };

            WriteName(bird);

            string ending;

            //для користувача
            Console.WriteLine("\nВиберiть дiю:");
            Console.WriteLine("Сiсти - 1, атакувати - 2, летiти - 3, їсти - 4");

            //цикл поки користувач не захоче припинити роботу програми
            do
            {
                //ловимо помилки, які можуть виникнути при роботі програми
                try
                {
                    //цикл, в якому користувач вибирає дію
                    for (int i = 0; i < 4; i++)
                    {
                        //перевірка, яку дію вибрав користувач
                        int action = int.Parse(Console.ReadLine());
                        if (action == 1)
                        {
                            ToSit(bird);
                        }
                        else if (action == 2)
                        {
                            ToAttack(bird);
                        }
                        else if (action == 3)
                        {
                            ToFly(bird);
                        }
                        else if (action == 4)
                        {
                            ToEat(bird);
                        }
                        else
                        {
                            Console.WriteLine("Невiдома команда!");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("\nБажаєте продовжити (yes), чи закiнчити (no)");
                    ending = Console.ReadLine().ToLower();
                }
            } while (ending == "yes");
        }

        //метод, який виводить ім'я птаха
        static void WriteName(Bird bird)
        {
            Console.WriteLine(bird.ToString());
        }

        static void ToSit(Bird bird)
        {
            bird.Sit();
        }

        static void ToAttack(Bird bird)
        {
            bird.Attack();
        }

        static void ToFly(Bird bird)
        {
            var birdToFly = new Bird.Wings();
            birdToFly.Fly(bird);
        }

        static void ToEat(Bird bird)
        {
            var birdToEat = new Bird.Beak();
            birdToEat.Eat(bird);
        }
    }
}

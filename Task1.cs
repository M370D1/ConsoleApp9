using System.Collections.Generic;
using ConsoleApp9;

namespace ConsoleApp9
{
    class Task1
    {
        abstract class Animal
        {
            public string Name { get; set; }

            public Animal(string name)
            {
                Name = name;
            }

            public abstract void MakeSound();

            public void Eat()
            {
                Console.WriteLine($"{Name} is eating.");
            }
        }

        class Dog : Animal
        {
            public Dog(string name) : base(name) { }

            public override void MakeSound()
            {
                Console.WriteLine($"{Name} says: Bark!");
            }
        }

        class Cat : Animal
        {
            public Cat(string name) : base(name) { }

            public override void MakeSound()
            {
                Console.WriteLine($"{Name} says: Meow!");
            }
        }

        public static void Execute()
        {
            List<Animal> animals = new List<Animal>
        {
            new Dog("Rocky"),
            new Cat("Snowball"),
            new Dog("Hector"),
            new Cat("Bella")
        };

            foreach (Animal animal in animals)
            {
                animal.MakeSound();
                animal.Eat();
            }
        }
    }
}
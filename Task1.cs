using System;
using System.Collections.Generic;

namespace ConsoleApp9
{
    class Task1
    {
        abstract class Animal
        {
            private string _name;

            public string Name
            {
                get { return _name; }
                protected set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Name cannot be empty or null.");
                    _name = value;
                }
            }

            protected Animal(string name)
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

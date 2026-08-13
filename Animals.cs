using System;

namespace AnimalHierarchy
{
    // Base Abstract Class
    public abstract class Animal
    {
        public string Name { get; set; }
        protected Animal(string name) => Name = name;
    }

    // Branch 1: Land Animals
    public abstract class LandAnimal : Animal
    {
        protected LandAnimal(string name) : base(name) { }
    }

    public class Tiger : LandAnimal, ICanWalk, ICanHunt, ICanJump
    {
        public Tiger(string name = "Tiger") : base(name) { }
        public void Walk() => Console.WriteLine($"{Name} is walking gracefully.");
        public void Hunt() => Console.WriteLine($"{Name} is hunting prey.");
        public void Jump() => Console.WriteLine($"{Name} is leaping forward.");
    }

    public class Snake : LandAnimal, ICanCrawl, ICanHunt, ICanSwim
    {
        public Snake(string name = "Snake") : base(name) { }
        public void Crawl() => Console.WriteLine($"{Name} is slithering/crawling.");
        public void Hunt() => Console.WriteLine($"{Name} is stalking prey.");
        public void Swim() => Console.WriteLine($"{Name} is swimming gracefully.");
    }

    public class Dog : LandAnimal, ICanWalk, ICanSwim, ICanJump
    {
        public Dog(string name = "Dog") : base(name) { }
        public void Walk() => Console.WriteLine($"{Name} is walking on a leash.");
        public void Swim() => Console.WriteLine($"{Name} is doggy-paddling.");
        public void Jump() => Console.WriteLine($"{Name} is jumping for a toy.");
    }

    // Branch 2: Aquatic Animals
    public abstract class AquaticAnimal : Animal
    {
        protected AquaticAnimal(string name) : base(name) { }
    }

    public class Dolphin : AquaticAnimal, ICanSwim, ICanHunt, ICanJump
    {
        public Dolphin(string name = "Dolphin") : base(name) { }
        public void Swim() => Console.WriteLine($"{Name} is swimming in open sea.");
        public void Hunt() => Console.WriteLine($"{Name} is hunting fish.");
        public void Jump() => Console.WriteLine($"{Name} is leaping out of the water.");
    }

    public class Starfish : AquaticAnimal, ICanCrawl
    {
        public Starfish(string name = "Starfish") : base(name) { }
        public void Crawl() => Console.WriteLine($"{Name} is crawling on the ocean floor.");
    }

    public class Shark : AquaticAnimal, ICanSwim, ICanHunt
    {
        public Shark(string name = "Shark") : base(name) { }
        public void Swim() => Console.WriteLine($"{Name} is swimming fast.");
        public void Hunt() => Console.WriteLine($"{Name} is hunting underwater.");
    }
}
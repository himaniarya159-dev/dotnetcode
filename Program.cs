namespace AnimalHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ANIMAL HIERARCHY DEMO ===\n");

            Tiger tiger = new Tiger();
            tiger.Walk();
            tiger.Hunt();
            tiger.Jump();

            Console.WriteLine();

            Dolphin dolphin = new Dolphin();
            dolphin.Swim();
            dolphin.Jump();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

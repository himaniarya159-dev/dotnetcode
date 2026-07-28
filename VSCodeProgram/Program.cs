namespace VSCodeProgram;

class Program
{
    static void Main(string[] args)
    {
        // Set up welcome header
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("========================================");
        Console.WriteLine("    WELCOME TO THE VS CODE C# APP");
        Console.WriteLine("========================================");
        Console.ResetColor();
        Console.WriteLine();

        // Prompt for user input using Console.Write (keeps cursor on same line)
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();

        Console.Write("Enter your favorite programming language: ");
        string favoriteLanguage = Console.ReadLine();

        Console.WriteLine();

        // Output customized message
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Hello, ");
        Console.Write(userName);
        Console.WriteLine("!");
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"It's great that you are learning {favoriteLanguage}!");
        Console.ResetColor();

        Console.WriteLine();
        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
    }
}

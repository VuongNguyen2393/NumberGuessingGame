namespace NumberGuessingGame.Utils
{
  public static class ConsoleHelper
  {
    public static void PrintWelcome(int minValue, int maxValue)
    {
      var welcome = $"Welcome to the Number Guessing Game!\nI'm thinking of a number between {minValue} and ${maxValue}.\nYou have some chances to guess the correct number.\n";
      PrintColor(welcome, ConsoleColor.DarkMagenta);
    }

    public static void PrintDifficultLevel(int easyChanceCount, int mediumChanceCount, int hardChanceCount)
    {
      var levels = $"1. Easy ({easyChanceCount} chances)\n2. Medium ({mediumChanceCount} chances)\n3. Hard ({hardChanceCount} chances)\n";
      var yourChoice = "Enter your choice: ";
      PrintColor(levels, ConsoleColor.Blue);
      PrintLineColor(yourChoice, ConsoleColor.DarkRed);

    }

    public static void PrintStartGame(Level level)
    {
      var startGame = $"Great! You have selected the {level.ToString()} difficulty level.\nLet's start the game!";
      PrintInfo(startGame);
    }

    public static void PrintInfo(string text)
    {
      PrintColor(text, ConsoleColor.Green);
    }

    public static void PrintWarning(string text)
    {
      PrintColor(text, ConsoleColor.DarkYellow);
    }

    public static void PrintError(string text)
    {
      PrintColor(text, ConsoleColor.DarkRed);
    }

    public static void PrintHint(string text)
    {
      PrintColor(text, ConsoleColor.Blue);
    }



    private static void PrintColor(string text, ConsoleColor consoleColor)
    {
      Console.ForegroundColor = consoleColor;
      System.Console.WriteLine(text);
      Console.ResetColor();
    }

    private static void PrintLineColor(string text, ConsoleColor consoleColor)
    {
      Console.ForegroundColor = consoleColor;
      System.Console.Write(text);
      Console.ResetColor();
    }
  }
}
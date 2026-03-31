using System.Collections;
using System.Runtime.CompilerServices;
using NumberGuessingGame.Utils;

namespace NumberGuessingGame;

class Program
{
    private const int _minValue = 1;
    private const int _maxValue = 100;

    static void Main(string[] args)
    {
        ConsoleHelper.PrintWelcome();
        ConsoleHelper.PrintDifficultLevel();
        var levelStr = Console.ReadLine();
        if (!Enum.TryParse<Level>(levelStr, out var level))
        {
            ConsoleHelper.PrintWarning("The level should only be 1, 2 or 3");
        }
        ConsoleHelper.PrintStartGame(level);

        bool isQuit = false;
        while (!isQuit)
        {
            var maxAttempt = GetAttempt(level);
            var attempt = 0;
            var targetNumber = Random.Shared.Next(1, 101);
            bool isEndGame = false;
            while (attempt < maxAttempt && !isEndGame)
            {
                Console.Write("> Enter your guess: ");
                var guessNumberStr = Console.ReadLine();
                ValidateIntegerInput(guessNumberStr, _minValue, _maxValue, out bool isValidated, out int guessNumber);
                if (!isValidated)
                {
                    continue;
                }
                attempt++;

                if (guessNumber > targetNumber)
                {
                    ConsoleHelper.PrintWarning($"Incorrect! The number is less than {guessNumber}.\n");
                }
                else if (guessNumber < targetNumber)
                {
                    ConsoleHelper.PrintWarning($"Incorrect! The number is greater than {guessNumber}.\n");
                }
                else
                {
                    ConsoleHelper.PrintInfo($"Congratulations! You guessed the correct number in {attempt} attempts\n");
                    isEndGame = true;
                    continue;
                }

                if (attempt == maxAttempt)
                {
                    ConsoleHelper.PrintError("You're FAIL\n");
                    continue;
                }
            }

            bool isContinueConfirm = true;
            while (isContinueConfirm)
            {
                System.Console.WriteLine("Do you wanny retry?\n1. Yes\n2. No\n");
                var decisionStr = Console.ReadLine();
                ValidateIntegerInput(decisionStr, 1, 2, out bool isValidated, out int decision);

                if (!isValidated) continue;
                if (decision == 2)
                {
                    isQuit = true;
                }
                isContinueConfirm = false;
            }
        }
    }

    private static int GetAttempt(Level level)
    {
        int attempt;
        switch (level)
        {
            case Level.Easy:
                attempt = 10;
                break;
            case Level.Medium:
                attempt = 5;
                break;
            default:
                attempt = 3;
                break;
        }
        return attempt;
    }

    private static void ValidateIntegerInput(string? inputStr, int minValue, int maxValue, out bool isValidated, out int guessNumberInt)
    {
        isValidated = true;

        if (!int.TryParse(inputStr, out var guessNumber))
        {
            System.Console.WriteLine("Your input should be numeric");
            isValidated = false;
        }
        if (guessNumber < minValue || guessNumber > maxValue)
        {
            System.Console.WriteLine("Your guess is out of range");
            isValidated = false;
        }
        guessNumberInt = guessNumber;
    }
}

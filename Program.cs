using System.Diagnostics;
using System.Formats.Tar;
using NumberGuessingGame.Utils;

namespace NumberGuessingGame;

class Program
{
    private const int MIN_VALUE = 1;
    private const int MAX_VALUE = 100;
    private const int EASY_CHANCE_COUNT = 10;
    private const int MEDIUM_CHANCE_COUNT = 7;
    private const int HARD_CHANCE_COUNT = 5;

    static void Main(string[] args)
    {
        ConsoleHelper.PrintWelcome(MIN_VALUE, MAX_VALUE);
        ConsoleHelper.PrintDifficultLevel(EASY_CHANCE_COUNT, MEDIUM_CHANCE_COUNT, HARD_CHANCE_COUNT);
        var level = GetLevel();
        ConsoleHelper.PrintStartGame(level);

        bool isQuit = false;
        while (!isQuit)
        {
            var maxAttempt = GetAttempt(level);
            var targetNumber = Random.Shared.Next(1, 101);
            RoundPlay(maxAttempt, targetNumber);
            GetRetryConfirmation(ref isQuit, ref level);
        }
    }

    private static void RoundPlay(int maxAttempt, int targetNumber)
    {
        var attempt = 0;
        bool isEndGame = false;
        var stopWatch = Stopwatch.StartNew();
        while (attempt < maxAttempt && !isEndGame)
        {
            HintLogic(attempt, maxAttempt, MIN_VALUE, MAX_VALUE, targetNumber);
            Console.Write("> Enter your guess: ");
            var guessNumberStr = Console.ReadLine();
            ValidateIntegerInput(guessNumberStr, MIN_VALUE, MAX_VALUE, out bool isValidated, out int guessNumber);
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
                stopWatch.Stop();
                ConsoleHelper.PrintInfo($"Congratulations! You guessed the correct number in {attempt} attempts\nYou finished your turn in {stopWatch.ElapsedMilliseconds / 1000} seconds\n");
                isEndGame = true;
                continue;
            }

            if (attempt == maxAttempt)
            {
                stopWatch.Stop();
                ConsoleHelper.PrintError($"You're FAIL\nYou finished your turn in {stopWatch.ElapsedMilliseconds / 1000} seconds\n");
                continue;
            }
        }
    }

    private static void HintLogic(int attempt, int maxAttemp, int minValue, int maxValue, int targetValue)
    {
        if (attempt == maxAttemp / 2)
        {
            var hintLowNumb = Random.Shared.Next(1, 20);
            var hintUpNumb = Random.Shared.Next(1, 20);
            ConsoleHelper.PrintHint($"The target number in the range from {targetValue - hintLowNumb} to {targetValue + hintUpNumb}");
        }

        if (attempt == maxAttemp * 7 / 10)
        {
            var typeOfTargetValue = targetValue % 2 == 0 ? "even" : "odd";
            ConsoleHelper.PrintHint($"The target number is {typeOfTargetValue} number");
        }


    }

    private static Level GetLevel()
    {
        Level returnLevel = Level.Easy;
        bool isValidLevel = false;
        while (!isValidLevel)
        {
            var levelStr = Console.ReadLine();
            if (!Enum.TryParse<Level>(levelStr, out var level))
            {
                ConsoleHelper.PrintWarning("The level should only be 1, 2 or 3");
                continue;
            }
            isValidLevel = true;
            returnLevel = level;
        }
        return returnLevel;
    }

    private static void GetRetryConfirmation(ref bool isQuit, ref Level currentLevel)
    {
        bool isContinueConfirm = true;
        while (isContinueConfirm)
        {
            ConsoleHelper.PrintInfo("Do you wanny retry?\n1. Yes\n2. No\n3. Change difficulty level\n");
            var decisionStr = Console.ReadLine();
            ValidateIntegerInput(decisionStr, 1, 3, out bool isValidated, out int decision);

            if (!isValidated) continue;
            if (decision == 2)
            {
                isQuit = true;
            }
            if (decision == 3)
            {
                Console.WriteLine();
                ConsoleHelper.PrintDifficultLevel(EASY_CHANCE_COUNT, MEDIUM_CHANCE_COUNT, HARD_CHANCE_COUNT);
                var level = GetLevel();
                ConsoleHelper.PrintStartGame(level);
                currentLevel = level;
            }
            isContinueConfirm = false;
        }
    }

    private static int GetAttempt(Level level)
    {
        int attempt;
        switch (level)
        {
            case Level.Easy:
                attempt = EASY_CHANCE_COUNT;
                break;
            case Level.Medium:
                attempt = MEDIUM_CHANCE_COUNT;
                break;
            default:
                attempt = HARD_CHANCE_COUNT;
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

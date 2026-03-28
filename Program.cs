namespace NumberGuessingGame;

class Program
{
    static void Main(string[] args)
    {
        var targetNumber = Random.Shared.Next(1, 101);
        var maxAttempt = 10;
        var attempt = 0;
        while (true)
        {
            Console.Write("> Enter your guess: ");
            var guessNumberStr = Console.ReadLine();
            if (!int.TryParse(guessNumberStr, out var guessNumber))
            {
                System.Console.WriteLine("Your input should be numeric");
            }
            if (guessNumber < 1 || guessNumber > 100)
            {
                System.Console.WriteLine("Your guess is out of range");
            }

            attempt++;

            if (guessNumber > targetNumber)
            {
                System.Console.WriteLine($"Incorrect! The number is less than {guessNumber}.");
            }
            else if (guessNumber < targetNumber)
            {
                System.Console.WriteLine($"Incorrect! The number is greater than {guessNumber}.");
            }
            else
            {
                System.Console.WriteLine($"Congratulations! You guessed the correct number in {attempt} attempts");
                return;
            }

            if (attempt == maxAttempt)
            {
                System.Console.WriteLine("You're FAIL");
            }

        }
    }
}

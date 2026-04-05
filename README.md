# Number Guessing Game

A simple CLI game built with C# and .NET 10 where the player guesses a randomly generated number between 1 and 100.

Idea: https://roadmap.sh/projects/number-guessing-game

## Features

- Welcome message and game instructions.
- Difficulty selection:
  - Easy: 10 attempts
  - Medium: 7 attempts
  - Hard: 5 attempts
- The application chooses a random number between 1 and 100.
- Player enters a guess and receives feedback:
  - whether the guess is too high or too low.
- Supports replaying the game and changing difficulty.
- High score is stored in a JSON file.
- Provides hints during the game.

## Project Structure

- `Program.cs`: main game logic.
- `Models/Level.cs`: enum defining the difficulty levels.
- `Utils/ConsoleHelper.cs`: helper methods for console output and styling.
- `Data/highscore.json`: file storing high score data.

## Requirements

- .NET 10 SDK

## Run the Project

1. Open a terminal in the project folder.
2. Run:

```bash
dotnet run
```

## How to Play

1. Choose a difficulty by entering `1`, `2`, or `3`.
2. Enter a guess between `1` and `100`.
3. If the guess is incorrect, the game tells you whether the secret number is higher or lower.
4. The game ends when you guess correctly or run out of attempts.
5. After each round, you can choose to replay or change difficulty.

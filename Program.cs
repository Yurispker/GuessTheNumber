int value = new Random().Next(1, 100);
ConsoleKeyInfo start_key = default;
bool gameRunning = true;
int guess_counter = 0;

Console.WriteLine("Welcome to the Guess the Number Game!");

Thread.Sleep(1000); //Sleep for a second to give the user time to read the welcome message

while (start_key.Key != ConsoleKey.Enter)
{
    Console.WriteLine("Press Enter to start the game...");
    start_key = Console.ReadKey(true);
}

while (gameRunning)
{
    Console.WriteLine("Guess a number between 1 and 100 or press 'Q' to quit:");
    var input = Console.ReadLine();

    if (input == "q" || input == "Q")
    {
        Console.WriteLine("Thanks for playing! Goodbye!");
        break;
    }
    if (!int.TryParse(input, out int guess))
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
        continue;
    }

    guess_counter++;

    //Render the result message based on the guess
    string resultMessage = guess switch
    {
        < 1 or > 100 => "Congratulations! You cannot follow simple instructions!",
        _ when guess < value => "Too low! Try again.",
        _ when guess > value => "Too high! Try again.",
        _ => $"Congratulations! You've guessed the number {value} in {guess_counter} attempts."
    };

    Console.WriteLine(resultMessage);
    Thread.Sleep(1000); //Sleep a second to give the user time to read the result message

    //End the game if the guess is correct
    if (guess == value)
    {
        gameRunning = false;
    }
}

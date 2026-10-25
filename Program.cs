int value = new Random().Next(1, 100);
Console.WriteLine(value);
int guess_counter = 0;

while (true)
{
    Console.WriteLine("Guess a number between 1 and 100:");

    var input = Console.ReadLine();
    guess_counter++;

    if (!int.TryParse(input, out int guess))
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
        continue;
    }
    else if (guess < 1 || guess > 100)
    {
        Console.WriteLine("Congratulations! You cannot follow simple instructions! Please enter a number between 1 and 100.");
        continue;
    }
    else
    {
        switch (guess)
        {
            case int n when n < value:
                Console.WriteLine("Too low! Try again.");
                break;

            case int n when n > value:
                Console.WriteLine("Too high! Try again.");
                break;

            default:
                Console.WriteLine($"Congratulations! You guessed the number {value} in {guess_counter} attempts.");
                return;
        }
    }
}

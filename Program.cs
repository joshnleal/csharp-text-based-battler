Console.WriteLine("Welcome");
string? heroName = null;
int monsterCount = 0;
do
{
    try
    {
        Console.Write("Enter your name: ");
        heroName = Console.ReadLine();
        int numericName = -1;
        if (heroName == "")
        {
            heroName = "Hero";
        }
        else if (int.TryParse(heroName, out numericName))
        {
            throw new ArgumentException("Error: Name must contain characters.");
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
        heroName = null;
    }

} while (heroName is null);

do
{
    Console.Write("How many monsters would you like to battle?: ");
    string? count = Console.ReadLine();
    try
    {
        if (!int.TryParse(count, out monsterCount))
        {
            throw new ArgumentException("Error: Input must be numeric.");
        }
        else if (monsterCount <= 1)
        {
            throw new ArgumentException("Error: Input must be greater than 1");
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
} while (monsterCount <= 1);

Console.WriteLine($"Hello there {heroName}! You will be battling {monsterCount} monsters.");


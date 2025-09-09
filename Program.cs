Console.WriteLine("Welcome to the Monster Battler");
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

Console.WriteLine($"\nHello there {heroName}! You will be battling {monsterCount} monsters.");

// Initializing monsters and their health
int[] monsters = new int[monsterCount];
for (int i = 0; i < monsterCount; i++)
{
    monsters[i] = 10 * (i + 1);
}

int playerHealth = 50;

Console.WriteLine("Battle Phase");
Console.WriteLine("------------");
Random random = new Random();
int rng;
int killCount = 0;
foreach (int monsterHealth in monsters)
{
    int currentMonsterHealth = monsterHealth;
    if (playerHealth <= 0)
        break;
    Console.WriteLine("A monster appears...");
    while (!(currentMonsterHealth <= 0) && !(playerHealth <= 0))
    {
        Console.WriteLine("Current Health");
        Console.WriteLine($"{heroName}: {playerHealth}");
        Console.WriteLine($"Monster: {currentMonsterHealth}");
        Console.WriteLine($"\n{heroName}'s turn");
        Console.WriteLine("Select an action");
        Console.WriteLine("1. Heal");
        Console.WriteLine("2. Attack");
        string? input = null;
        int playerChoice;
        try
        {
            Console.Write("Input:");
            input = Console.ReadLine();

            if (!int.TryParse(input, out playerChoice))
                throw new ArgumentException("Error: Input an integer.");
            if (playerChoice < 1 || playerChoice > 2)
                throw new ArgumentException("Error: Input must be 1 or 2.");

            rng = random.Next(5, 16);

            if (playerChoice == 1)
            {
                playerHealth += rng;
                Console.WriteLine($"{heroName} heals for {rng} hit points.");
            }
            else
            {
                currentMonsterHealth -= rng;
                Console.WriteLine($"{heroName} attacks monsters for {rng} hit points.");
            }

            if (currentMonsterHealth <= 0)
            {
                Console.WriteLine("Monster defeated!\n");
                killCount++;
            }
            else
            {
                rng = random.Next(5, 16);
                playerHealth -= rng;
                Console.WriteLine($"Monster attacks {heroName} for {rng} hit points.");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            continue;
        }
    }
}


if (playerHealth < 0)
{
    Console.WriteLine("Game Over");
    Console.WriteLine($"{heroName} killed in action... {killCount} monster(s) slain.");
}
else
{
    Console.WriteLine("Congratulations!");
    Console.WriteLine("You killed all the monsters!");
}
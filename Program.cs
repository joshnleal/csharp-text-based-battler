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

int[] monsters = new int[monsterCount];
for (int i = 0; i < monsterCount; i++)
{
    monsters[i] = 10 * (i + 1);
}

int playerHealth = 50;

Console.WriteLine("Battle Phase");
Random random = new Random();
int rng;
foreach (int monsterHealth in monsters) {
    int currentMonsterHealth = monsterHealth;
    if (playerHealth <= 0)
        break;
    else
        Console.WriteLine("A monster appears.");
    while (currentMonsterHealth != 0 || playerHealth <= 0)
        {
            Console.WriteLine("Health");
            Console.WriteLine($"{heroName}: {playerHealth}");
            Console.WriteLine($"Monster: {monsterHealth}");
            Console.WriteLine($"\n{heroName}'s turn");
            Console.WriteLine("Select an action");
            Console.WriteLine("1. Heal");
            Console.WriteLine("2. Attack");
            string? input = null;
            int playerChoice;
            try
            {
                input = Console.ReadLine();
                if (!int.TryParse(input, out playerChoice))
                {
                    throw new ArgumentException("Error: Input an integer.");
                }
                if (playerChoice < 1 || playerChoice > 2)
                {
                    throw new ArgumentException("Error: Input must be 1 or 2.");
                }
                rng = random.Next(5, 16);
                if (playerChoice == 1)
                    playerHealth += rng;
                else
                    currentMonsterHealth -= rng;


                if (currentMonsterHealth <= 0)
                Console.WriteLine("Monster defeated!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
}
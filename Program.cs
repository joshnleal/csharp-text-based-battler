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
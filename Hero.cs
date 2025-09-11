using System.Security.Cryptography;
namespace Battler
{
    class Hero;
}

public class Hero
{
    public string? Name { get; set; }
    public int Health { get; set; }

    public Hero(string name, int health)
    {
        Name = name;
        Health = health;
    }

    public void TakeDamage(int monsterAttack)
    {
        Health -= monsterAttack;
        Console.WriteLine($"Monster attacks {Name} for {monsterAttack} hit points.");
    }

    public void Heal(int healthPoints)
    {
        Health += healthPoints;
        Console.WriteLine($"{Name} heals for {healthPoints} hit points.");
    }

    public bool IsDead()
    {
        return Health <= 0;
    }

    public void PlayTurn(Monster monster)
    { 
        Random random = new Random();
        int rng;
        while (!(Health <= 0))
        {
            Console.WriteLine($"\n{Name}'s turn");
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
                    Heal(rng);
                else
                    monster.TakeDamage(rng);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }
        }
    }
}
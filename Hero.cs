using System.Security.Cryptography;

public class Hero
{
    public string? Name { get; set; }
    public int Health { get; set; }


    public Hero(string Name, int Health)
    {
        this.Name = Name;
        this.Health = Health;
    }

    public void TakeDamage(int monsterAttack)
    {
        Health -= monsterAttack;
    }

    public bool IsDead()
    {
        return Health <= 0;
    }

    public void PlayTurn(Monster monster)
    { 
        Console.WriteLine("Battle Phase");
        Console.WriteLine("------------");
        Random random = new Random();
        int rng;
        Console.WriteLine("A monster appears...");
        while (!(monster.Health <= 0) && !(this.Health <= 0))
        {
            Console.WriteLine("Current Health");
            Console.WriteLine($"{Name}: {this.Health}");
            Console.WriteLine($"Monster: {monster.Health}");
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
                {
                    this.Health += rng;
                    Console.WriteLine($"{Name} heals for {rng} hit points.");
                }
                else
                {
                    monster.Health -= rng;
                    Console.WriteLine($"{Name} attacks monsters for {rng} hit points.");
                }

                if (monster.Health <= 0)
                {
                    Console.WriteLine("Monster defeated!\n");
                }
                else
                {
                    rng = random.Next(5, 16);
                    this.Health -= rng;
                    Console.WriteLine($"Monster attacks {Name} for {rng} hit points.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }
        }
    }
}
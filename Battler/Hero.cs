using System.Security.Cryptography;
namespace Battler
{
    public class Hero
    {
        private string _name;
        private int _health;
        private List<Weapon> _weapons;

        public Hero(string name, int health)
        {
            _name = name;
            _health = health;
            _weapons = new List<Weapon>();
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public List<Weapon> Weapons
        {
            get { return _weapons; }
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
            bool validInput = false;
            while (!(validInput))
            {
                try
                {
                    Console.WriteLine($"\n{Name}'s turn");
                    Console.WriteLine("Select an action");
                    Console.WriteLine("1. Heal");
                    Console.WriteLine("2. Attack");
                    Console.WriteLine("3. Find a Weapon");
                    Console.WriteLine("4. Upgrade Existing Weapon");
                    string? input = null;
                    int playerChoice;
                    Console.Write("Input:");
                    input = Console.ReadLine();

                    if (!int.TryParse(input, out playerChoice))
                        throw new ArgumentException("Error: Input an integer.");
                    if (playerChoice < 1 || playerChoice > 4)
                        throw new ArgumentException("Error: Input must be between 1-4.");

                    validInput = true;
                    rng = random.Next(5, 16);

                    if (playerChoice == 1)
                        Heal(rng);
                    else if (playerChoice == 2)
                        monster.TakeDamage(rng);
                    else if (playerChoice == 3)
                        Weapons.Add(new Weapon());
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

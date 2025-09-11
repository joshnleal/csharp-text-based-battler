namespace Battler
{
    public class Game
    {
        public Hero Player { get; }
        int Monsters { get; set; }
        public Game(Hero currentPlayer, int monsterCount)
        {
            Player = currentPlayer;
            Monsters = monsterCount;
        }

        public void Play()
        {
            int killCount = 0;
            Console.WriteLine("\nFight!");
            Console.WriteLine("------");
            for (int i = 0; i < Monsters; i++)
            {
                Console.WriteLine("\nA monster appears...");
                RunMonsterBattle(new Monster(10 * (i + 1), i + 1));
                if (Player.IsDead())
                    break;

                killCount++;
            }
            if (!Player.IsDead())
            {
                Console.WriteLine("Congratulations!");
                Console.WriteLine("You killed all the monsters!");
            }
            else
            {
                Console.WriteLine("Game Over");
                Console.WriteLine($"{Player.Name} killed in action... {killCount} monster(s) slain.");
            }
        }

        public void RunMonsterBattle(Monster monster)
        {
            while (!Player.IsDead()) {
                Console.WriteLine("Current Health");
                Console.WriteLine($"{Player.Name}: {Player.Health} hp");
                Console.WriteLine($"Monster {monster.MonsterId}: {monster.Health} hp");
                Player.PlayTurn(monster);
                if (monster.IsDead())
                {
                    Console.WriteLine("Monster killed");
                    return;
                }
                monster.MonsterTurn(Player);
            }
        }
    }
    
}

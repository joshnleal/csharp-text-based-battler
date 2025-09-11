namespace Battler
{
    class Game;
}

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
            RunMonsterBattle(new Monster(i * 10, i + 1));
            if (Player.IsDead())
            {
                killCount = i + 1;
                break;
            }
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
        Player.PlayTurn(monster);
        if (monster.IsDead())
            return;
        monster.MonsterTurn(Player);
    }
}
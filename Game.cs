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
        for (int i = 0; i < Monsters; i++)
        {
            RunMonsterBattle(new Monster(i * 10, i + 1));
            if (Player.IsDead())
                break;
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
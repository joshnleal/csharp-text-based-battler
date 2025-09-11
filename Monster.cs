namespace Battler
{
    class Monster;
}

public class Monster
{
    public int Health { get; set; }
    public int MonsterId { get; set;}

    public Monster(int health, int monsterId)
    {
        Health = health;
        MonsterId = monsterId;
    }

    public void TakeDamage(int heroAttack)
    {
        Health -= heroAttack;
        Console.WriteLine($"Monsters attacked for {heroAttack} hit points.");
    }

    public bool IsDead()
    {
        return Health <= 0;
    }

    public void MonsterTurn(Hero hero)
    {
        Random random = new Random();
        int rng = random.Next(5, 16);
        hero.TakeDamage(rng);
    }
}
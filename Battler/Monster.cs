namespace Battler
{
    public class Monster
    {
        private int _health;
        private int _monsterId;

        public Monster(int health, int monsterId)
        {
            _health = health;
            _monsterId = monsterId;
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int MonsterId
        {
            get { return _monsterId; }
        }

        public void TakeDamage(int heroAttack)
        {
            Health -= heroAttack;
            Console.WriteLine($"Monster attacked for {heroAttack} hit points.");
        }

        public bool IsDead()
        {
            return Health <= 0;
        }

        public void MonsterTurn(Hero hero)
        {
            Console.WriteLine("\nMonster's turn");
            Random random = new Random();
            int rng = random.Next(5, 16);
            hero.TakeDamage(rng);
        }
    }
}

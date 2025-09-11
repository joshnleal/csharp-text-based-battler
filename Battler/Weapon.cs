namespace Battler {
    public class Weapon
    {
        private string _name;
        private int _strength;
        private int _reliability;
        private int _weight;

        public Weapon(string name, int strength, int reliability, int weight)
        {
            _name = name;
            _strength = strength;
            _reliability = reliability;
            _weight = weight;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Strength
        {
            get { return _strength; }
            set { _strength = value; }
        }

        public int Reliability
        {
            get { return _reliability; }
            set { _reliability = value; }
        }

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public int GetDamage()
        {
            Random random = new Random();
            int rng = random.Next(0, Reliability--);
            return Strength * rng;
        }

        public string ToString()
        {
            if (Reliability == 0)
                return $"{Name} (BROKEN)";

            return $"{Name} ({Strength} strength, {Reliability} reliability, {Weight} kg)";
        }

        public int Upgrade(int rng)
        {
            ToString();
            Random random = new Random();
            Weight += random.Next(1, 6);
            int upgradeAmount = random.Next(1, 16);
            if (rng == 1)
                Strength += upgradeAmount;
            else
                Reliability += upgradeAmount;
            ToString();
            return rng;
        }
    }
}
using System.Text;
using Microsoft.VisualBasic;

namespace Battler {
    public class Weapon
    {
        private string _name;
        private int _strength;
        private int _reliability;
        private int _weight;

        public Weapon()
        {
            // [(noun, strength, reliability, weight,)...]
            var nouns = new[] {
                new { Name = "sword", Strength = 4, Reliability = 8, Weight = 5 },
                new { Name = "shield", Strength = 1, Reliability = 8, Weight = 8 },
                new { Name = "bow", Strength = 8, Reliability = 2, Weight = 3 },
                new { Name = "canon", Strength = 9, Reliability = 2, Weight = 15 },
                new { Name = "force field", Strength = 2, Reliability = 7, Weight = 1 },
                new { Name = "drone", Strength = 9, Reliability = 2, Weight = 20 },
                new { Name = "tank", Strength = 9, Reliability = 7, Weight = 45 }
            };

            // [(adjective, multiplier,)...]
            var adjectives = new[] {
                new { Adjective = "wooden", Multiplier = 1 },
                new { Adjective = "bronze", Multiplier = 2 },
                new { Adjective = "steel", Multiplier = 3 },
                new { Adjective = "diamond", Multiplier = 4 },
                new { Adjective = "nanofiber", Multiplier = 5 },
                new { Adjective = "unobtainium", Multiplier = 6 },
                new { Adjective = "epic", Multiplier = 7 },
                new { Adjective = "legendary", Multiplier = 8 },
                new { Adjective = "eternal", Multiplier = 9 },
            };

            Random random = new();
            var noun = nouns[random.Next(0, nouns.Length)];
            var adjective = adjectives[random.Next(0, adjectives.Length)];
            _name = adjective.Adjective + " " + noun.Name;
            _strength = noun.Strength;
            _reliability = noun.Reliability;
            _weight = noun.Weight;

            Console.WriteLine($"Weapon found: {this.ToString()}");
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

        override public string ToString()
        {
            if (Reliability == 0)
                return $"{Name} (BROKEN)";

            return $"{Name} ({Strength} strength, {Reliability} reliability, {Weight} kg)";
        }

        public int Upgrade(int rng)
        {
            Console.WriteLine($"Old Stats: {ToString()}");
            Random random = new Random();
            Weight += random.Next(1, 6);
            int upgradeAmount = random.Next(1, 16);
            StringBuilder sb = new StringBuilder();
            if (rng == 1)
            {
                Strength += upgradeAmount;
                sb.Append("Strength ");
            }
            else
            { 
                Reliability += upgradeAmount;
                sb.Append("Reliability ");
            }

            sb.Append($"upgraded by {upgradeAmount} points!");
            Console.WriteLine(sb.ToString());
            Console.WriteLine($"New stats: {ToString()}");
            return upgradeAmount;
        }
    }
}
using System;
using System.Collections.Generic;

namespace PokemonPocket
{
    public class PokemonMaster
    {
        public string Name { get; set; }
        public int NoToEvolve { get; set; }
        public string EvolveTo { get; set; }

        public PokemonMaster(string name, int noToEvolve, string evolveTo)
        {
            this.Name = name;
            this.NoToEvolve = noToEvolve;
            this.EvolveTo = evolveTo;
        }
    }
    public class PokemonCollection
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Exp { get; set; }

        public string Skill { get; set; }
        public PokemonCollection(string name, int hp, int exp)
        {
            this.Name = name;
            this.Hp = hp;
            this.Exp = exp;
        }
    }

    public class Pikachu : PokemonCollection
    {
        public Pikachu(String name, int hp, int exp) : base(name, hp, exp)
        {
            Skill = "Lightning Bolt";
        }
    }

    public class Eevee : PokemonCollection
    {
        public Eevee(String name, int hp, int exp) : base(name, hp, exp)
        {
            Skill = "Run Away";
        }

    }

    public class Charmander : PokemonCollection
    {
        public Charmander(String name, int hp, int exp) : base(name, hp, exp)
        {
            Skill = "Solar Power";
        }
    }

    public class Raichu : PokemonCollection
    {
        public Raichu(String name, int hp, int exp) : base(name, hp, exp)
        {
            Skill = "Lightning Bolt";
        }
    }

    public class Flareon : PokemonCollection
    {
        public Flareon(String name, int hp, int exp) : base(name, hp, exp)
        {
            Skill = "Run Away";
        }
    }

    public class Charmeleon : PokemonCollection
    {
        public Charmeleon(String name, int hp, int exp) : base(name, hp, exp)
        {
            Skill = "Solar Power";
        }
    }
}
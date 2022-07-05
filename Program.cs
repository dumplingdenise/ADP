// Denise 214329G

using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonPocket
{
    public class Program
    {
        static void Main(string[] args)
        {
            //PokemonMaster list for checking pokemon evolution availability.    
            List<PokemonMaster> pokemonMasters = new List<PokemonMaster>(){
            new PokemonMaster("Pikachu", 2, "Raichu"),
            new PokemonMaster("Eevee", 3, "Flareon"),
            new PokemonMaster("Charmander", 1, "Charmeleon")
            };

            //Use "Environment.Exit(0);" if you want to implement an exit of the console program
            //Start your assignment 1 requirements below.

            //List<PokemonCollection> pokemonCollections = new List<PokemonCollection>();
            var pokemons = new PokemonCollectionsData();
            static void Display()
            {
                Console.WriteLine("\n*****************************\nWelcome to Pokemon Pocket App\n*****************************");
                Console.WriteLine("(1). Add pokemon to my pocket\n(2). List pokemon(s) in my Pocket\n(3). Check if I can evolve pokemon\n(4). Evolve pokemon\n(5). Delete a pokemon");
                Console.Write("Please only enter [1,2,3,4] or Q to quit: ");
            }

            void AddPoke()
            {
                string name; int hp; int exp;
                while (true)
                {
                    Console.Write("\nEnter Pokemon's name: ");
                    name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("\nPlease fill in the name");
                    }
                    else
                    {
                        name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
                        if (name == pokemonMasters[0].Name)
                        {
                            break;
                        }
                        else if (name == pokemonMasters[1].Name)
                        {
                            break;
                        }
                        else if (name == pokemonMasters[2].Name)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid pokemon name, please try again!");
                        }
                    }
                }
                while (true)
                {
                    Console.Write("Enter Pokemon's Hp: ");
                    string inputhp = Console.ReadLine();
                    if (int.TryParse(inputhp, out hp))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Pleasae enter a valid value.");
                    }
                }
                while (true)
                {
                    Console.Write("Enter Pokemon's Exp: ");
                    string inputexp = Console.ReadLine();
                    if (int.TryParse(inputexp, out exp))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Pleasae enter a valid value.");
                    }
                }
                if (name == pokemonMasters[0].Name)
                {
                    var pikachu = new Pikachu(name, hp, exp);
                    //pokemonCollections.Add(new Pikachu(name, hp, exp));
                    pokemons.Add(pikachu);
                    pokemons.SaveChanges();
                    Console.WriteLine("\n{0} Added to your pokemon pokect!", name);
                }
                else if (name == pokemonMasters[1].Name)
                {
                    //pokemonCollections.Add(new Eevee(name, hp, exp));
                    var eevee = new Eevee(name, hp, exp);
                    pokemons.Add(eevee);
                    pokemons.SaveChanges();
                    Console.WriteLine("\n{0} Added to your pokemon pokect!", name);
                }
                else if (name == pokemonMasters[2].Name)
                {
                    //pokemonCollections.Add(new Charmander(name, hp, exp));
                    var charmander = new Charmander(name, hp, exp);
                    pokemons.Add(charmander);
                    pokemons.SaveChanges();
                    Console.WriteLine("\n{0} Added to your pokemon pokect!", name);
                }
            }

            void InsertionSort()
            {

                var allpokemons = pokemons.Pokemonslist.ToList();
                if (allpokemons.Count() == 0)
                {
                    Console.WriteLine("\nThere is no pokemons in collection, please add pokemons first.");
                }
                else
                {
                    Console.WriteLine("\n----------------------\n----------------------");
                    List<Int32> pokemon_hp = new List<Int32>();
                    for (int x = 0; x < allpokemons.Count; x++)
                    {
                        pokemon_hp.Add(allpokemons[x].Hp); // pulling Hp to another list for sorting.
                    }
                    List<Int32> uniquepoke_hp = pokemon_hp.Distinct().ToList(); // to remove duplicates
                    for (int i = 1; i < uniquepoke_hp.Count; i++)
                    {
                        var val = uniquepoke_hp[i];
                        var flag = 0;
                        for (int j = i - 1; j >= 0 && flag != 1;)
                        {
                            if (val < uniquepoke_hp[j])
                            {
                                uniquepoke_hp[j + 1] = uniquepoke_hp[j];
                                j--;
                                uniquepoke_hp[j + 1] = val;
                            }
                            else flag = 1; // ensure the code run smoothly even if the val is more than hp. 
                        }
                    }
                    for (int x = 0; x < uniquepoke_hp.Count; x++)
                    {
                        for (int i = 0; i < allpokemons.Count; i++)
                        {
                            if (uniquepoke_hp[x] == allpokemons[i].Hp)
                            {
                                Console.Write("Name: {0, -15} \nHP: {1,-15} \nEXP: {2, -15} \nSkill: {3, -15}", allpokemons[i].Name, allpokemons[i].Hp, allpokemons[i].Exp, allpokemons[i].Skill);
                                Console.WriteLine("\n----------------------\n----------------------");
                            }
                        }
                    }
                }
            }

            void Checking()
            {
                var allpokemons = pokemons.Pokemonslist.ToList();
                if (allpokemons.Count == 0)
                {
                    Console.WriteLine("\nThere is no pokemons in pokemon collections.");
                }
                else
                {
                    foreach (var c in pokemonMasters)
                    {
                        var pokecount = allpokemons.Where(p => p.Name == c.Name).Count();
                        if (pokecount >= c.NoToEvolve)
                        {
                            Console.WriteLine("\n{0} --> {1}", c.Name, c.EvolveTo);
                        }
                        else
                        {
                            if (pokecount < pokemonMasters[0].NoToEvolve)
                            {
                                continue;
                            }
                            if (pokecount < pokemonMasters[1].NoToEvolve)
                            {
                                continue;
                            }
                            if (pokecount < pokemonMasters[2].NoToEvolve)
                            {
                                continue;
                            }
                        }
                    }
                }
            }

            void Evolved()
            {
                string input;
                while (true)
                {
                    Checking();
                    var allpokemons = pokemons.Pokemonslist.ToList();
                    if (allpokemons.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("\nWhich pokemon do you want to evolve? ");
                        input = Console.ReadLine();
                        if (string.IsNullOrEmpty(input))
                        {
                            Console.WriteLine("Please enter a name: ");
                        }
                        else
                        {
                            if (input.ToLower() == "pikachu")
                            {
                                List<PokemonCollection> pikachu = allpokemons.Where(p => p.Name == pokemonMasters[0].Name).ToList();
                                if (pikachu.Count >= 2)
                                {
                                    if (pikachu.Count % 2 == 0)
                                    {
                                        foreach (var p in pikachu)
                                        {
                                            pokemons.Remove(p);
                                            pokemons.SaveChanges();

                                        }
                                        var addcount = pikachu.Count / 2;
                                        for (int x = 0; x < addcount; x++)
                                        {
                                            pokemons.Add(new Raichu("Raichu", 0, 0));
                                            pokemons.SaveChanges();
                                        }
                                        Console.WriteLine("\n{0} Pikachu had been evolved to {1} Raichu", pikachu.Count, addcount);
                                        break;
                                    }
                                    else
                                    {
                                        int count = 0;
                                        foreach (var p in pikachu)
                                        {
                                            pokemons.Remove(p);
                                            pokemons.SaveChanges();
                                            count += 1;
                                            if (count == 2)
                                            {
                                                break;
                                            }
                                        }
                                        var addcount = (pikachu.Count - 1) / 2;
                                        for (int x = 0; x < addcount; x++)
                                        {
                                            pokemons.Add(new Raichu("Raichu", 0, 0));
                                            pokemons.SaveChanges();
                                        }
                                        Console.WriteLine("\n{0} Pikachu had been evolved to {1} Raichu", pikachu.Count - 1, addcount);
                                        break;
                                    }
                                }
                            }
                            if (input.ToLower() == "eevee")
                            {
                                List<PokemonCollection> eevee = allpokemons.Where(p => p.Name == pokemonMasters[1].Name).ToList();
                                if (eevee.Count >= 3)
                                {
                                    if (eevee.Count % 3 == 0)
                                    {
                                        foreach (var p in eevee)
                                        {
                                            pokemons.Remove(p);
                                            pokemons.SaveChanges();
                                        }
                                        var addcount = eevee.Count / 3;
                                        for (int x = 0; x < addcount; x++)
                                        {
                                            pokemons.Add(new Flareon("Flareon", 0, 0));
                                            pokemons.SaveChanges();
                                        }
                                        Console.WriteLine("\n{0} Pikachu had been evolved to {1} Raichu", eevee.Count, addcount);
                                        break;
                                    }
                                    else
                                    {
                                        int count = 0;
                                        foreach (var p in eevee)
                                        {
                                            pokemons.Remove(p);
                                            pokemons.SaveChanges();
                                            count += 1;
                                            if (count == 3)
                                            {
                                                pokemons.Add(new Flareon("Flareon", 0, 0));
                                                pokemons.SaveChanges();
                                            }
                                        }
                                        Console.WriteLine("\nEevee had been evolved to Flareon");
                                        break;
                                    }
                                }
                            }
                            if (input.ToLower() == "charmander")
                            {
                                List<PokemonCollection> charmander = allpokemons.Where(p => p.Name == pokemonMasters[2].Name).ToList();
                                if (charmander.Count >= 1)
                                {
                                    foreach (var p in charmander)
                                    {
                                        pokemons.Remove(p);
                                        pokemons.SaveChanges();
                                        pokemons.Add(new Charmeleon("Charmeleon", 0, 0));
                                        pokemons.SaveChanges();
                                    }
                                    Console.WriteLine("{0} Charmander had been evolved to {1} Charmeleon", charmander.Count, charmander.Count);
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid pokemon");
                            }
                        }
                    }
                }
            }

            void Delete()
            {
                char cont; var deleting = true; string input;
                while (deleting)
                {
                    var allpokemons = pokemons.Pokemonslist.ToList();
                    for (int p = 0; p < allpokemons.Count; p++)
                    {
                        Console.Write("Name: {0, -15} \nHP: {1,-15} \nEXP: {2, -15} \nSkill: {3, -15}", allpokemons[p].Name, allpokemons[p].Hp, allpokemons[p].Exp, allpokemons[p].Skill);
                        Console.WriteLine("\n----------------------\n----------------------");
                    }
                    if (allpokemons.Count == 0)
                    {
                        Console.WriteLine("\nNo pokemons in pokemon collection available to delete.");
                        break;
                    }
                    else
                    {
                        Console.Write("Which pokemons do you want to delete ('x' to go back to main menu?) ");
                        input = Console.ReadLine();
                        input = char.ToUpper(input[0]) + input.Substring(1).ToLower();
                        if (string.IsNullOrEmpty(input))
                        {
                            Console.WriteLine("Please enter a pokemon name.");
                        }
                        else
                        {
                            if (input == "Pikachu" || input == "Eevee" || input == "Charmander" || input == "Raichu" || input == "Flareon" || input == "Charmeleon")
                            {
                                for (int p = 0; p < allpokemons.Count; p++)
                                {
                                    if (allpokemons[p].Name == input)
                                    {
                                        List<PokemonCollection> temp = allpokemons.Where(p => p.Name == input).ToList();
                                        foreach (var x in temp)
                                        {
                                            pokemons.Remove(x);
                                            pokemons.SaveChanges();
                                        }
                                        Console.WriteLine("Pokemon {0} have been deleted.", input);
                                        deleting = false;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid pokemon name");

                            }

                        }

                    }
                    while (true)
                    {
                        Console.Write("Do you still want to delete pokemons? (Y/N) ");
                        string input1 = Console.ReadLine();
                        if (char.TryParse(input1.ToLower(), out cont))
                        {
                            if (cont == 'y')
                            {
                                deleting = true;
                                break;
                            }
                            else if (cont == 'n')
                            {
                                deleting = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid value.");
                            }
                        }
                    }
                }
            }

            var cont = true;
            while (cont)
            {
                Display();
                string input = Console.ReadLine();
                char choice;
                if (char.TryParse(input, out choice))
                {
                    if (choice == 'Q' || choice == 'q')
                    {
                        Environment.Exit(0);
                    }
                    else if (choice == '1')
                    {
                        AddPoke();
                    }
                    else if (choice == '2')
                    {
                        InsertionSort();
                    }
                    else if (choice == '3')
                    {
                        Checking();
                    }
                    else if (choice == '4')
                    {
                        Evolved();
                    }
                    else if (choice == '5')
                    {
                        Delete();
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid choice. Try again!");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid choice. Try again!");
                }
            }
        }
    }
}



using System;
using C__Basic_codealong_modellering.Models;
using Microsoft.VisualBasic;

namespace C__Basic_codealong_modellering.Controller;

public class InputController(DataContext context)
{
    /* Her har vi flyttet ansvaret for input til en egen controller. 
    Vi henter inn en referanse til vår datacontext (til vår csv fil) */
    private readonly DataContext _context = context;
    private bool isRunning {get;set;} = true;
    public void Run()
    {
        while(isRunning)
        {
            Console.WriteLine("Here are the controls:");
            Console.WriteLine("1:How many squirrels are tracked?");
            Console.WriteLine("2:How many squirrels twitch their tails?");
            Console.WriteLine("3:How many are Adults?");
            Console.WriteLine("4:Make a more complicated Query");
            Console.WriteLine("5: exit program");
            var input = Console.ReadLine();
            int command;
            /* Her tvinger vi brukeren til å skrive inn en text som kan parses til en integer. */
            while(!int.TryParse(input, out command))
            {
                Console.WriteLine("Please choose a valid command number");
                input = Console.ReadLine();
            }

            /* Vi lager en case for hver command definert i Connsole.WriteLine på linje 20. */
            switch(command)
            {
                case 1:
                    Console.WriteLine($"There are {_context.Squirrels.Count} squirrel sightings in the dataset.");
                    break;
                case 2: 
                    Console.WriteLine($"The ammount of squirrels that twitch their tails are {_context.Squirrels.Where(squirrel => squirrel.TailTwitch).Count()}");
                    break;
                case 3:
                    Console.WriteLine($"The ammount of adult squirrels is {_context.Squirrels.Where(squirrel => squirrel.Age == "Adult").Count()}");
                    break;
                case 4: 
                    var query = QueryBuilder();
                    Console.WriteLine("Here comes the results of your query:");
                    Console.WriteLine($"We found {query.Count()} squirrels.");
                    foreach (var squirrel in query)
                    {
                        Console.WriteLine($"Squirrel with id {squirrel.SquirrelId} is an {squirrel.Age}, it's fur color is {squirrel.PrimaryFurColor}.");
                    }
                    break;
                default: 
                    isRunning = false;
                    break;
            }
        }
    }
    /* Her har vi en metode hvor vi lager en LinQ interface, som skal tilslutt "consumes" og vise et resultat til brukeren.
    Vi ser igjen her at vi kan "chaine" metodene så mye vi vil for å se om brukeren vil gjøre spørring mot Age, mot PrimaryFurColor eller begge, eller ingen. */
    public IQueryable<SquirrelData> QueryBuilder()
    {
        var queryStart = _context.Squirrels.AsQueryable();
        
        Console.WriteLine("Type an age you want to query by, or press enter to skip.");
        string ageinput = Console.ReadLine();
        if (!string.IsNullOrEmpty(ageinput))
        {
            queryStart = queryStart.Where(s => string.Equals(s.Age, ageinput, StringComparison.InvariantCultureIgnoreCase));
        }
        Console.WriteLine("Type a fur color you want to query by, or press enter to skip");
        string furinput = Console.ReadLine();
        if (!string.IsNullOrEmpty(furinput))
        {
            queryStart = queryStart.Where(s => string.Equals(s.PrimaryFurColor, furinput, StringComparison.InvariantCultureIgnoreCase));
        }
        return queryStart;
    }
}

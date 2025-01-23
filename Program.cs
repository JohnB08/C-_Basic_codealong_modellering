namespace C__Basic_codealong_modellering;

using System.Reflection.Metadata.Ecma335;
using C__Basic_codealong_modellering.Models;

class Program
{
    static void Main(string[] args)
    {
        var context = new DataContext();
        Console.WriteLine("Welcome to the squirrel tracker!");
        bool isRunning = true;
        while(isRunning)
        {
            Console.WriteLine("Here are the controls:\n1:How many squirrels are tracked?\n2:How many squirrels twitch their tails?\n3:How many are Adults?\n4: exit program");
            var input = Console.ReadLine();
            int command;
            while(!int.TryParse(input, out command))
            {
                Console.WriteLine("Please choose a valid command number");
                input = Console.ReadLine();
            }
            switch(command)
            {
                case 1:
                    Console.WriteLine($"There are {context.Squirrels.Count} squirrel sightings in the dataset.");
                    break;
                case 2: 
                    Console.WriteLine($"The ammount of squirrels that twitch their tails are {context.Squirrels.Where(squirrel => squirrel.TailTwitch).Count()}");
                    break;
                case 3:
                    Console.WriteLine($"The ammount of adult squirrels is {context.Squirrels.Where(squirrel => squirrel.Age == "Adult").Count()}");
                    break;
                default: 
                    isRunning = false;
                    break;
            }
        }
    }
}

namespace C__Basic_codealong_modellering;
using C__Basic_codealong_modellering.Controller;
using C__Basic_codealong_modellering.Models;

class Program
{
    static void Main(string[] args)
    {
        /* Her lager vi en instans av vår datacontext, den som skal være vår modell av selve filen. */
        var context = new DataContext();
        Console.WriteLine("Welcome to the squirrel tracker!");
        var controller = new InputController(context);
        controller.Run();
    }
}

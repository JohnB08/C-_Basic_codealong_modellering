using System;
using System.Security.Cryptography.X509Certificates;

namespace C__Basic_codealong_modellering.Models;
/* Her lager vi en modell av en linje i 2018_Central_Park_Squirrel_Census_-_Squirrel_Data_20250120.csv
    Vi henter kun ut den dataen vi syns er relevant, eller vi ønsker å ha oversikt over.
    En mer robust modell ville laget et felt for hver kolonne.
 */
public class SquirrelData
{
    public string SquirrelId {get;set;}
    public string ParkCoordinates {get;set;}
    public string Shift {get;set;}
    public DateTime Date{get;set;}
    public string? Age {get;set;}
    public string? PrimaryFurColor {get;set;}
    public string? HighlightFurColor {get;set;}

    /* Denne ColorCombo propertien vår, holder ingen verdi selv, men bruker verdien til Primary, og Highlight Fur Color for å returnere ønsket data.  */
    public string? ColorCombo {
        get
        {
            string val = string.Empty;
            if (!string.IsNullOrEmpty(PrimaryFurColor))
            {
                val += PrimaryFurColor;
            }
            if (!string.IsNullOrEmpty(HighlightFurColor))
            {
                val += $"+ {HighlightFurColor}";
            }
            return val;
        }
    }
    public string? Location{get;set;}
    public int AboveGroundMeassurement{get;set;} //Husk å skjekk mot string nullverdi, string FALSE.
    public string? SpesificLocation{get;set;}
    public bool Running {get;set;}
    public bool Chasing {get;set;}
    public bool Climbing {get;set;}
    public bool Eating {get;set;}
    public bool Foraging {get;set;}
    public string? OtherActivities{get;set;}
    public bool TailTwitch {get;set;}
    public bool Indifferent {get;set;}

    /* Her lager vi en constructor, det som skal lage et SquirrelData objekt.
    Vi tar inn en string, som representerer en Comma Separated Values streng eller en vilkårlig linje i filen vår.  */
    public SquirrelData(string csv)
    {
        /* Vi splitter opp filen, og assigner verdier til hver property, basert på kollonnen.
        Kolonne nr 1 er det samme som index 0 i values arrayet vårt.  */
        string[] values = csv.Split(",");
        SquirrelId = values[2];
        ParkCoordinates = values[3];
        Shift = values[4];
        if (DateTime.TryParse(values[5], out DateTime date))
        {
            Date = date;
        }
        Age = values[7];
        PrimaryFurColor = values[8];
        HighlightFurColor = values[10];
        Location = values[12];

        /* Legg merke til at vi ikke kan bruke properties rett i TryPArse, men er nødt å lage en dump variabel, som kan holde verdien før vi assigner den. */
        if (int.TryParse(values[13], out int res))
        {
            AboveGroundMeassurement = res;
        }
        SpesificLocation = values[14];
        if (bool.TryParse(values[15], out bool running))
        {
            Running = running;
        }
        if (bool.TryParse(values[16], out bool chasing))
        {
            Chasing = chasing;
        }
        if (bool.TryParse(values[18], out bool eating))
        {
            Eating = eating;
        }
        if (bool.TryParse(values[17], out bool climbing))
        {
            Climbing = climbing;
        }
        if (bool.TryParse(values[19], out bool foraging))
        {
            Foraging = foraging;
        }
        OtherActivities = values[20];
        if (bool.TryParse(values[25], out bool tailTwitch))
        {
            TailTwitch = tailTwitch;
        }
        if (bool.TryParse(values[27], out bool indifferent))
        {
            Indifferent = indifferent;
        }

    }
}

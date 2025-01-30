using System;
using System.Text;

namespace C__Basic_codealong_modellering.Models;
/* Her lager vi en modell for hele filen vår. */
public class DataContext
{
    /* Vi sier at filen representerer en liste av SquirrelData objekter. */
    public List<SquirrelData> Squirrels {get;set;} = [];
    /* Vi lager en constructor som leser filen, og lager en liste basert på dataen som er der. */
    public DataContext()
    {
        /* Her bruker vi ReadLines for å lese filen en linje om gangen, hver linje blir separert ut som sin egen string.  */
       var rawData = File.ReadLines("2018_Central_Park_Squirrel_Census_-_Squirrel_Data_20250120.csv");

       
       /* Her bruker vi noe som heter LinQ for å lage listen av squirrelData. 
       Vi skal kikke nærmere på LinQ neste uke, men her er en liten smakebit.
       Vi "chainer" flere metoder sammen i en metoderekke.
       Skip lar oss skippe x antall (i vårt tilfelle 1) elementer i starten av sekvensen vår før neste operasjon.
       Select sier basert på en vilkårlig element, hva skal returneres tilbake. 
       ToList() sier hva resultatet skal lagres som. */
       Squirrels = rawData.Skip(1).Select(dataString => new SquirrelData(dataString)).ToList();
       //I prinsipp det samme som: 
       /* var data = rawData.ToList();
       for (int i = 1; i < data.Count; i++)
       {
        Squirrels.Add(new SquirrelData(data[i]));
       } */
    }
}

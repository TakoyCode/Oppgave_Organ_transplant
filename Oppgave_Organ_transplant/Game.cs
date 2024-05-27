using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppgave_Organ_transplant
{
    internal class Game
    {
        private Person kaare;
        private Person bernt;
        public Game()
        {
            kaare = new Person("Kåre", true, true);
            bernt = new Person("Bernt", false, false);
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("Bernt trenger en ny nyre for å overleve, hva skal du gjøre?");
            Console.WriteLine("1) Gi bort min nyre til Bernt");
            Console.WriteLine("2) Ikke gi bort min nyre til Bernt");
            Console.WriteLine("3) Sjekk hvordan mine nyrer ligger ann");
            Console.WriteLine("4) Sjekk hvordan Bernt sine nyrer ligger ann");
            Console.WriteLine("5) Exit");
            Menu();
        }

        private void Menu()
        {
            switch (Console.ReadLine())
            {
                case "1":
                    kaare.GiveAwayKidneyTo(bernt);
                    break;
                case "2":
                    DeathScreen();
                    break;
                case "3":
                    kaare.CheckStatus();
                    break;
                case "4":
                    bernt.CheckStatus();
                    break;
                case "5":
                    Environment.Exit(404);
                    break;
                default:
                    Console.WriteLine("Prøv igjen!");
                    Thread.Sleep(500);
                    break;
            }

           
        }

        private void DeathScreen()
        {
            bernt.IsAlive = false;

            Console.Clear();
            Console.WriteLine("Bernt klarte ikke å finne en ny nyre i tide, og døde av nyresvikt :(");
            Console.WriteLine("Det er veldig trist at du kunne gjøre ingenting for å endre skjebnen hans.");
            Console.ReadKey(true);
        }
    }
}

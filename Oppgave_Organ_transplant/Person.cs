namespace Oppgave_Organ_transplant
{
    internal class Person
    {
        public string Name;
        public bool IsKidney1Healthy;
        public bool IsKidney2Healthy;
        public bool IsAlive;

        public Person(string name, bool isKidney1Healthy, bool isKidney2Healthy)
        {
            Name = name;
            IsKidney1Healthy = isKidney1Healthy;
            IsKidney2Healthy = isKidney2Healthy;
            IsAlive = true;
        }

        public void CheckStatus()
        {
            Console.Clear();
            Console.WriteLine($"{Name} {CheckIfAlive()}.");
            CheckKidney(IsKidney1Healthy, 1);
            CheckKidney(IsKidney2Healthy, 2);
            Console.Write("\nTrykk hvem som helst knapp for å gå tilbake...");
            Console.ReadKey(true);
        }

        public string CheckIfAlive()
        {
            if (IsAlive && (IsKidney1Healthy == false || IsKidney2Healthy == false))
            {
                return "lever, men livet kunne vært bedre";
            }
            else if(IsAlive)
            {
                return "lever og har det fint";
            }
            else
            {
                return "er ikke med oss lenger, han døde av nyresvikt. " +
                       "Men det var ikke bare nyren hans, som sviktet han...";
            }
        }

        private void CheckKidney(bool IsKidneyHealthy, int KidneyNum)
        {
            if (IsKidneyHealthy)
            {
                Console.WriteLine($"Nyre num.{KidneyNum} er god og sun!");
            }
            else
            {
                Console.WriteLine($"Nyre num.{KidneyNum} er nesten helt borte og trenger akutt hjelp!");
            }
        }

        public void GiveAwayKidneyTo(Person person)
        {
            GiveAwayKidneyMenu();
            switch (Console.ReadLine())
            {
                case "1":
                    changeKidneys(IsKidney1Healthy, 1,person);
                    break;
                case "2":
                    changeKidneys(IsKidney2Healthy, 2, person);
                    break;
                case "3":
                    break;
                default:
                    GiveAwayKidneyTo(person);
                    break;
            }
        }

        private void changeKidneys(bool kidney, int kidneyNum, Person person)
        {
            if (kidney)
            {
                if (kidneyNum == 1)
                {
                    IsKidney1Healthy = false;
                    person.IsKidney1Healthy = true;
                }
                else
                {
                    IsKidney2Healthy = false;
                    person.IsKidney2Healthy = true;
                }
            }
            else
            {
                Console.WriteLine("Nyren din er for dårlig for å gi bort, er nesten som den ikke er der.");
                Console.ReadKey(true);
                GiveAwayKidneyTo(person);
            }
        }

        private void GiveAwayKidneyMenu()
        {
            Console.Clear();
            CheckKidney(IsKidney1Healthy, 1);
            CheckKidney(IsKidney2Healthy, 2);
            Console.WriteLine("\n1) Velg å gi bort nyre 1");
            Console.WriteLine("2) Velg å gi bort nyre 2");
            Console.WriteLine("3) Tilbake");
        }
    }
}

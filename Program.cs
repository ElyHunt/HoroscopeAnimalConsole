using System;
/*
    Elliot Hunt
    October 04, 2020
    A program that takes your name 
        and generates a spirit animal, astrological sign,
        and horoscope based on it along with the day.
*/
namespace HoroscopeAnimalConsole
{
    class Person
    {
        private string name;
        private string astrologicalSign;
        private string species;
        private string horoscope;

        private string[] astrologicalSigns = 
        {"Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra",
         "Scorpio", "Sagittarius", "Capricorn", "Aquarius", "Pisces"};
            //12 available signs.
        private string[] speciesList = 
        {"Shark", "Snow Leopard", "Rabbit", "Alien", "Fox", "Wolf", "Sheep", "Skunk"};

        public Person()
        {//Default Constructor.
            name = "No Name";
            generateData();
            
        }
        public Person(string name)
        {
            this.name = name;
            generateData();
        }

        public override string ToString()
        {//Returns details of Person as a string
            return $"\n\n{name}\n\t{species}\n\t{astrologicalSign}\n{horoscope}\n\n";
        }
        
        void generateData()
        {
            generateSign();
            generateSpecies();
            generateHoroscope();
        }

        void generateSign()
        {
            int counter = 0;
            for(int i = 0; i < name.Length; i++)
            {
                counter += (int)name[i];
            }//Add up the ascii values and decide sign.
            astrologicalSign = astrologicalSigns[counter%astrologicalSigns.Length];
        }

        void generateHoroscope()
        {
            DateTime dt = DateTime.Today;
            String dateToProcess = dt.ToString("d"); //More number-y.
            String dateToPrint = dt.ToString("D"); //More readable date.

            int counter = 0;
            for(int i = 0; i < dateToProcess.Length; i++)
                counter += (int)dateToProcess[i];

            int horoscopeNumber = (counter/astrologicalSign.Length)%5;
            //5 must be updated with the number of cases below.

            switch (horoscopeNumber)
            {
                case 0:
            horoscope = dateToPrint + 
                "\n\tIt's been a long time since you talked to an old friend. \n" +
                "\tDrop them a message! They're always happy to hear from a \n" + 
                "\t" + species + " who is a " + astrologicalSign + ".\n";
                break;

                case 1:
            horoscope = dateToPrint + 
                "\n\tFor " + species + "-folk, it's important to change up your work-environment today.\n" +
                "\tEspecially since your sign is " + astrologicalSign + ".\n" +
                "\tTry a coffee shop or a different room if possible.\n" ;
                break;

                case 2:
            horoscope = dateToPrint + "\n\tLove is in store for you today, " + astrologicalSign + ".\n" +
                "\tA " + species + " like you should have no trouble connecting with someone special today! \n" + 
                "\tBe sure to follow your heart as far as it will bring you.\n";
                break;

                case 3:
            horoscope = dateToPrint + "\n\tToday may be challenging, " + astrologicalSign + "-" + species + ".\n" +
                "\tBut then again, you've gotten through every life-challenge so far!\n" +
                $"\tToday will be no different. Keep steady and channel your inner-{species}.\n";
                break;

                case 4:
            horoscope = dateToPrint + "\n\tYou've never been much of one for tradition, " + astrologicalSign + ".\n" +
                $"\tAs a {species}, there are traditions unique to your species.\n" +
                "\tJust remember that these old traditions can provide much-needed stability for you today.\n";
                break;
                
                default:
            horoscope = dateToPrint + "\n\tIt's a good day for a " + 
                species + " whose sign is " + astrologicalSign + ".\n";
                break;

                
                
            }
        }

        void generateSpecies()
        {
            species = speciesList[name.Length%speciesList.Length];

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0)
                {
                    Person currentPerson = new Person(args[0]);
                    Console.WriteLine(currentPerson);
                }
                else
                {
                    Console.WriteLine("Please enter your name!");
                    string name = Console.ReadLine();
                    Person currentPerson = new Person(name);
                    Console.WriteLine(currentPerson);
                }
            
        }

    }
}

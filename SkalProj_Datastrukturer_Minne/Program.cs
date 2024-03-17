using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, will handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            // ~ Teori of fakta ~

            // 1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion
            // S: Stacken fungerar så att det man lägger till och tar bort kommer från det översta lagret, t.ex. som en hög med böcker.
            //    För att komma åt bok nr 2 i högen så måste vi plocka bort bok nr 1 först. Vi kan alltså inte ta en bok direkt från mitten av högen utan att plocka bort de böckerna som ligger
            //    ovanpå först. Stacken håller koll på lokala variabler, samt de metoder som körs och när metoden har körts så rensas den bort från stacken igen. 
            //    
            //    I heapen lagras allt istället så att vi kan komma åt det utan att behöva flytta på något annat först. T.ex. om vi tänker oss att böckerna nu står i en stor bokhylla istället.
            //    Vi kan nu komma åt exakt den boken vi vill ha, förutsatt att vi vet vilken bok vi letar efter(adressen till boken). 
            //    Saker som lagras i heapen är sådan som lever längre än det som finns i stacken, t.ex. saker som används utanför metoder, eller en variabel som lagrar något som används på flera ställen.
            //    Heapen behöver därför "oroa sig" för garbage collectorn som körs för att samla upp och rensa det som ligger i minnet men inte längre används.
            //    T.ex. om vi har en pointer till en reference type inne i en metod så slutar pointern fungera såfort metoden körts klart, men platsen i minnet tas fortfarande upp
            //    tills dess att garbage collector körts och upptäcker att ingenting pekar på den längre och därmed rensar bort den.


            // 2. Vad är Value Types respektive Reference Types och vad skiljer dem åt? 
            // S: Value types är t.ex. bool, int, decimal, double mm. De lagrar värdet där de deklareras vilket kan vara antingen på stacken eller på heapen.
            //    Om en value type deklareras som en variabel i en metodparameter eller i själva metoden så lagras den på stacken, men om en value type lagras som t.ex. en variabel i en klass
            //    så lagras den på heapen tillsammans med klassen. 
            //    Reference types är t.ex. classes, interfaces, objects mm. De har en pointer(en adress) som pekar på en plats i minnet där värdet lagras, vilket i detta fall är på heapen.


            // 3. Följande metoder(se bild nedan) genererar olika svar.Den första returnerar 3, den andra returnerar 4, varför?
            // S: Det första exemplet har en value type av typen int med namnet x, den lagrar alltså värdet där den har deklarerats och sparas på stacken. 
            //    När y tilldelas värdet av x, så får den alltså värdet 3, men ingen koppling till variabeln x. Dvs y och x har ingen koppling, och var y gör påverkar inte x.
            //    Det andra exemplet av x är istället en reference type då vi instansierar en class. När x tilldelas värdet 3 så sparas det i heapen, dvs vi har en pointer till den platsen där
            //    värdet finns. När y skapas och tilldelas x, så har de båda en varsin pointer till samma värde på heapen, vilket just då är 3. När man sedan kör y.MyValue = 4
            //    så ändras även värdet på x, eftersom de pekar på samma plats i minnet på heapen. 


            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}


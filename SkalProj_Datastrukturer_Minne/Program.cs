using System;
using System.Diagnostics;

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
            //    ~ Teori of fakta ~

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
                    Console.Clear();
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

            List<string> theList = new List<string>();
            bool run = true;
            do
            {
                Console.WriteLine("\nPlease enter + to add, - to remove, or 0 to return to the main menu.\nFor example +Adam or -Adam to add or remove \"Adam\" from the list");
                string input = Console.ReadLine();
                Console.Clear();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    char nav = input[0]; // Sparar första charactern som användaren knappat in
                    string value = input.Substring(1); // Sparar hela user input med start från index 1, dvs tar inte med första charactern, t.ex. +Alex sparar Alex
                    
                    switch (nav) // Hoppar in i antingen case +, -, eller 0 beroende på vad användaren knappat in som sparats i nav-variabeln 
                    {
                        case '+':
                            theList.Add(value); // Lägger till user input i listan
                            Console.WriteLine($"\"{value}\" was added to the list.");
                            Console.WriteLine($"List capacity: {theList.Capacity}, count: {theList.Count}"); // Skriv ut nuvarande kapaciteten på listan, dvs hur många platser det totalt finns i listan.
                            break;                                                          // Skriver sedan ut hur många faktiska platser som är tagna i listan.

                        case '-':
                            theList.Remove(value); // Tar bort user input från listan(om det fanns med).
                            Console.WriteLine($"\"{value}\" was removed to the list.");
                            Console.WriteLine($"List capacity: {theList.Capacity}, count: {theList.Count}");
                            break;

                        case '0':
                            run = false; // Avslutar do-while loopen och returnerar till main menyn
                            break;

                        default: // Om användaren knappat in andra siffror, bokstäver, eller characters som inte finns med i ovan cases.
                            Console.WriteLine("Please only use + to add something to the list, or - to remove someting from the list");
                            break;
                    }
                    
                }
                else // T.ex. om användaren skickar in endast ett space, eller kör enter direkt utan input.
                {
                    Console.WriteLine("Invalid input.");
                }

            } while (run);

            // 1. Skriv klart implementationen av ExamineList-metoden så att undersökningen blir genomförbar.
            // S: Se ovan

            // 2. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek) 
            // S: Varje gång arrayen i listan blir full, dvs första gången vid 4:e input då den startar med 4st platser. Andra gången vid 8st inputs, tredje vid 16st osv.
            //

            // 3. Med hur mycket ökar kapaciteten? 
            // S: Den dubblas i storlek varje gång, först 4*2 = 8, sedan 8*2 = 16, 16*2 = 32...osv

            // 4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
            // S: Därför att det är mer effektivt att dubblera storleken direkt, istället för att göra en ökning varje gång något läggs till.

            // 5. Minskar kapaciteten när element tas bort ur listan? 
            // S: Nej, den minskar inte även om element tas bort ur listan.

            // 6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista? 
            // S: En array är bättre om man vet den exakta storleken i förväg, då är storleken satt direkt istället för att köra en lista som
            // behöver öka i storlek tills dess att man nått den mängden man behöver.

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
            Queue<string> theQueue = new Queue<string>(); // Instansierar en ny Queue av typen string
            bool run = true;

            do
            {
                Console.WriteLine("\nWelcome to the supermarket checkout!" +
                    "\nPlease enter 1 to add a customer to the queue, 2 to remove a person from the queue, or 0 to return to the main menu.");
                string input = Console.ReadLine();
                Console.Clear();

                if (!string.IsNullOrWhiteSpace(input))
                {

                    switch (input)
                    {
                        case "1":
                            Console.Write("Customer name: ");
                            string newCustomer = Console.ReadLine();
                            theQueue.Enqueue(newCustomer); // Lägger till user input(newCustomer) i queuen
                            Console.WriteLine($"Queue count: {theQueue.Count}" + // Skriver ut hur många värden som finns sparade i queuen just nu
                                $"\nPeople in the queue:");
                            foreach (var customer in theQueue) // Foreach för att skriva ut varje värde som sparats i queuen, dvs varje kund som står i kön i detta fall.
                            {
                                Console.WriteLine(customer);
                            }
                            break;

                        case "2":
                            if (theQueue.Count == 0) // Om queuen är tom
                            {
                                Console.WriteLine("The queue is empty");
                            }
                            else
                            {
                                theQueue.Dequeue(); // Tar bort ett värde från queuen, här väljs inte ett värde/en person utan det är alltid den som lagts till förts som tas bort vilket är varför ingen
                                Console.WriteLine($"Queue count: {theQueue.Count}" + // user input används när man kör Dequeue. Skriver här ut hur många värden som finns lagrade i queuen just nu.
                                    $"\nPeople in the queue");
                                foreach (var customer in theQueue)
                                {
                                    Console.WriteLine(customer);
                                }
                            }
                            break;

                        case "0":
                            run = false;
                            break;

                        default:
                            Console.WriteLine("Please only use 1 to add something to the queue, or 2 to remove someting from the queue");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }


            } while (run);

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

            // 1. Simulera ännu en gång ICA-kön på papper. Denna gång med en stack. Varför är det inte så smart att använda en stack i det här fallet ?
            // S: Personen som ställer sig i kön först kan potentiellt få stå där för alltid, om kön aldrig tar slut och byggs på hela tiden.

            // 2. Implementera en ReverseText-metod som läser in en sträng från användaren och med hjälp av en stack vänder ordning på teckenföljden för att sedan skriva ut den
            //    omvända strängen till användaren.
            // S: Se case 3
            
            Stack<string> theStack = new Stack<string>();
            bool run = true;

            do
            {
                Console.WriteLine("\nWelcome to the supermarket checkout!" +
                    "\n1. Add a customer to the stack" +
                    "\n2. Remove a person from the stack" +
                    "\n3. Reverse input" +
                    "\n0. Return to the main menu.");
                string input = Console.ReadLine();
                Console.Clear();

                if (!string.IsNullOrWhiteSpace(input))
                {

                    switch (input)
                    {
                        case "1":
                            Console.Write("Customer name: ");
                            string newCustomer = Console.ReadLine();
                            theStack.Push(newCustomer);  // Lägger till user input till stacken med push-metoden
                            Console.WriteLine($"Stack count: {theStack.Count}" + // Skriver ut hur många värden som finns lagrade i stacken just nu
                                $"\nPeople in the stack:");
                            foreach (var customer in theStack) // Går igenom varje värde(kund) som finns lagrade i stacken och skriver ut i konsollen
                            {
                                Console.WriteLine(customer);
                            }
                            break;

                        case "2":
                            if (theStack.Count == 0) // Om stacken är tom
                            {
                                Console.WriteLine("The stack is empty");
                            }
                            else
                            {
                                theStack.Pop(); // Pop-metoden används här för att ta bort ett värde ur stacken och det är alltid det senaste värdet som tas bort, dvs det som lades till sist.
                                Console.WriteLine($"Stack count: {theStack.Count}" +
                                    $"\nPeople in the stack");
                                foreach (var customer in theStack)
                                {
                                    Console.WriteLine(customer);
                                }
                            }
                            break;

                        case "3":
                            ReverseText(); // Fråga 2
                            break;

                        case "0":
                            run = false;
                            break;

                        default:
                            Console.WriteLine("Please only use 1 to add something to the stack, 2 to remove someting from the stack, or 3 to reverse input");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }


            } while (run);

        }

        static void ReverseText()
        {
            Stack<char> reverseStack = new Stack<char>(); // Skapar en Stack av typen char för att spara ned user input i enskilda characters för att kunna vända på orden.
            string reverseOutput = "";

            Console.Write("Please enter a word or a sentence: ");
            string userInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(userInput))
            {
                foreach (char item in userInput) // För varje character i user input, pusha(skicka/spara) till stacken. Dvs varje bokstav/siffra/symbol en och en.
                {
                    reverseStack.Push(item);
                }

                while (reverseStack.Count > 0) // Sålänge det finns minst en character så ska de poppas(plockas fram) och adderas till strängen reverseOutput.
                {
                    reverseOutput += reverseStack.Pop();
                }

                Console.WriteLine($"Your input in reverse: {reverseOutput}"); // Printa färdigställda order/meningen i reverse order mot vad användaren skickade in.
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

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


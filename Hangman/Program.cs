using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Labra02 T9
 *  Tee tekstipohjainen Hirsipuu-peli. 
 *  Voit kovakoodata arvattavan sanan ja toteuta looppi, jossa käyttäjältä kysytään seuraavaa kirjainta. 
 *  Muista näyttää aina kirjaimen jälkeen oikein arvatut kirjaimet sanan oikealla kohdalla (käytä esim _-alaviivaa ei arvattujen kirjainten kohdalla). 
 *  Voit näyttää myös jo arvatut ei käytetyt -kirjaimet. Päätä itse milloin pelaaja joutuu hirteen. 
 *  
 */

namespace T9
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                string[] words = { "time", "year", "people", "way", "day", "man", "thing", "woman", "life", "child", "world", "school",
                    "state", "family", "student", "group", "country", "problem", "hand", "part", "place", "case", "week", "company",
                    "system", "program", "question", "work", "government", "number", "night", "point", "home", "water", "room", "mother",
                    "area", "money", "story", "fact", "month", "lot", "right", "study", "book", "eye", "job", "word", "business", "issue",
                    "side", "kind", "head", "house", "service", "friend", "father", "power", "hour", "game", "line", "end", "member", "law",
                    "car", "city", "community", "name", "president", "team", "minute", "idea", "kid", "body", "information", "back", "parent",
                    "face", "others", "level", "office", "door", "health", "person", "art", "war", "history", "party", "result", "change", "morning",
                    "reason", "research", "girl", "guy", "moment", "air", "teacher", "force", "education" };

                int tries = 0; // arvausyritykset

                IList<char> guessList = new List<char>(); // arvatut kirjaimet

                Random rnd = new Random();
                int wordIndex = rnd.Next(words.Length);
                char[] original = words[wordIndex].ToCharArray(); //valitaan stringeistä yksi ja syötetään char-taulukkoon

                char[] guess = words[wordIndex].ToCharArray(); //kopioidaan ja korvataan sanan kirjaimet viivoilla
                for (int j = 0; j < guess.Length; j++)
                {
                    guess[j] = '-';
                }



                while (tries < 6)
                {
                    PrintTitle();
                    PrintGallows(tries);

                    int lines = guess.Length; // nollataan
                    int counter = 0; // nollataan counter jokaisella pyyhkimisellä


                    Console.Write("Word is: ");
                    Console.Write(guess);
                    Console.WriteLine();
                    Console.Write("You have guessed the following letters: ");
                    foreach (var k in guessList)
                    {
                        Console.Write(k + ", ");
                    }
                    Console.WriteLine();
                    Console.Write("Guess a letter: ");
                    string input = Console.ReadLine();
                    char letter = input[0];
                    letter = char.ToLower(letter);


                    while (input.Length != 1 || (!Char.IsLetter(letter)))
                    {
                        Console.WriteLine("Invalid input!");
                        Console.Write("Guess a letter: ");
                        input = Console.ReadLine();
                        letter = input[0];
                        letter = char.ToLower(letter);
                    }



                    foreach (var k in guessList)
                    {
                        while (k == letter)
                        {
                            Console.WriteLine("You already guessed that!");
                            Console.Write("Guess a letter: ");
                            input = Console.ReadLine();
                            letter = input[0];
                            letter = char.ToLower(letter);
                        }
                    }


                    guessList.Add(letter);

                    // for-loop arrayn läpi, counterilla tsekkaa montako kertaa vaihtaa kirjainta, jos 0 niin counter++
                    for (int j = 0; j < original.Length; j++)
                    {
                        if (original[j] == letter)
                        {
                            guess[j] = original[j];
                            counter++;

                        }

                        if (guess[j] != '-')
                        {
                            lines--;
                        }

                    }

                    if (lines == 0)
                    {
                        Console.WriteLine("You are victorious! The word was: " + words[wordIndex]);
                        Console.WriteLine("Try again? (y/n)");
                        TryAgain();
                    }

                    if (counter == 0)
                    {
                        tries++;
                    }


                    Console.Clear();
                }

                PrintGameOver();
                PrintGallows(tries);
                Console.WriteLine("You have failed to achieve victory. The Word was: " + words[wordIndex]);
                Console.WriteLine("Try again? (y/n)");
                TryAgain();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void PrintTitle() //Title
        {
            Console.WriteLine();
            Console.WriteLine("  ██░ ██  ▄▄▄       ███▄    █   ▄████  ███▄ ▄███▓ ▄▄▄       ███▄    █ ");
            Console.WriteLine(" ▓██░ ██▒▒████▄     ██ ▀█   █  ██▒ ▀█▒▓██▒▀█▀ ██▒▒████▄     ██ ▀█   █ ");
            Console.WriteLine(" ▒██▀▀██░▒██  ▀█▄  ▓██  ▀█ ██▒▒██░▄▄▄░▓██    ▓██░▒██  ▀█▄  ▓██  ▀█ ██▒");
            Console.WriteLine(" ░▓█ ░██ ░██▄▄▄▄██ ▓██▒  ▐▌██▒░▓█  ██▓▒██    ▒██ ░██▄▄▄▄██ ▓██▒  ▐▌██▒");
            Console.WriteLine(" ░▓█▒░██▓ ▓█   ▓██▒▒██░   ▓██░░▒▓███▀▒▒██▒   ░██▒ ▓█   ▓██▒▒██░   ▓██░");
            Console.WriteLine("  ▒ ░░▒░▒ ▒▒   ▓▒█░░ ▒░   ▒ ▒  ░▒   ▒ ░ ▒░   ░  ░ ▒▒   ▓▒█░░ ▒░   ▒ ▒ ");
            Console.WriteLine("  ▒ ░▒░ ░  ▒   ▒▒ ░░ ░░   ░ ▒░  ░   ░ ░  ░      ░  ▒   ▒▒ ░░ ░░   ░ ▒░");
            Console.WriteLine("  ░  ░░ ░  ░   ▒      ░   ░ ░ ░ ░   ░ ░      ░     ░   ▒      ░   ░ ░ ");
            Console.WriteLine("  ░  ░  ░      ░  ░         ░       ░        ░         ░  ░         ░ ");
        }

        static void PrintGallows(int i) //tulosta hirsipuu
        {
            Console.WriteLine(" ____________________________");
            Console.WriteLine("|____________________________|");
            Console.WriteLine("   |  |/ /     |     \\ \\|  |");

            if (i == 0)
            {
                Console.WriteLine("   |  | /             \\ |  |");
                Console.WriteLine("   |  |/               \\|  |");
            }

            else
            {
                Console.WriteLine("   |  | /     / \\     \\ |  |");
                Console.WriteLine("   |  |/      \\_/      \\|  |");

            }

            if (i < 2)
            {
                Console.WriteLine("   |  |                 |  |");
                Console.WriteLine("   |  |                 |  |");
                Console.WriteLine("   |  |                 |  |");
            }

            else if (i == 2)
            {
                Console.WriteLine("   |  |       | |       |  |");
                Console.WriteLine("   |  |       | |       |  |");
                Console.WriteLine("   |  |       | |       |  |");
            }

            else if (i == 3)
            {
                Console.WriteLine("   |  |      /| |       |  |");
                Console.WriteLine("   |  |     //| |       |  |");
                Console.WriteLine("   |  |    // | |       |  |");
            }

            else
            {
                Console.WriteLine("   |  |      /| |\\      |  |");
                Console.WriteLine("   |  |     //| |\\\\     |  |");
                Console.WriteLine("   |  |    // | | \\\\    |  |");
            }

            if (i < 5)
            {
                Console.WriteLine("   |  |                 |  |");
                Console.WriteLine("   |  |                 |  |");
                Console.WriteLine("   |  |                 |  |");
            }

            else if (i == 5)
            {
                Console.WriteLine("   |  |      //         |  |");
                Console.WriteLine("   |  |     //          |  |");
                Console.WriteLine("   |  |    //           |  |");
            }

            else
            {

                Console.WriteLine("   |  |      // \\\\      |  |");
                Console.WriteLine("   |  |     //   \\\\     |  |");
                Console.WriteLine("   |  |    //     \\\\    |  |");
            }

            Console.WriteLine("   |  |                 |  |");
            Console.WriteLine("   |  |                 |  |");
            Console.WriteLine(" __|__|_________________|__|__");
            Console.WriteLine("|_____________________________|");

        }

        static void PrintGameOver()
        {
            Console.WriteLine();
            Console.WriteLine("   ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  ");
            Console.WriteLine("  ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒");
            Console.WriteLine(" ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒");
            Console.WriteLine(" ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  ");
            Console.WriteLine(" ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒");
            Console.WriteLine("  ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░");
            Console.WriteLine("   ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░");
            Console.WriteLine(" ░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ ");
            Console.WriteLine("       ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     ");
        }

        static void TryAgain()
        {

            char again = ' ';
            do
            {
                again = Console.ReadKey().KeyChar;
                if (again == 'y')
                {
                    var restart = new System.Diagnostics.ProcessStartInfo(Environment.GetCommandLineArgs()[0]);
                    System.Diagnostics.Process.Start(restart);
                    System.Environment.Exit(0);
                }
                else if (again == 'n')
                {
                    System.Environment.Exit(0);
                }
            } while (again != 'y' || again != 'n');
        }
        static void InputToLowerCase()
        {
            string input = Console.ReadLine();
            char letter = input[0];
            letter = char.ToLower(letter);
        }
    }
}
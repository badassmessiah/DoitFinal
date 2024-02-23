namespace HangmanApp
{
    internal class Program
    {

        //მომხმარებელს უნდა ჰქონდეს 6 - ჯერ ასოს გახსნის საშუალება, თუ ასეთი ასო სიტყვაში ფიგურირებს უნდა გამოჩნდეს თუ რომელ პოზიციაზეა არსებული ასო.
        //ამის შემდეგ მომხმარებელმა უნდა შეიყვანოს სრულად სიტყვის დასახელება, 
        //თუ შეყვანილი სიტყვა დაემთხვა მოსაძებნ სიტყვას მომხმარებელი იგებს, წინააღმდეგ შემთხვევაში მარცხდება.
        //თუ მომხმარებელმა ექვსივეჯერ ისეთი ასო შეიყვანა რომელიც სიტყვაში საერთოდ არ ფიგურირებს მომხმარებელი უნდა დამარცხდეს.
        //თუ მომხმარებელმა ექვსი ასოს შეყვანისას სიტყვაში არსებული ყველა ასო გახსნა და გამოიცნო მომხმარებელი იმარჯვებს.
        //მომხმარებლის თამაშების ისტორია უნდა ინახებოდეს XML ფორმატში მის სახელთან და უმაღლეს ქულასთან ერთად,
        //რათა მომხმარებელმა შეძლოს TOP 10 მოთამაშის და მისი შედეგების ნახვა და რეკორდების გაუმჯობესება.

        public static int score = 0;
        public static string name = "";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman! You have 6 tries to guess the word, but first, what is your name?");

            name = Console.ReadLine();

            var word = RandomWord.GetRandomWord();

            int tries = 6;
            


            var guessedWord = new string('_', word.Length).ToCharArray();

            Console.WriteLine($"{name}, the word has " + word.Length + " characters");

            Console.WriteLine("What is your first guess?");

            do
            {
                var guess = Console.ReadLine().ToLower();

                if (guess == word)
                {
                    score = score + 10;
                    playerWon(tries);
                    break;
                }

                if (guess.Length != 1 || char.IsDigit(guess[0]))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                if (HandleGuess(guess[0], word, guessedWord, ref tries))
                {
                    break;
                }
                

                if (tries == 0)
                {
                    Console.WriteLine("You have no more tries left. Game over!");
                    break;
                }

                Console.WriteLine("What is your next guess?");

            } while (true);

            static void playerWon(int tries)
            {
                Console.WriteLine("Congratulations! You won!");
                score = score + tries;
                Console.WriteLine("Your score is: " + score);
                Save.AsXML(name, score);
                LeaderBoard.ShowLeaderBoard();
            }

            static bool HandleGuess(char guess, string word, char[] guessedWord, ref int tries)
            {
                var found = false;
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == guess)
                    {
                        guessedWord[i] = guess;
                        found = true;
                    }
                }

                if (found)
                {
                    Console.WriteLine("You are Correct!");
                    score++;
                    Console.WriteLine(guessedWord);
                    if (new string(guessedWord) == word)
                    {
                        playerWon(tries);
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("That letter is not in the word");
                    tries--;
                    Console.WriteLine("You have " + tries + " tries left.");
                }

                return false;
            }



        }
    }
}

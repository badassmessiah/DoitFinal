namespace NumberGuessingApp
{
    internal class Program
    {

        //ამ თამაშში პროგრამამ უნდა შექმნას შემთხვევითი რიცხვი, მომხმარებლის მიზანია გამოიცნოს ეს რიცხვი.
        //მომხმარებელს რიცხვის გამოსაცნობად უნდა ჰქონდეს 10 მცდელობა,
        //ყოველი შეყვანის შემდეგ პროგრამამ უნდა მიანიშნოს შემოყვანილი რიცხვი არსებულ რიცხვთან შედარებით მაღალია თუ დაბალი.
        //თუ მომხმარებელი 10 მცდელობის განმავლობაში გამოიცნობს რიცხვს ის მოიგებს, თუ არა მაშინ დამარცხდება.

        //თამაშის დაწყებისას მომხმარებელს უნდა შეეძლოს აირჩიოს თამაშის სირთულის მაჩვენებელი:
        //Easy (მარტივი) - რიცხვი   1-15 დიაპზონში.
        //Medium (საშუალო) - რიცხვი - 1-25 დიაპაზონში.
        //Hard (რთული) - რიცხვი - 1-50 დიაპაზონში.

        //მომხმარებლის თამაშების ისტორია უნდა ინახებოდეს CSV ფორმატში მის სახელთან და უმაღლეს ქულასთან ერთად,
        //რათა მომხმარებელმა შეძლოს TOP 10 მოთამაშის და მისი შედეგების ნახვა და რეკორდების გაუმჯობესება.

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, This is Number Guessing Game.");

            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            int score = 0;

            int min = 1;
            int max = DifficultyChooser.ChooseDifficulty();


            int number = new Random().Next(min, max);
            int attempts = 10;

            
            while (attempts > 0)
            {
                Console.WriteLine($"Please enter your guess (1-{max}): ");
                string input = Console.ReadLine();
                int guess;

                if (int.TryParse(input, out guess))
                {
                    if (guess == number)
                    {
                        Console.WriteLine($"Congratulations, {name}! You have guessed the number.");
                        score = attempts;
                        break;
                    }
                    else if (guess > number)
                    {
                        Console.WriteLine("The number is lower.");
                    }
                    else
                    {
                        Console.WriteLine("The number is higher.");
                    }

                    attempts--;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                
            }



            
        }
    }
}

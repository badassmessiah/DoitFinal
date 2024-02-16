namespace NumberGuessingApp
{
    public static class InputValidation
    {
        public static string ValidateDifficulty(string input)
        {
            if (input == "e" || input == "m" || input == "h")
            {
                return input;
            }
            else
            {
                return "Invalid input. Please choose difficulty again.";
            }
        }
    }
}

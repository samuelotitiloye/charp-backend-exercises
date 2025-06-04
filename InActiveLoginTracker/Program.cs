namespace InActiveLoginTracker
{
    public class Program
    {
        public static ParsedInput PromptUserForInput()
        {
            string fileName = string.Empty;
            int expirationThreshold = 0;
            
            // 1. Ask user for file name
            // 2. Check if file exists — if not, ask again
            while (true)
            {
                Console.WriteLine("Enter the path to the login data file(.json or .csv): ");
                string? userInput = Console.ReadLine(); // ask user for file name?

                if (!string.IsNullOrEmpty(userInput) && File.Exists(userInput))
                {
                    fileName = userInput;
                    break;// exit loop
                }
                else
                {
                    Console.WriteLine("File is not found. Please enter a valid file path:");
                }
            }

            // 3. Ask for expiration threshold
            while (true)
            {
                Console.WriteLine("Enter expiration threshold in days (positive number): ");
                string? thresholdInput = Console.ReadLine();
                // 4. Check if it's a valid int > 0 — if not, ask again
                if(int.TryParse(thresholdInput, out int parsedThreshold) && parsedThreshold > 0)
                {
                    expirationThreshold = parsedThreshold;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid number. Please enter a positive integer.");
                }
            } 
            // 5. Return ParsedInput with both value
            return new ParsedInput
            {
                FileName = fileName,
                ExpirationThreshold = expirationThreshold
            };
        }
    }
}
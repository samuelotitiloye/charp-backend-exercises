namespace InActiveLoginTracker
{
    public class Program
    {
        public static ParsedInput PromptUserForInput()
        {
            // 1. Ask user for file name
            string? userInput = Console.ReadLine();
            // 2. Check if file exists — if not, ask again
            if (File.Exists(userInput))
            {
                //
            }

            // 3. Ask for expiration threshold
            // 4. Check if it's a valid int > 0 — if not, ask again
            // 5. Return ParsedInput with both value

        }
    }
}
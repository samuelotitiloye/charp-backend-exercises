using System;
using System.Collections.Generic;
using InActiveLoginTracker.Models;


public static ParsedInput? ParseArgs(string[] args )
{
    if (args.Length <= 2) // not enough arguments
    {
        return null;
    }
    string FileName = args[0];
    string thresholdInput = args[1];

    if (!File.Exists(FileName)) // invalid file
    {
        return null;
    }

    if (!int.TryParse(thresholdInput, out int threshold))
    {
        return null; // invalid threshold
    }

    return new ParsedInput
    {
        FileName = fileName,
        ExpirationThreshold = threshold,
   };
}








//args[] available?
// ├─ Yes → Try ParseArgs(args)
// |       ├─ Valid? → Use it
// |       └─ Invalid? → Show error, exit or prompt
//└─ No  → PromptUserForInput()

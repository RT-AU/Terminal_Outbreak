using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Outbreak.Mainframe
{
    internal static class Utils
    {
        public static bool PressEnter()
        {
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
            return true;
        }

        public static void ExitGame()
        {
            Environment.Exit(0);
        }

        internal static string FrameText(string text, string additionalString = "")
        {
            string headerString = "| " + text + additionalString + " |";
            string borderString = "";
            while (borderString.Length < headerString.Length)
            {
                borderString += "-";
            }

            string line = $"{borderString}{Environment.NewLine}{headerString}{Environment.NewLine}{borderString}";

            return line;
        }
        internal static string WrapText(string text)
        {
            int consoleWidth = Console.WindowWidth;
            // Split the text into words
            string[] words = text.Split(' ');

            // Initialize variables to keep track of line length
            int lineLength = 0;
            string line = "";

            // Iterate through each word
            foreach (string word in words)
            {
                // If adding the word exceeds the width, start a new line
                if (lineLength + word.Length + 1 > consoleWidth)
                {
                    line += Environment.NewLine; // Start a new line
                    lineLength = 0; // Reset line length
                }

                // Add the word to the current line
                line += word + " ";
                lineLength += word.Length + 1; // Include space after each word
            }

            return line;
        }

        


    }

    


}


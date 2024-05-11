using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Outbreak.Mainframe
{
    internal class Menu // Class which creates the logic for controlling the game through the arrow keys rather than requiring text input.
    {
        private string mainTitle;
        private string initialDisplay;
        private List<string> options;
        private int selectedIndex;

        public Menu(string initialDisplay, List<string> options, string mainTitle = "")
        {
            this.mainTitle = mainTitle;
            this.initialDisplay = initialDisplay;
            this.options = options;
            selectedIndex = 0;
        }

        private void DrawDisplay()
        {
            if (mainTitle != "")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(mainTitle);
                Console.ResetColor();
            }

            Console.WriteLine(initialDisplay);

            for (int i = 0; i < options.Count; i++)
            {
                if (options[i] == "")
                {
                    continue;
                }
                string currentOption = options[i];
                string indicator;

                if (i == selectedIndex)
                {
                    indicator = "-> ";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    indicator = "  ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine($"{indicator} << {currentOption} >>");
            }
            Console.ResetColor();
        }

        private void DrawSubDisplay()
        {
            if (mainTitle != "")
            {
                Console.WriteLine(mainTitle);
            }

            Console.WriteLine(initialDisplay);

            for (int i = 0; i < options.Count; i++)
            {
                if (options[i] == "")
                {
                    continue;
                }
                string currentOption = options[i];
                string indicator;

                if (i == selectedIndex)
                {
                    indicator = "-> ";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    indicator = "  ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine($"{indicator} << {currentOption} >>");
            }
            Console.ResetColor();
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DrawDisplay();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                //update selectedIndex based on arrow keys
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex == -1)
                    {
                        selectedIndex = options.Count - 1;
                    }


                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == options.Count)
                    {
                        selectedIndex = 0;
                    }

                }
            }
            while (keyPressed != ConsoleKey.Enter);

            return selectedIndex;
        }

        public int RunHeaderVersion()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DrawSubDisplay();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                //update selectedIndex based on arrow keys
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex == -1)
                    {
                        selectedIndex = options.Count - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == options.Count)
                    {
                        selectedIndex = 0;
                    }

                }
            }
            while (keyPressed != ConsoleKey.Enter);

            return selectedIndex;
        }

        public string RunRemovable(List<string> optionNames) // function for menus where options should be removed after certain conditions (i.e. after buying hiring an ally)
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DrawSubDisplay();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                //update selectedIndex based on arrow keys
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex == -1)
                    {
                        selectedIndex = options.Count - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == options.Count)
                    {
                        selectedIndex = 0;
                    }

                }
            }
            while (keyPressed != ConsoleKey.Enter);
            string selectedOption = optionNames[selectedIndex];

            return selectedOption;
        }
    }
}

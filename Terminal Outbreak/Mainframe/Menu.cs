using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Outbreak.Mainframe
{
    internal class Menu
    {
        private string mainTitle;
        private string initialDisplay;
        private string[] options;
        private int selectedIndex;


        public Menu(string initialDisplay, string[] options, string mainTitle = "")
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

            for (int i = 0; i < options.Length; i++)
            {
                string currentOption = options[i];
                string indicator;

                if (i == selectedIndex)
                {
                    indicator = "->";
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
                        selectedIndex = options.Length - 1;
                    }


                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == options.Length)
                    {
                        selectedIndex = 0;
                    }

                }
            }
            while (keyPressed != ConsoleKey.Enter);

            return selectedIndex;
        }
    }
}

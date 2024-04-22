using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes
{
    internal class BuildTrapsScene : Scene
    {

        public BuildTrapsScene(TerminalOutbreakGame game) : base(game)
        {

        }
        public override void Run()
        {

            string header = Utils.FrameText("Build Traps");
            string display = $"The following traps are available for you to build:";
            display += $"{terminalOutbreakGame.baseManager.getTraps()}{Environment.NewLine}";
            string[] options = { "Build Spike Trap", "Build Blade Trap", "Build Flame Trap", "Build Turret Trap", "Return" }; // will need to either work out a way to remove or just display a message when a trap has already been built

            Menu resupplyResultsMenu = new Menu(display, options, header);
            int selectedIndex = resupplyResultsMenu.RunHeaderVersion();

            switch (selectedIndex)
            {
                case 0:
                    if(terminalOutbreakGame.baseManager.GetTrap(selectedIndex).IsBuilt()==false)
                    {
                        terminalOutbreakGame.baseManager.BuildTrap(selectedIndex);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Build Traps"));
                        Console.WriteLine($"{Environment.NewLine}The {terminalOutbreakGame.baseManager.GetTrap(selectedIndex).GetTrapName()} has already been built! You can only build one of each trap.{Environment.NewLine}Press enter to continue.");
                        Utils.PressEnter();
                    }
                    this.Run();
                    break;
                case 1:
                    if (terminalOutbreakGame.baseManager.GetTrap(selectedIndex).IsBuilt() == false)
                    {
                        terminalOutbreakGame.baseManager.BuildTrap(selectedIndex);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Build Traps"));
                        Console.WriteLine($"{Environment.NewLine}The {terminalOutbreakGame.baseManager.GetTrap(selectedIndex).GetTrapName()} has already been built! You can only build one of each trap.{Environment.NewLine}Press enter to continue.");
                        Utils.PressEnter();
                    }
                    this.Run();
                    break;
                case 2:
                    if (terminalOutbreakGame.baseManager.GetTrap(selectedIndex).IsBuilt() == false)
                    {
                        terminalOutbreakGame.baseManager.BuildTrap(selectedIndex);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Build Traps"));
                        Console.WriteLine($"{Environment.NewLine}The {terminalOutbreakGame.baseManager.GetTrap(selectedIndex).GetTrapName()} has already been built! You can only build one of each trap.{Environment.NewLine}Press enter to continue.");
                        Utils.PressEnter();
                    }
                    this.Run();
                    break;
                case 3:
                    if (terminalOutbreakGame.baseManager.GetTrap(selectedIndex).IsBuilt() == false)
                    {
                        terminalOutbreakGame.baseManager.BuildTrap(selectedIndex);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Build Traps"));
                        Console.WriteLine($"{Environment.NewLine}The {terminalOutbreakGame.baseManager.GetTrap(selectedIndex).GetTrapName()} has already been built! You can only build one of each trap.{Environment.NewLine}Press enter to continue.");
                        Utils.PressEnter();
                    }
                    this.Run();
                    break;
                case 4:
                    terminalOutbreakGame.constructionChoiceScene.Run();
                    break;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes.CombatScenes
{
    internal class CloseQuartersCombatScene : Scene
    {
        public CloseQuartersCombatScene(TerminalOutbreakGame game) : base(game)
        {

        }

        public override void Run()
        {
            string header = Utils.FrameText("Nightfall - Close Quarters");
            string display = $"{Environment.NewLine}XNUMBEROFZOMBIES are now within close quarters. What weapon would you like to use?{Environment.NewLine}"; // TO DO // get this up and running for CQ combat

            List<string> options = new List<string>();
            options.Add("Primary Weapon");
            options.Add("Secondary Weapon");
            options.Add("Melee Weapon");

            Menu resupplyResultsMenu = new Menu(display, options, header);
            int selectedIndex = resupplyResultsMenu.RunHeaderVersion();

            switch (selectedIndex)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("Bang you kill some zombies"); // TO DO --- SET UP ACTUAL COMBAT, if zombies not yet dead, repeat
                    Utils.PressEnter();
                    terminalOutbreakGame.closeQuartersCombatScene.Run();
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("Bang you kill some zombies"); // TO DO --- SET UP ACTUAL COMBAT
                    Utils.PressEnter();
                    terminalOutbreakGame.closeQuartersCombatScene.Run();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("You kill 0 zombies. Your Allies killed 0 zombies. Your Traps killed 0 zombies."); // TO DO --- SET UP ACTUAL COMBAT for Allies and Traps
                    Utils.PressEnter();
                    terminalOutbreakGame.closeQuartersCombatScene.Run();
                    break;
            }
        }
    }
}

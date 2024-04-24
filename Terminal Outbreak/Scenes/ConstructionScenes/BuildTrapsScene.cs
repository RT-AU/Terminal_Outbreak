using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;
using Terminal_Outbreak.Defences;

namespace Terminal_Outbreak.Scenes.ConstructionScenes
{
    internal class BuildTrapsScene : Scene
    {
        private bool spikeTrapBuilt = false;
        private bool bladeTrapBuilt = false;
        private bool flameTrapBuilt = false;
        private bool turretTrapBuilt = false;

        public BuildTrapsScene(TerminalOutbreakGame game) : base(game)
        {

        }
        public override void Run()
        {

            string header = Utils.FrameText("Build Traps");
            string display = $"The following traps are available for you to build:";
            display += $"{terminalOutbreakGame.baseManager.getTraps()}{Environment.NewLine}";

            List<string> options = new List<string>();
            if (!spikeTrapBuilt) { options.Add("Build Spike Trap"); }
            if (!bladeTrapBuilt) { options.Add("Build Blade Trap"); }
            if (!flameTrapBuilt) { options.Add("Build Flame Trap"); }
            if (!turretTrapBuilt) { options.Add("Build Turret Trap"); }
            options.Add("RETURN");

            if (options.Count == 1)
            {
                display = Utils.WrapText($"{Environment.NewLine}There are no more traps available to build!{Environment.NewLine}");
            }

            Menu resupplyResultsMenu = new Menu(display, options, header);
            string selectedOption = resupplyResultsMenu.RunRemovable(options);

            int selectedIndex = 5;
            if (selectedOption.Contains("Spike Trap")) { selectedIndex = 0; }
            if (selectedOption.Contains("Blade Trap")) { selectedIndex = 1; }
            if (selectedOption.Contains("Flame Trap")) { selectedIndex = 2; }
            if (selectedOption.Contains("Turret Trap")) { selectedIndex = 3; }
            if (selectedOption.Contains("RETURN")) { selectedIndex = 4; }

            switch (selectedIndex)
            {
                case 0:
                    if (terminalOutbreakGame.baseManager.GetTrap(selectedIndex).IsBuilt() == false)
                    {
                        terminalOutbreakGame.baseManager.BuildTrap(selectedIndex);
                        spikeTrapBuilt = true;
                    }
                    Run();
                    break;
                case 1:
                    if (terminalOutbreakGame.baseManager.GetTrap(selectedIndex).IsBuilt() == false)
                    {
                        terminalOutbreakGame.baseManager.BuildTrap(selectedIndex);
                        bladeTrapBuilt = true;
                    }
                    Run();
                    break;
                case 2:
                    if (terminalOutbreakGame.baseManager.GetTrap(selectedIndex).IsBuilt() == false)
                    {
                        terminalOutbreakGame.baseManager.BuildTrap(selectedIndex);
                        flameTrapBuilt = true;
                    }
                    Run();
                    break;
                case 3:
                    if (terminalOutbreakGame.baseManager.GetTrap(selectedIndex).IsBuilt() == false)
                    {
                        terminalOutbreakGame.baseManager.BuildTrap(selectedIndex);
                        turretTrapBuilt = true;
                    }
                    Run();
                    break;
                case 4:
                    terminalOutbreakGame.constructionChoiceScene.Run();
                    break;                    
                case 5:
                    Console.WriteLine("Error in Option Selection");
                    break;
            }

        }
    }
}

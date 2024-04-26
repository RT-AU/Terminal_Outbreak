using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes.InfoScreens
{
    internal class WarningScene : Scene
    {
        public WarningScene(TerminalOutbreakGame game) : base(game)
        {

        }

        public void RunNoWeaponWarning()
        {
            string header = Utils.FrameText("CAUTION ADVISED");
            string display = Utils.WrapText($"{Environment.NewLine}You currently have no weapons equipped! You can buy weapons from the trader. If you have already obtained a weapon, make sure to equip it in the Equip Weapons menu! I would advise buying at least a secondary weapon, as Melee weapons aren't useful until the zombies are within melee range.{Environment.NewLine}");

            List<string> options = new List<string>();
            options.Add("RETURN");
            options.Add("IGNORE");

            Menu warningMenu = new Menu(display, options, header);
            int selectedIndex = warningMenu.RunHeaderVersion();

            switch (selectedIndex)
            {
                case 0:
                    terminalOutbreakGame.baseScene.Run();
                    break;
                case 1:
                    Console.WriteLine("Are you sure? This is not advised. y/n");
                    Console.CursorVisible = true;
                    string? choice = Console.ReadLine()?.ToLower();
                    if (choice == "y" || choice == "yes")
                    {
                        Console.CursorVisible = false;
                        return;
                    }
                    else
                    {
                        Console.CursorVisible = false;
                        this.Run();
                    }
                    break;
            }
        }

        public void GameOverKilled()
        {
            string header = Utils.FrameText("GAME OVER");
            string display = Utils.WrapText($"{Environment.NewLine}{terminalOutbreakGame.player.GetName()} has been killed! As your base is overrun, everything you've worked for is totally destroyed. It was all for naught. Your story ends here.{Environment.NewLine}");

            List<string> options = new List<string>();
            options.Add("EXIT GAME");

            Menu warningMenu = new Menu(display, options, header);
            int selectedIndex = warningMenu.RunHeaderVersion();

            switch (selectedIndex)
            {
                case 0:
                    Utils.ExitGame();
                    break;
            }
        }

        public void GameOverStarved()
        {
            string header = Utils.FrameText("GAME OVER");
            string display = Utils.WrapText($"{Environment.NewLine}You ran out of rations! No matter how hard {terminalOutbreakGame.player.GetName()} seached, they just couldn't find enough food, eventually become too weak to carry on. Your story ends here.{Environment.NewLine}");

            List<string> options = new List<string>();
            options.Add("EXIT GAME");

            Menu warningMenu = new Menu(display, options, header);
            int selectedIndex = warningMenu.RunHeaderVersion();

            switch (selectedIndex)
            {
                case 0:
                    Utils.ExitGame();
                    break;
            }
        }
    }
}

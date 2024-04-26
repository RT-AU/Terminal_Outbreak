using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes.EquippingScenes
{
    internal class EquipmentScene : Scene
    {

        public EquipmentScene(TerminalOutbreakGame game) : base(game)
        {

        }

        public override void Run()
        {
            string header = Utils.FrameText("Equip Weapons");
            
            string display = Utils.WrapText($"{Environment.NewLine}Which slot would you like to equip a weapon for?{Environment.NewLine}");

            List<string> options = new List<string>();
            options.Add("Equip Primary Weapons");
            options.Add("Equip Secondary Weapons");
            options.Add("Equip Melee Weapons");
            options.Add("RETURN");

            Menu resupplyResultsMenu = new Menu(display, options, header);
            int selectedIndex = resupplyResultsMenu.RunHeaderVersion();

            switch (selectedIndex)
            {
                case 0:
                    terminalOutbreakGame.equipPrimaryScene.Run();
                    break;
                case 1:
                    terminalOutbreakGame.equipSecondaryScene.Run();
                    break;
                case 2:
                    terminalOutbreakGame.equipMeleeScene.Run();
                    break;
                case 3:
                    terminalOutbreakGame.baseScene.Run();
                    break;
            }
        }
    }
}

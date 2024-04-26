using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Items;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes
{
    internal class ResupplyScene : Scene
    {
        
        private List<Resource> resources;
        private List<Weapon> equipment;
        private bool failedRun;


        public ResupplyScene(TerminalOutbreakGame game) : base(game)
        {
            resources = new List<Resource>();
            equipment = new List<Weapon>();
            failedRun = false;
        }

        public override void Run()
        {
            string header = Utils.FrameText("Resupply Run");

            
            string display = Utils.WrapText($"{Environment.NewLine}You prepare to head out on a resupply run.{Environment.NewLine}");

            if (terminalOutbreakGame.baseManager.GetTime() == 0)
            {
                display = Utils.WrapText($"There is not enough time to go on a supply run! Night has fallen!.");
                display += Environment.NewLine;
            }
            else if (failedRun == true)
            {
                    display = Utils.WrapText($"There is not enough time to go on a supply run! Only {terminalOutbreakGame.baseManager.GetTime()} hours remain before nightfall.");
                    display += Environment.NewLine;
            }
            else
            {
                display += Utils.WrapText($"{Environment.NewLine}How much time do you want to spend looking for supplies?{Environment.NewLine}");
            }

            
            List<string> options = new List<string>();
            options.Add("Long Resupply Run - 8hrs");
            options.Add("Short Resupply Run - 4hrs");
            options.Add("RETURN");

            Menu resupplyMenu = new Menu(display, options, header);
            int selectedIndex = resupplyMenu.RunHeaderVersion();

            switch (selectedIndex)
            {
                case 0: // Long Supply Run
                    SupplyRun(8.00f);
                    break;
                
                case 1: //Short Supply Run
                    SupplyRun(4.00f);
                    break;
                
                case 2:// resets failedRun and returns to previous menu
                    failedRun = false;
                    terminalOutbreakGame.baseScene.Run();
                    break;
            }
        }

        private void SupplyRun(float timeTaken)
        {
            float actionTime = timeTaken;
            if (terminalOutbreakGame.baseManager.GetTime() >= actionTime)
            {
                failedRun = false;
                terminalOutbreakGame.baseManager.ReduceTime(actionTime);                                // subtracts the actionTime from the time remaining in the day //
                List<Resource> resultsList = terminalOutbreakGame.resourceManager.Resupply(actionTime); // fetches gathered resources and passes in actionTime to differentiate long and short supply runs
                
                Dictionary<string, int> resourceCounts = new Dictionary<string, int>();
                
                foreach (Resource resource in resultsList)
                {
                    // If resource name exists in dictionary, increment its count
                    if (resourceCounts.ContainsKey(resource.GetResourceName()))
                    {
                        resourceCounts[resource.GetResourceName()]++;
                    }
                    // Otherwise, add the resource name to the dictionary with count 1
                    else
                    {
                        resourceCounts[resource.GetResourceName()] = 1;
                    }
                }
                string results = "";

                foreach (var kvp in resourceCounts)
                {
                    results += $"{Environment.NewLine}{kvp.Key}: {kvp.Value}";
                }

                string header = Utils.FrameText("Results");
                string display = $"Spent {actionTime} hours looking and found:{Environment.NewLine}{results}{Environment.NewLine}";

                List<string> options = new List<string>();
                options.Add("RETURN");


                Menu resupplyResultsMenu = new Menu(display, options, header);
                int selectedIndex = resupplyResultsMenu.RunHeaderVersion();

                //switch (selectedIndex) { case 0: terminalOutbreakGame.baseScene.Run(); break; };  
                switch (selectedIndex) { case 0: this.Run(); break; };  
                            
            }
            else
            {
                failedRun = true;
                this.Run(); // calls the scene again with updated info
            }
        }
    }
}
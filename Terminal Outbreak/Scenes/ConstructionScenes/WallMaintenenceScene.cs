using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes.ConstructionScenes
{
    internal class WallMaintenenceScene : Scene
    {
        int resourceRequiredID;
        int buildAmount;
        int repairAmount;
        int buildTime;
        int repairTime;
        public WallMaintenenceScene(TerminalOutbreakGame game) : base(game)
        {
            resourceRequiredID = 1;
            buildAmount = 20;
            repairAmount = 5;
            buildTime = 6;
            repairTime = 2;
        }

        public override void Run()
        {
            bool barrierBuilt = terminalOutbreakGame.baseManager.IsBarrierBuilt();
            bool barrierDestroyed = terminalOutbreakGame.baseManager.IsBarrierDestroyed();
            string header = Utils.FrameText("Construction Options");
            string display = string.Empty;
            if (barrierBuilt)
            {
                display = Utils.WrapText($"{Environment.NewLine}When the wall is standing, it forces enemies to stay at long range for an extra 5 rounds, at which point they will destroy the wall. It can be repaired for 5 wood and 2 hours of work.{Environment.NewLine}");
            }
            else
            {
                display = Utils.WrapText($"{Environment.NewLine}You can construct a barrier wall to keep the Zombies from advancing beyond Long Range until they destroy it. Construction will cost 20 Wood and will take 6 hours to complete. When it is standing, it will force enemies to stay at long range for an extra 5 rounds, at which point they will destroy the wall. It can be repaired for 5 wood and 2 hours of work.{Environment.NewLine}");
            }

            List<string> options = new List<string>();
            if (barrierBuilt)
            {
                options.Add("Repair Barrier Wall");
            }
            else
            {
                options.Add("Construct Barrier Wall");
            }

            options.Add("RETURN");
            Menu resupplyResultsMenu = new Menu(display, options, header);
            int selectedIndex = resupplyResultsMenu.RunHeaderVersion();

            switch (selectedIndex)
            {
                case 0:
                    if (barrierBuilt)
                    {
                        if(barrierDestroyed) // Repair Barrier
                        {
                            bool baseWoodSupplies = terminalOutbreakGame.resourceManager.CheckResourceQuantity(resourceRequiredID, repairAmount);
                            if (baseWoodSupplies && terminalOutbreakGame.baseManager.GetTime() >= repairTime)
                            {
                                Console.Clear();
                                Console.WriteLine(Utils.FrameText("Wall Repaired"));
                                Console.WriteLine("You successfully repaired the barrier wall!");
                                Console.WriteLine($"{Environment.NewLine}Press ENTER to Continue");
                                Utils.PressEnter();
                                terminalOutbreakGame.baseManager.RepairBarrier();
                                terminalOutbreakGame.resourceManager.ReduceResourceQuantity(resourceRequiredID, repairAmount);
                                terminalOutbreakGame.baseManager.ReduceTime(repairTime);
                            }
                            else if (!baseWoodSupplies)
                            {
                                Console.Clear();
                                Console.WriteLine(Utils.FrameText("Repairs Failed"));
                                Console.WriteLine($"{Environment.NewLine}Not enough wood to repair the barrier wall!");
                                Console.WriteLine($"{Environment.NewLine}Press ENTER to Continue");
                                Utils.PressEnter();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(Utils.FrameText("Repairs Failed"));
                                Console.WriteLine($"{Environment.NewLine}Not enough time to repair the barrier wall");
                                Console.WriteLine($"{Environment.NewLine}Press ENTER to Continue");
                                Utils.PressEnter();
                            }
                        }
                        else if (terminalOutbreakGame.baseManager.GetTime() >= repairTime)
                        {
                            Console.Clear();
                            Console.WriteLine(Utils.FrameText("Repairs Not Necessary"));
                            Console.WriteLine($"{Environment.NewLine}The wall is still standing! No need to repair it.");
                            Console.WriteLine($"{Environment.NewLine}Press ENTER to Continue");
                            Utils.PressEnter();
                        }
                        
                    }
                    else // build the barrier
                    {
                        bool baseWoodSupplies = terminalOutbreakGame.resourceManager.CheckResourceQuantity(resourceRequiredID, buildAmount);
                        if (baseWoodSupplies && terminalOutbreakGame.baseManager.GetTime() >= buildTime)
                        {
                            Console.Clear();
                            Console.WriteLine(Utils.FrameText("Constructon Completed"));
                            Console.WriteLine($"{Environment.NewLine}You successfully built the barrier wall!");
                            Console.WriteLine($"{Environment.NewLine}Press ENTER to Continue");
                            Utils.PressEnter();
                            terminalOutbreakGame.baseManager.BuildBarrer();
                            terminalOutbreakGame.resourceManager.ReduceResourceQuantity(resourceRequiredID, buildAmount);
                            terminalOutbreakGame.baseManager.ReduceTime(buildTime);
                        }
                        else if (!baseWoodSupplies)
                        {
                            Console.Clear();
                            Console.WriteLine(Utils.FrameText("Construction Failed"));
                            Console.WriteLine($"{Environment.NewLine}Not enough wood to build the barrier wall.");
                            Console.WriteLine($"{Environment.NewLine}Press ENTER to Continue");
                            Utils.PressEnter();
                        }
                        else if (terminalOutbreakGame.baseManager.GetTime() < buildTime)
                        {
                            Console.Clear();
                            Console.WriteLine(Utils.FrameText("Construction Failed"));
                            Console.WriteLine($"{Environment.NewLine}Not enough time to construct barrier wall!");
                            Console.WriteLine($"{Environment.NewLine}Press ENTER to Continue");
                            Utils.PressEnter();
                        }

                    }
                    Run();
                    break;
                case 1:
                    terminalOutbreakGame.constructionChoiceScene.Run();
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes.ConstructionScenes
{
    internal class RepairHelicopterScene : Scene
    {
        int metalRequired;
        int fuelRequired;
        int enginePartsRequired;
        int electricalKitRequired;
        int repairTime;
        bool metalSessionCompleted;
        bool fuelSessionCompleted;
        bool engineSessionCompleted;
        bool electricalSessionCompleted;
        bool helicopterRepaired;
        public RepairHelicopterScene(TerminalOutbreakGame game) : base(game)
        {
            // On construction, set cost for helicopter repair so that repairs can be done over time
            metalRequired = 50;
            fuelRequired = 30;
            enginePartsRequired = 12;
            electricalKitRequired = 4;
            repairTime = 24;
            metalSessionCompleted = false;
            fuelSessionCompleted = false;
            engineSessionCompleted = false;
            electricalSessionCompleted = false;
        
        }

        public override void Run()
        {
            helicopterRepaired = terminalOutbreakGame.baseManager.IsHelicopterFixed();
            
            string header = Utils.FrameText("Repair Helicopter");
            string display = Utils.WrapText($"{Environment.NewLine}To repair the helicopter, you will require the following resources and 24 hours of work. The work can be split up into four 6-hour sessions, with a session available every time one of the resource requirements is fulfulled.");
            display += $"{Environment.NewLine}{Environment.NewLine}{metalRequired} Metal{Environment.NewLine}{fuelRequired} Fuel{Environment.NewLine}{enginePartsRequired} Engine Parts{Environment.NewLine}{electricalKitRequired} Electrical Kit{Environment.NewLine}{Environment.NewLine}{repairTime} hours of work still required{Environment.NewLine}";

            List<string> options = new List<string>();
            options.Add("Allocate Supplies for Repair");
            options.Add("Repair Helicopter - 6 Hours");
            options.Add("RETURN");


            Menu resupplyResultsMenu = new Menu(display, options, header);
            int selectedIndex = resupplyResultsMenu.RunHeaderVersion();

            switch (selectedIndex)
            {
                case 0:
                    terminalOutbreakGame.allocateResourcesScene.RunAllocation(metalRequired, fuelRequired, enginePartsRequired, electricalKitRequired);
                    break;
                case 1:
                    if (terminalOutbreakGame.baseManager.GetTime() >= 6)
                    {
                        if (metalRequired == 0 && metalSessionCompleted == false) // Fix Metals on the Helicopter
                        {
                            repairTime -= 6;
                            terminalOutbreakGame.baseManager.ReduceTime(6f);
                            metalSessionCompleted = true;
                            Console.Clear();
                            Console.WriteLine(Utils.FrameText("Frame Repaired"));
                            Console.WriteLine(Utils.WrapText($"{Environment.NewLine}You spend 6 hours bolting the lightest scraps of metal you could find onto the helicopter frame. It doesn't look pretty, but it shouldn't snap in half mid-flight. Hopefully."));
                            Console.WriteLine($"{Environment.NewLine}Press ENTER to continue.");
                            Utils.PressEnter();
                        }
                        else if (fuelRequired == 0 && fuelSessionCompleted == false) // Fix Fuel on the Helicopter
                        {
                            repairTime -= 6;
                            terminalOutbreakGame.baseManager.ReduceTime(6f);
                            fuelSessionCompleted = true;
                            Console.Clear();
                            Console.WriteLine(Utils.FrameText("Refuelling Completed"));
                            Console.WriteLine(Utils.WrapText($"{Environment.NewLine}You spend 6 hours checking the fuel lines, fuel tanks, and then refuelling the helicopter using a whole 20 canisters. That should be enough to get to the next town...right?"));
                            Console.WriteLine($"{Environment.NewLine}Press ENTER to continue.");
                            Utils.PressEnter();
                        }
                        else if (enginePartsRequired == 0 && engineSessionCompleted == false) // Fix Engine on the Helicopter
                        {
                            repairTime -= 6;
                            terminalOutbreakGame.baseManager.ReduceTime(6f);
                            engineSessionCompleted = true;
                            Console.Clear();
                            Console.WriteLine(Utils.FrameText("Engine Repaired"));
                            Console.WriteLine(Utils.WrapText($"{Environment.NewLine}You spend 6 hours working on the engine like some kind of apocalyptic heavy-diesel Frankenstein, and this is your monster. It might be your eyes playing tricks on you, but it almost looks like there are more parts left over than when you started...Damn you're good."));
                            Console.WriteLine($"{Environment.NewLine}Press ENTER to continue.");
                            Utils.PressEnter();
                        }
                        else if (electricalKitRequired == 0 && electricalSessionCompleted == false) // Fix Electricals on the Helicopter
                        {
                            repairTime -= 6;
                            terminalOutbreakGame.baseManager.ReduceTime(6f);
                            electricalSessionCompleted = true;

                            Console.Clear();
                            Console.WriteLine(Utils.FrameText("Electrics Repaired"));
                            Console.WriteLine(Utils.WrapText($"{Environment.NewLine}You spend 6 hours working on the electrics. If you were doing this in the mythic age the people would've called you Thor...because of the way sparks have been flying out of everything you touch. But hey, at least that means the battery is still good, right?"));
                            Console.WriteLine($"{Environment.NewLine}Press ENTER to continue.");
                            Utils.PressEnter();
                        }
                        else if (helicopterRepaired == false) // Nothing to work on yet
                        {
                            Console.Clear();
                            Console.WriteLine(Utils.FrameText("Nothing To Work On Yet"));
                            Console.WriteLine(Utils.WrapText($"{Environment.NewLine}There's nothing to work on yet. You'll need to find and allocate some parts first."));
                            Console.WriteLine($"{Environment.NewLine}Press ENTER to continue.");
                            Utils.PressEnter();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(Utils.FrameText("Helicopter Already Repaired!"));
                            Console.WriteLine(Utils.WrapText($"{Environment.NewLine}The Helicopter has already been repaired! End the Preperation Phase to Depart!"));
                            Console.WriteLine($"{Environment.NewLine}Press ENTER to continue.");
                            Utils.PressEnter();
                            
                        }
                    }
                    else // if helicopter is repaired. change the end preperation step into escape 
                    {
                        if (helicopterRepaired)
                        {
                            Console.Clear();
                            Console.WriteLine(Utils.FrameText("Helicopter Already Repaired!"));
                            Console.WriteLine(Utils.WrapText($"{Environment.NewLine}The Helicopter has already been repaired! End the Preperation Phase to Depart!"));
                            Console.WriteLine($"{Environment.NewLine}Press ENTER to continue.");
                            Utils.PressEnter();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(Utils.FrameText("Not Enough Time"));
                            Console.WriteLine(Utils.WrapText($"{Environment.NewLine}There is not enough time to work on the helicopter today."));
                            Console.WriteLine($"{Environment.NewLine}Press ENTER to continue.");
                            Utils.PressEnter();
                        }
                        
                    }

                    if (repairTime == 0 && helicopterRepaired == false)
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Helicopter Repaired!"));
                        Console.WriteLine(Utils.WrapText($"{Environment.NewLine}Somehow, finally, you manage to get the Helicopter fixed. Now all that's left is to get out of here!"));
                        Console.WriteLine($"{Environment.NewLine}Press ENTER to continue.");
                        Utils.PressEnter();
                        terminalOutbreakGame.baseManager.SetHelicopterFixed();
                    }

                    this.Run();
                    break;
                case 2:
                    terminalOutbreakGame.constructionChoiceScene.Run();
                    break;
            }
        }


        public void ReduceMetalRequired(int allocated)
        {
            if(metalRequired >= allocated)
            {
                metalRequired -= allocated;
            }
        }
        public void ReduceFuelRequired(int allocated)
        {
            if (fuelRequired >= allocated)
            {
                fuelRequired -= allocated;
            }
        }
        public void ReduceEnginePartsRequired(int allocated)
        {
            if (enginePartsRequired >= allocated)
            {
                enginePartsRequired -= allocated;
            }
        }
        public void ReduceElectricalKitsRequired(int allocated)
        {
            if (electricalKitRequired >= allocated)
            {
                electricalKitRequired -= allocated;
            }
        }


    }
}

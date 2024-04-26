using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;
using Terminal_Outbreak.Items;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Terminal_Outbreak.Scenes.ConstructionScenes
{
    internal class AllocateResourcesScene : Scene
    {

        public AllocateResourcesScene(TerminalOutbreakGame game) : base(game)
        {

        }

        public void RunAllocation(int metalRequired, int fuelRequired, int enginePartsRequired, int electricalKitsRequired)
        {
            string header = Utils.FrameText("Allocate Supplies");
            string display = $"{Environment.NewLine}Which resource would you like to allocate to the repairs?{Environment.NewLine}";
            
            List<string> options = new List<string>();
            options.Add("Scrap Metal");
            options.Add("Fuel Canisters");
            options.Add("Engine Parts");
            options.Add("Electrical Kit");
            options.Add("All Available");
            options.Add("RETURN");


            Menu resupplyResultsMenu = new Menu(display, options, header);
            int selectedIndex = resupplyResultsMenu.RunHeaderVersion();
            int resourceRequired;
            int baseResourceCount;
            int resourceID;
            int allocation;
            string resourceName;

            Resource? resource;


            switch (selectedIndex)
            {
                case 0: // Allocate Metal
                    resourceRequired = metalRequired;
                    resourceID = 2;
                    
                    resource = terminalOutbreakGame.resourceManager.GetBaseResources().Find(r => r.GetResourceID() == resourceID);
                    baseResourceCount = terminalOutbreakGame.resourceManager.GetResourceAmount(resourceID);
                    
                    if (resource == null)
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Allocation Failed"));
                        Console.WriteLine($"{Environment.NewLine}You have not found any scrap metal yet. Press ENTER to continue.");
                        Utils.PressEnter();
                        terminalOutbreakGame.allocateResourcesScene.RunAllocation(metalRequired, fuelRequired, enginePartsRequired, electricalKitsRequired);
                    }
                    else
                    {
                        do
                        {
                            resourceName = resource.GetResourceName();
                            allocation = AllocateResource(resourceRequired, resourceName, resourceID);
                            if (baseResourceCount < allocation)
                            {
                                Console.Clear();
                                Console.WriteLine(Utils.FrameText("Allocation Failed"));
                                Console.WriteLine($"{Environment.NewLine}You do not have enough {resourceName}. Press ENTER to continue.");
                                Utils.PressEnter();
                            }
                            else
                            {
                                terminalOutbreakGame.repairHelicopterScene.ReduceMetalRequired(allocation);
                                terminalOutbreakGame.resourceManager.ReduceResourceQuantity(resourceID, allocation);
                                break;
                            }
                        } while (allocation != 0);
                        
                    }
                    terminalOutbreakGame.repairHelicopterScene.Run();
                    break;

                case 1: // Allocate Fuel
                    resourceRequired = fuelRequired;
                    resourceID = 3;
                    resource = terminalOutbreakGame.resourceManager.GetBaseResources().Find(r => r.GetResourceID() == resourceID);
                    baseResourceCount = terminalOutbreakGame.resourceManager.GetResourceAmount(resourceID);

                    if (resource == null)
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Allocation Failed"));
                        Console.WriteLine($"{Environment.NewLine}You have not found any fuel canisters yet. Press ENTER to continue.");
                        Utils.PressEnter();
                        terminalOutbreakGame.allocateResourcesScene.RunAllocation(metalRequired, fuelRequired, enginePartsRequired, electricalKitsRequired);
                    }
                    else
                    {
                        do
                        {
                            resourceName = resource.GetResourceName();
                            allocation = AllocateResource(resourceRequired, resourceName, resourceID);
                            if (baseResourceCount < allocation)
                            {
                                Console.Clear();
                                Console.WriteLine(Utils.FrameText("Allocation Failed"));
                                Console.WriteLine($"{Environment.NewLine}You do not have enough {resourceName}. Press ENTER to continue.");
                                Utils.PressEnter();
                            }
                            else
                            {
                                terminalOutbreakGame.repairHelicopterScene.ReduceFuelRequired(allocation);
                                terminalOutbreakGame.resourceManager.ReduceResourceQuantity(resourceID, allocation);
                                break;
                            }
                        } while (allocation != 0);

                    }
                    terminalOutbreakGame.repairHelicopterScene.Run();
                    break;

                case 2: // Allocate Engine Parts
                    resourceRequired = enginePartsRequired;
                    resourceID = 7;
                    resource = terminalOutbreakGame.resourceManager.GetBaseResources().Find(r => r.GetResourceID() == resourceID);
                    baseResourceCount = terminalOutbreakGame.resourceManager.GetResourceAmount(resourceID);

                    if (resource == null)
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Allocation Failed"));
                        Console.WriteLine($"{Environment.NewLine}You have not found any engine parts yet. Press ENTER to continue.");
                        Utils.PressEnter();
                        terminalOutbreakGame.allocateResourcesScene.RunAllocation(metalRequired, fuelRequired, enginePartsRequired, electricalKitsRequired);
                    }
                    else
                    {
                        do
                        {
                            resourceName = resource.GetResourceName();
                            allocation = AllocateResource(resourceRequired, resourceName, resourceID);
                            if (baseResourceCount < allocation)
                            {
                                Console.Clear();
                                Console.WriteLine(Utils.FrameText("Allocation Failed"));
                                Console.WriteLine($"{Environment.NewLine}You do not have enough {resourceName}. Press ENTER to continue.");
                                Utils.PressEnter();
                            }
                            else
                            {
                                terminalOutbreakGame.repairHelicopterScene.ReduceEnginePartsRequired(allocation);
                                terminalOutbreakGame.resourceManager.ReduceResourceQuantity(resourceID, allocation);
                                break;
                            }
                        } while (allocation != 0);

                    }
                    terminalOutbreakGame.repairHelicopterScene.Run(); ;
                    break;
                case 3: // Allocate Electrical Kits
                    resourceRequired = electricalKitsRequired;
                    resourceID = 8;
                    resource = terminalOutbreakGame.resourceManager.GetBaseResources().Find(r => r.GetResourceID() == resourceID); 
                    baseResourceCount = terminalOutbreakGame.resourceManager.GetResourceAmount(resourceID);

                    if (resource == null)
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Allocation Failed"));
                        Console.WriteLine($"{Environment.NewLine}You have not found any electrical kits yet. Press ENTER to continue.");
                        Utils.PressEnter();
                        terminalOutbreakGame.allocateResourcesScene.RunAllocation(metalRequired, fuelRequired, enginePartsRequired, electricalKitsRequired);
                    }
                    else
                    {
                        do
                        {
                            resourceName = resource.GetResourceName();
                            allocation = AllocateResource(resourceRequired, resourceName, resourceID);
                            if (baseResourceCount < allocation)
                            {
                                Console.Clear();
                                Console.WriteLine(Utils.FrameText("Allocation Failed"));
                                Console.WriteLine($"{Environment.NewLine}You do not have enough {resourceName}. Press ENTER to continue.");
                                Utils.PressEnter();
                            }
                            else
                            {
                                terminalOutbreakGame.repairHelicopterScene.ReduceElectricalKitsRequired(allocation);
                                terminalOutbreakGame.resourceManager.ReduceResourceQuantity(resourceID, allocation);
                                break;
                            }
                        } while (allocation != 0);

                    }
                    terminalOutbreakGame.repairHelicopterScene.Run();
                    break;
                case 4: // Allocate All Available Resources

                    int baseMetalResourceCount = terminalOutbreakGame.resourceManager.GetResourceAmount(2);
                    int baseFuelResourceCount = terminalOutbreakGame.resourceManager.GetResourceAmount(3);
                    int baseEnginePartsResourceCount = terminalOutbreakGame.resourceManager.GetResourceAmount(7);
                    int baseElectricalKitsResourceCount = terminalOutbreakGame.resourceManager.GetResourceAmount(8);
                    int metalAllocated = 0;
                    int fuelAllocated = 0;
                    int enginePartsAllocated = 0;
                    int electricalKitsAllocated = 0;
                    
                    // SCRAP METAL
                    if(baseMetalResourceCount >= metalRequired) // checks if base has enough METAL to cover the full cost
                    {
                        terminalOutbreakGame.resourceManager.ReduceResourceQuantity(2, metalRequired);
                        metalAllocated = metalRequired;
                        terminalOutbreakGame.repairHelicopterScene.ReduceMetalRequired(metalAllocated);
                    }
                    else // if not, just uses all available to reduce the cost
                    {
                        metalRequired = metalRequired - baseMetalResourceCount;
                        metalAllocated = baseMetalResourceCount;
                        terminalOutbreakGame.resourceManager.ReduceResourceQuantity(2, baseMetalResourceCount);
                        terminalOutbreakGame.repairHelicopterScene.ReduceMetalRequired(metalAllocated);
                    }
                    // FUEL CANISTERS
                    if (baseFuelResourceCount >= fuelRequired) // checks if base has enough FUEL to cover the full cost
                    {
                        terminalOutbreakGame.resourceManager.ReduceResourceQuantity(3, fuelRequired);
                        fuelAllocated = fuelRequired;
                        terminalOutbreakGame.repairHelicopterScene.ReduceFuelRequired(fuelAllocated);
                    }
                    else
                    {
                        fuelRequired = fuelRequired - baseFuelResourceCount;
                        fuelAllocated = baseFuelResourceCount;
                        terminalOutbreakGame.resourceManager.ReduceResourceQuantity(3, baseFuelResourceCount);
                        terminalOutbreakGame.repairHelicopterScene.ReduceFuelRequired(fuelAllocated);
                    }
                    //Engine Parts
                    if (baseEnginePartsResourceCount >= enginePartsRequired) // checks if base has enough ENGINE PARTS to cover the full cost
                    {
                        terminalOutbreakGame.resourceManager.ReduceResourceQuantity(7, enginePartsRequired);
                        enginePartsAllocated = enginePartsRequired;
                        terminalOutbreakGame.repairHelicopterScene.ReduceEnginePartsRequired(enginePartsAllocated);
                    }
                    else
                    {
                        enginePartsRequired = enginePartsRequired - baseEnginePartsResourceCount;
                        enginePartsAllocated = baseEnginePartsResourceCount;
                        terminalOutbreakGame.resourceManager.ReduceResourceQuantity(7, baseEnginePartsResourceCount);
                        terminalOutbreakGame.repairHelicopterScene.ReduceEnginePartsRequired(enginePartsAllocated);
                    }
                    //Electrical Kits
                    if (baseElectricalKitsResourceCount >= electricalKitsRequired) // checks if base has enough ELECTRICAL KITS to cover the full cost
                    {
                        terminalOutbreakGame.resourceManager.ReduceResourceQuantity(8, electricalKitsRequired);
                        electricalKitsAllocated = electricalKitsRequired;
                        terminalOutbreakGame.repairHelicopterScene.ReduceElectricalKitsRequired(electricalKitsAllocated);
                    }
                    else
                    {
                        electricalKitsRequired = electricalKitsRequired - baseElectricalKitsResourceCount;
                        electricalKitsAllocated = baseElectricalKitsResourceCount;
                        terminalOutbreakGame.resourceManager.ReduceResourceQuantity(8, baseElectricalKitsResourceCount);
                        terminalOutbreakGame.repairHelicopterScene.ReduceElectricalKitsRequired(electricalKitsAllocated);
                    }
                    
                    // Print out a results screen of how many resources were allocated
                    Console.Clear();
                    if (metalAllocated == 0 && fuelAllocated == 0 && enginePartsAllocated == 0 && electricalKitsAllocated == 0)
                    {
                        Console.WriteLine(Utils.FrameText("Resources Allocation Failed"));
                        Console.WriteLine($"{Environment.NewLine}No resources available to allocate.");
                    }
                    else
                    {
                        Console.WriteLine(Utils.FrameText("Resources Allocated"));
                        Console.WriteLine($"{Environment.NewLine}The following resources were allocated:");
                        if (metalAllocated > 0) { Console.WriteLine($"{Environment.NewLine}{metalAllocated} Scrap Metal"); }
                        if (fuelAllocated > 0) { Console.WriteLine($"{Environment.NewLine}{fuelAllocated} Fuel Canisters"); }
                        if (enginePartsAllocated > 0) { Console.WriteLine($"{Environment.NewLine}{enginePartsAllocated} Engine Parts"); }
                        if (electricalKitsAllocated > 0) { Console.WriteLine($"{Environment.NewLine}{electricalKitsAllocated} Electrical Kit"); }
                    }
                    Console.WriteLine($"{Environment.NewLine}Press ENTER to continue.");
                    Utils.PressEnter();
                    terminalOutbreakGame.repairHelicopterScene.Run();
                    break;
                case 5:
                    terminalOutbreakGame.repairHelicopterScene.Run();
                    break;
            }
        }

        public int AllocateResource(int resourceRequired, string resourceName, int resourceID) // function used to manually allocate materials
        {
            int quantity;
            string headerText = string.Empty;
            string miniDisplay = string.Empty;
            Console.Clear();
            headerText = (Utils.FrameText($"Allocate {resourceName}"));
            if (resourceName == "Scrap Metal")
            {
                miniDisplay = ($"{Environment.NewLine}You have {terminalOutbreakGame.resourceManager.GetResourceAmount(resourceID)} {resourceName}. How much {resourceName.ToLower()} would you like to allocate? {resourceRequired} still required.");
            }
            if (resourceName == "Engine Parts" || resourceName == "Electrical Kits" || resourceName == "Fuel Canisters")
            {
                miniDisplay = ($"{Environment.NewLine}You have {terminalOutbreakGame.resourceManager.GetResourceAmount(resourceID)} {resourceName}. How many {resourceName.ToLower()} would you like to allocate? {resourceRequired} still required.");
            }
            miniDisplay += ($"{Environment.NewLine}Input a numerical value and then press ENTER. To return without allocating, input a value of 0{Environment.NewLine}");
            Console.WriteLine(headerText);
            Console.WriteLine(miniDisplay);
            Console.CursorVisible = true;
            do
            {
                while (!Int32.TryParse(Console.ReadLine(), out quantity))
                {
                    Console.Clear();
                    Console.WriteLine(headerText);
                    Console.WriteLine("NOTE - Please ensure you enter ONLY a numerical number (I.E. No letters or spaces).");
                    Console.Write(miniDisplay);
                    Console.WriteLine(Environment.NewLine);
                }
                if (quantity <= resourceRequired)
                {
                    Console.CursorVisible = false;
                    return quantity;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(headerText);
                    Console.WriteLine($"NOTE - Allocation is too high, only {resourceRequired} is required.");
                    Console.Write(miniDisplay);
                    Console.WriteLine(Environment.NewLine);
                }


            } while (quantity > resourceRequired || quantity != 0);
            Console.CursorVisible = false;
            return 0;
        }

    }
}

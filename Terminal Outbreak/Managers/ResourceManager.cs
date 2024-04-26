using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Items;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Managers
{
    internal class ResourceManager
    {
        private List<Resource> baseResources; 

        private int[] lootTable;
        private Random random;
        private int total;
        private int rationConsumption;

        public ResourceManager()
        {
            baseResources = new List<Resource>();
            lootTable = 
                [40, // Food chance
                30, // Wood chance
                28, // Metal chance
                18, // Fuel Barrel chance
                15, // Ammunition chance
                10, // Pipes chance
                7,  // Gun parts chance
                5,   // Engine Parts
                3, // Electrical Kit
                ];

            random = new Random();
            rationConsumption = 1;

            for (int i = 0; i < 5; i++) // gives the player 5 rations to start with
            {
                baseResources.Add(new Resource(0));
            }
        }
        public void IncreaseRationConsumption()
        {
            rationConsumption++;
        }
        public int GetRationConsumption()
        {
            return rationConsumption;
        }

        public void ConsumeRations()
        {
            int rations = GetFoodRations();
            rations -= rationConsumption;
        }

        public List<Resource> GetBaseResources()
        {
            return baseResources;
        }
        public List<Resource> Resupply(float actionTime)
        {
            total = 0;
            List<Resource> foundResources = new List<Resource>();
            int randomQuantity;
            int randomItem;
            

            foreach (int item in lootTable) 
            {
                total += item;
            }

            if(actionTime == 8.00f)
            {
                randomQuantity = random.Next(10, 25); // Change this to adjust how much loot is found during a long supply run
            }
            else
            {
                randomQuantity = random.Next(5, 12); // Change this to adjust how much loot is found during a short supply run
            }

            int quantity = 0;

            while (quantity < randomQuantity)
            {
                randomItem = random.Next(0, total);

                for (int i = 0; i < lootTable.Length; i++)
                {
                    if (randomItem <= lootTable[i])
                    {
                        Resource resource = new Resource(i);
                        foundResources.Add(resource);
                        break;
                    }
                    else
                    {
                        randomItem -= lootTable[i];
                    }
                }
                quantity++;
            }

            foreach (Resource resource in foundResources) // update master resource list with found resources
            {
                baseResources.Add(resource);
            }

            return foundResources; // return resources found this run for printout
        }


        public int GetFoodRations()
        {
            int rationsCount = 0;

            foreach (Resource resource in baseResources)
            {
                if (resource.GetResourceID() == 0)
                {
                    rationsCount++;
                }
            }
            return rationsCount;
        }


        public string GetResources()
        {
            int formatCounter = 0;
            string resources = $"{Environment.NewLine}    ";
            var groupedResources = baseResources.GroupBy(r => r.GetResourceID()) // AFTERMATH // Look into this kind of code a lot more in-depth: LINQ
                                    .Select(g => new { ID = g.Key, Count = g.Count(), Name = g.First().GetResourceName() })
                                    .OrderBy(r => r.ID);
            foreach (var resource in groupedResources)
            {
                if (resource.ID == 0)
                {
                    continue;
                }
                if (formatCounter == 3)
                {
                    resources += $"{Environment.NewLine}    ";
                    formatCounter = 0;
                }
                resources += ($"{resource.Name}: {resource.Count}".PadRight(20));
                formatCounter++;
                

            }

            bool allFood = baseResources.All(r => r.GetResourceID() == 0); // checks to make sure that only food exists in the resource list because food is given its own display
            if (allFood)
            {
                resources = "NONE";
            }
            return resources;
        }

        public bool CheckResourceQuantity(int resourceID, int reqCount) // something like this should be used to check if ID has enough for contruction, etc.
        {
            int quantity = baseResources.Count(r => r.GetResourceID() == 1);
            if (quantity >= reqCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetResourceAmount(int resourceID)
        {
            int amount = baseResources.Count(r => r.GetResourceID() == resourceID);
            return amount;
        }

        public void ReduceResourceQuantity(int resourceID, int reductionAmount)
        {
            // Check if there are at least reductionAmount number of resources with the given resourceID
            int resourceCount = baseResources.Count(r => r.GetResourceID() == resourceID);
            if (resourceCount < reductionAmount)
            {
                Console.WriteLine("Not enough resources to remove.");
                Utils.PressEnter();
                return;
            }

            for (int i = 0; i < reductionAmount; i++)
            {
                // Find the index of the first resource with the given ID
                int index = baseResources.FindIndex(r => r.GetResourceID() == resourceID);

                // If a resource with the given ID is found, remove it
                if (index != -1)
                {
                    baseResources.RemoveAt(index);
                }
                else
                {
                    // If no resource with the given ID is found, stop the loop
                    break;
                }
            }
        }
    }

    
}

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
        
        private int[] lootTable = 
        {
            30, // Food chance
            25, // Wood chance
            20, // Metal chance
            18, // Fuel Barrel chance
            15, // Ammunition chance
            10, // Pipes chance
            7,  // Gun parts chance
            5   // Electrical Components
        };
        
        
        private Random random = new Random();
        private int total;

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

            return foundResources;
        }

    }
}

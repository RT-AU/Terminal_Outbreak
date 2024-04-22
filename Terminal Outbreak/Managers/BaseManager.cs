using System.ComponentModel.Design;
using Terminal_Outbreak.Defences;
using Terminal_Outbreak.Items;
using Terminal_Outbreak.Scenes;

namespace Terminal_Outbreak.Managers
{
    // Class which handles the base resources
    internal class BaseManager
    {

        private float prepTime;
        private int foodRations;
        private List<Resource> baseResources;
        private List<Trap> traps;
        private BarrierWall barrier;

        public BaseManager()
        {
            prepTime = 12.0f;
            foodRations = 5;
            baseResources = new List<Resource>();
            traps = new List<Trap>();
            barrier = new BarrierWall();

            for (int i = 0; i <= 3; i++) 
            {
                traps.Add(new Trap(i));
            }
        }


        public void reduceTime(float time)
        {
            prepTime -= time;
        }

        public void resetTime()
        {
            prepTime = 12.0f;
        }

        public float getTime()
        {
            return prepTime;
        }

        public int checkFoodRations()
        {
            return foodRations;
        }

        public void increaseFoodRations(int amount)
        {
            foodRations += amount;
        }
        public void decreaseFoodRations(int amount)
        {
            foodRations -= amount;
        }

        public void BuildTrap(int trapID)
        {
            for (int i = 0; i < traps.Count; i++)
            {
                if (traps[i].GetTrapID() == trapID)
                {
                    traps[i].BuildTrap();
                }
            }
        }

        public Trap GetTrap(int trapID)
        {
            return traps[trapID];
        }
        public string getTraps()
        {
            string trapString = "";
            for (int i = 0; i < traps.Count; i++)
            {
                if (traps[i].IsBuilt() == false)
                {
                    if (i == 2)
                    {
                        trapString += $"{Environment.NewLine}{Environment.NewLine}{traps[i].GetTrapName()} (Deals {traps[i].GetDamage()} Damage and uses 2 Fuel Barrels every night)";
                    }
                    else if (i == 3)
                    {
                        trapString += $"{Environment.NewLine}{Environment.NewLine}{traps[i].GetTrapName()} (Deals {traps[i].GetDamage()} Damage and uses 5 Ammunition every night)";
                    }
                    else
                    {
                        trapString += $"{Environment.NewLine}{Environment.NewLine}{traps[i].GetTrapName()} (Deals {traps[i].GetDamage()} Damage)";
                    }
                    
                    trapString += $"{Environment.NewLine}{traps[i].GetRecipe()}";
                }
            }
            return trapString;
        }

        public int GetTrapCount()
        {
            return traps.Count;
        }

        public void increaseResources(List<Resource> gatheredResources)
        {
            foreach (Resource resource in gatheredResources)
            {
                baseResources.Add(resource);
            }
        }

        public Dictionary<string, int> getResourceList()
        {
            Dictionary<string, int> resourceList = new Dictionary<string, int>();

            foreach (Resource resource in baseResources)
            {
                // If resource name exists in dictionary, increment its count
                if (resourceList.ContainsKey(resource.GetResourceName()))
                {
                    resourceList[resource.GetResourceName()]++;
                }
                // Otherwise, add the resource name to the dictionary with count 1
                else
                {
                    resourceList[resource.GetResourceName()] = 1;
                }
            }
            return resourceList;
        }
    }
}
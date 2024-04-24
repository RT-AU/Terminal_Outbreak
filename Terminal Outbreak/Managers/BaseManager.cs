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
        private List<Resource> baseResources; // TO DO // Move this to the resource Manager?
        private List<Trap> traps;
        private BarrierWall barrier;
        private int dayNumber;

        public BaseManager()
        {
            prepTime = 12.0f;
            foodRations = 5;
            dayNumber = 1;
            baseResources = new List<Resource>();
            traps = new List<Trap>();
            barrier = new BarrierWall();

            for (int i = 0; i <= 3; i++) 
            {
                traps.Add(new Trap(i));
            }
        }


        public void ReduceTime(float time)
        {
            prepTime -= time;
        }

        public void ResetTime()
        {
            prepTime = 12.0f;
        }

        public float GetTime()
        {
            return prepTime;
        }

        public int CheckFoodRations()
        {
            return foodRations;
        }

       

        public void IncreaseFoodRations(int amount)
        {
            foodRations += amount;
        }
        public void DecreaseFoodRations(int amount)
        {
            foodRations -= amount;
        }

        public int GetDayNumber()
        {
            return dayNumber;
        }

        public void IncreaseDayNumber()
        {
            dayNumber++;
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
                    
                    if (traps[i].GetResourceRequired() != "NONE")
                    {
                        string resourceRequired = traps[i].GetResourceRequired();
                        int resourceQuantity = traps[i].GetResourceRequiredQuanitity();
                        trapString += $"{Environment.NewLine}{Environment.NewLine}{traps[i].GetTrapName()} (Deals {traps[i].GetDamage()} Damage and uses {resourceQuantity} {resourceRequired} every night)";
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

        public void IncreaseResources(List<Resource> gatheredResources)
        {
            foreach (Resource resource in gatheredResources)
            {
                baseResources.Add(resource);
            }
        }

        public Dictionary<string, int> GetResourceList()
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
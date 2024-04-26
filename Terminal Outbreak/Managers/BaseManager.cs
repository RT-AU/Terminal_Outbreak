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
        private List<Trap> traps;
        private bool barrierBuilt;
        private bool barrierDestroyed;
        private int barrierHealth;
        private int dayNumber;
        private bool helicopterFixed;

        public BaseManager()
        {
            prepTime = 12.0f;
            dayNumber = 1;
            traps = new List<Trap>();
            barrierBuilt = false;
            barrierHealth = 5;
            barrierDestroyed = false;
            helicopterFixed = false;

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

        public List<Trap> GetTrapList()
        {
            return traps;
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
        public string GetTraps()
        {
            string trapString = "";
            for (int i = 0; i < traps.Count; i++)
            {
                if (traps[i].IsBuilt() == false)
                {

                    if (traps[i].GetLRDamage() == 0)
                    {
                        trapString += $"{Environment.NewLine}{traps[i].GetTrapName()} (Trap placed at Medium Range which deals {traps[i].GetMRDamage()} damage to {traps[i].GetMulti()} enemies)";
                    }
                    else if (traps[i].GetMRDamage() == 0)
                    {

                        trapString += $"{Environment.NewLine}{traps[i].GetTrapName()} (Trap placed at Long Range which deals {traps[i].GetLRDamage()} damage to {traps[i].GetMulti()} enemies)";
                    }
                    else
                    {
                        trapString += $"{Environment.NewLine}{traps[i].GetTrapName()} (Trap effective at both Long and Medium range, and deals {traps[i].GetLRDamage()} Damage to {traps[i].GetMulti()} enemies)";
                    }

                    //if (traps[i].GetResourceRequired() != "NONE") // FOR NOW, TRAP RESOURCES WILL BE REMOVED
                    //{
                    //    string resourceRequired = traps[i].GetResourceRequired();
                    //    int resourceQuantity = traps[i].GetResourceRequiredQuanitity();
                    //    trapString += $"{Environment.NewLine}{traps[i].GetTrapName()} (Deals {traps[i].GetDamage()} Damage to {traps[i].GetMulti()} enemies and uses {resourceQuantity} {resourceRequired} every night)";
                    //}
                    //else
                    //{
                    //    trapString += $"{Environment.NewLine}{traps[i].GetTrapName()} (Deals {traps[i].GetDamage()} Damage to {traps[i].GetMulti()} enemies)";
                    //}
                    
                    Dictionary<int, int> trapRecipes = traps[i].GetRecipe(); // fetches the recipe of the traps
                    string recipe = string.Empty;
                    
                    foreach (var trapRecipe in trapRecipes) 
                    {
                        Resource resource = new Resource(trapRecipe.Key);
                        recipe += $"{trapRecipe.Value} {resource.GetResourceName()}{Environment.NewLine}";
                        //recipe += resource.GetResourceName();
                    }

                    //trapString += $"{Environment.NewLine}{traps[i].GetRecipe()}";
                    trapString += $"{Environment.NewLine}{recipe}";
                }
            }
            return trapString;
        }
        public string GetBuiltTrapsNames()
        {
            string builtTrapsNames = $"{Environment.NewLine}    ";
            int trapCounter = 0;
            for (int i = 0; i < traps.Count; i++)
            {
                if (traps[i].IsBuilt())
                {
                    trapCounter++;
                    if (trapCounter > 1)
                    {
                        builtTrapsNames += ", ";
                    }
                    if (trapCounter == 3)
                    {
                        builtTrapsNames += $"{Environment.NewLine}    ";
                    }
                    builtTrapsNames += $"{traps[i].GetTrapName()}";
                }
            }
            if (trapCounter == 0)
            {
                builtTrapsNames = "NONE";
            }
            return builtTrapsNames;
        }
        public int GetTrapCount()
        {
            return traps.Count;
        }

        public void SetHelicopterFixed()
        {
            helicopterFixed = true;
        }

        public bool IsHelicopterFixed()
        {
            return helicopterFixed;
        }

        public bool IsBarrierBuilt()
        {
            return barrierBuilt;
        }
        
        public void BuildBarrer()
        {
            barrierBuilt = true;
        }
        public void DamageBarrier()
        {
            barrierHealth--;
        }
        public void ResetBarrierHealth()
        {
            barrierHealth = 5;
        }
        public int GetBarrierHealth()
        { 
            return barrierHealth; 
        }
        public bool IsBarrierDestroyed()
        {
            return barrierDestroyed;
        }
        public void DestroyBarrier()
        {
            barrierDestroyed = true;
        }

        public void RepairBarrier()
        {
            barrierDestroyed = false;
            ResetBarrierHealth();
        }
    }
}
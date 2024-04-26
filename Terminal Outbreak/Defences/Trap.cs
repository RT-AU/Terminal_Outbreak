using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Defences
{
    internal class Trap
    {

        private int trapID;
        private string trapName = "default";
        private int trapLRDamage;
        private int trapMRDamage;
        private int trapMulti;
        private int trapMaxHealth;
        private int trapHealth;
        private bool trapRequiresResource;
        private string resourceRequired = "N/A";
        private int resourceRequiredQuantity;
        private bool behindWall;
        private Dictionary<int, int> recipe;
        private int[] ingredientsArray = [1, 2, 4, 5, 3, 6]; // wood, metal, ammunition, pipes, fuel, gun parts
        private bool isBuilt;


        public Trap(int id) 
        {
            trapID = id;
            recipe = new Dictionary<int, int>();
            switch (trapID)
            {
                case 0:
                    trapName = "Spike Trap";
                    trapMaxHealth = 10;
                    trapHealth = 10;
                    trapLRDamage = 5;
                    trapMRDamage = 0;
                    trapMulti = 5;
                    trapRequiresResource = false;
                    behindWall = false;
                    recipe.Add(1, 15); // 5x wood

                    isBuilt = false;
                    break;

                case 1:
                    trapName = "Blade Trap";
                    trapMaxHealth = 10;
                    trapHealth = 5;
                    trapLRDamage = 15;
                    trapMRDamage = 0;
                    trapMulti = 10;
                    trapRequiresResource = false;
                    behindWall = false;
                    recipe.Add(1, 15); // 5x wood
                    recipe.Add(2, 15); // 5x metal

                    isBuilt = false;
                    break;

                case 2:
                    trapName = "Flame Trap";
                    trapMaxHealth = 10;
                    trapHealth = 10;
                    trapLRDamage = 0;
                    trapMRDamage = 10;
                    trapMulti = 25;
                    trapRequiresResource = true;
                    resourceRequired = "Fuel";
                    resourceRequiredQuantity = 2;
                    behindWall = true;
                    recipe.Add(2, 30); // 5x metal
                    recipe.Add(5, 20); // 2x pipes
                    recipe.Add(3, 10); // 1x fuel canister

                    isBuilt = false;
                    break;

                case 3:
                    trapName = "Sentry Turret";
                    trapMaxHealth = 10;
                    trapHealth = 10;
                    trapLRDamage= 25;
                    trapMRDamage = trapLRDamage;
                    trapMulti = 10;
                    trapRequiresResource = true;
                    resourceRequired = "Ammunition";
                    resourceRequiredQuantity = 5;
                    behindWall = true;
                    recipe.Add(2, 25); // 10x metal
                    recipe.Add(6, 15); // 10x gun parts
                    recipe.Add(4, 20); // 15x Ammunition

                    isBuilt = false;
                    break;
            }
        }

        public void BuildTrap()
        {
            isBuilt = true;
        }

        public bool IsBuilt()
        {
            return isBuilt;
        }
        public int GetTrapID()
        {
            return trapID;
        }
        public string GetTrapName()
        {
            return trapName;
        }

        public void Damage(int damage)
        {
            trapHealth -= damage;
        }

        public void Repair() // for now it will just completely repair the baricade at a time cost of 1 hours
        {
            trapHealth = trapMaxHealth;
        }

        public int GetHealth()
        {
            return trapHealth;
        }

        public int GetLRDamage()
        {
            return trapLRDamage;
        }
        public int GetMRDamage()
        {
            return trapMRDamage;
        }

        public int GetMulti()
        {
            return trapMulti;
        }

        public string GetResourceRequired()
        {
            if (trapRequiresResource == true) 
            {
                return resourceRequired;
            }
            else
            {
                return "NONE";
            }
        }

        public int GetResourceRequiredQuanitity()
        {
            if (trapRequiresResource == true)
            {
                return resourceRequiredQuantity;
            }
            else
            {
                return 0;
            }
        }

        public Dictionary<int, int> GetRecipe()
        {
            return recipe;
        }

    }
}

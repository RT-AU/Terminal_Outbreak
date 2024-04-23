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
        private string trapName ="default";
        private int trapDamage;
        private int trapMaxHealth;
        private int trapHealth;
        private int trapIsDestroyed;
        private bool trapRequiresResource;
        private string resourceRequired = "N/A";
        private int resourceRequiredQuantity;
        private bool behindWall;
        private Dictionary<string, int> recipe;
        private string[] ingredientsArray = ["wood", "metal", "pipes", "fuel", "gun parts"];
        private bool isBuilt;


        public Trap(int id) 
        {
            trapID = id;
            recipe = new Dictionary<string, int>();
            switch (trapID)
            {
                case 0:
                    trapName = "Spike Trap";
                    trapMaxHealth = 10;
                    trapHealth = 10;
                    trapDamage = 10;
                    trapIsDestroyed = 0;
                    trapRequiresResource = false;
                    behindWall = false;
                    recipe.Add("wood", 5);

                    isBuilt = false;
                    break;

                case 1:
                    trapName = "Blade Trap";
                    trapMaxHealth = 10;
                    trapHealth = 10;
                    trapDamage = 15;
                    trapIsDestroyed = 0;
                    trapRequiresResource = false;
                    behindWall = false;
                    recipe.Add("wood", 5);
                    recipe.Add("metal", 5);

                    isBuilt = false;
                    break;

                case 2:
                    trapName = "Flame Trap";
                    trapMaxHealth = 10;
                    trapHealth = 10;
                    trapDamage = 20;
                    trapIsDestroyed = 0;
                    trapRequiresResource = true;
                    resourceRequired = "Fuel";
                    resourceRequiredQuantity = 2;
                    behindWall = true;
                    recipe.Add("metal", 5);
                    recipe.Add("pipes", 2);
                    recipe.Add("barrel", 1);

                    isBuilt = false;
                    break;

                case 3:
                    trapName = "Sentry Turret";
                    trapMaxHealth = 10;
                    trapHealth = 10;
                    trapDamage= 25;
                    trapIsDestroyed = 0;
                    trapRequiresResource = true;
                    resourceRequired = "Ammunition";
                    resourceRequiredQuantity = 5;
                    behindWall = true;
                    recipe.Add("metal", 10);
                    recipe.Add("gun parts", 10);

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

        public int GetDamage()
        {
            return trapDamage;
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

        public string GetRecipe()
        {
            string ingredients = "Required Materials:";
            foreach (string ingredient in ingredientsArray)
            {
                if (recipe.ContainsKey(ingredient))
                {
                    ingredients += $"{Environment.NewLine}  {recipe[ingredient]} {ingredient}";
                }
               
            }
            return ingredients;

        }

    }
}

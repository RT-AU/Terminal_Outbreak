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
        private bool behindWall;
        private Dictionary<string, int> recipe;
        private string[] ingredientsArray = ["wood", "metal", "pipes", "fuel", "gun parts"];


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
                    break;

                case 2:
                    trapName = "Flame Trap";
                    trapMaxHealth = 10;
                    trapHealth = 10;
                    trapDamage = 20;
                    trapIsDestroyed = 0;
                    trapRequiresResource = true;
                    resourceRequired = "Fuel";
                    behindWall = true;
                    recipe.Add("metal", 5);
                    recipe.Add("pipes", 2);
                    recipe.Add("barrel", 1);
                    break;

                case 3:
                    trapName = "Sentry Turret";
                    trapMaxHealth = 10;
                    trapHealth = 10;
                    trapDamage= 25;
                    trapIsDestroyed = 0;
                    trapRequiresResource = true;
                    resourceRequired = "Ammunition";
                    behindWall = true;
                    recipe.Add("metal", 10);
                    recipe.Add("Gun Parts", 10);
                    break;
            }
        }

        public string getTrapName()
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

        public int getHealth()
        {
            return trapHealth;
        }

        public int getDamage()
        {
            return trapDamage;
        }

        public string getResourceRequired()
        {
            if (trapRequiresResource == true) 
            {
                return resourceRequired;
            }
            else
            {
                return "No resources are required for this trap";
            }
        }

        public string getRecipe()
        {
            string ingredients = "Requirements for building this trap are:";
            foreach (string ingredient in ingredientsArray)
            {
                if (recipe.ContainsKey(ingredient))
                {
                    ingredients += $"{Environment.NewLine}{recipe[ingredient]} {ingredient}";
                }
               
            }
            return ingredients;

        }

    }
}

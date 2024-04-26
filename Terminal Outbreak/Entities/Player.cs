using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Items;

namespace Terminal_Outbreak.Entities
{
    internal class Player
    {
        private string name;
        private int maxHealth;
        private int health;
        private List<Weapon> inventory;
        public Player() 
        { 
            name = "default";
            maxHealth = 100;
            health = 100;
            inventory = new List<Weapon>();
        }
            
        public void SetName(string playerName)
        {
            name = playerName;
        }

        public string GetName()
        {
            return name;
        }

        public int getHealth()
        {
            return health;
        }

        public void Damage(int damage) 
        { 
            health -= damage;
        }

        public void Heal(int heal) 
        {
            if (health + heal > maxHealth)
            {
                health = maxHealth;
            } else health += heal;

        }

        public void AddItem (Weapon item) 
        { 
            inventory.Add(item);
        }

        public void RemoveItem (Weapon item)
        {
            if (inventory.Contains(item))
            {
                inventory.Remove(item);
            }
        }
    }
}

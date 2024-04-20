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
        private int health;
        private List<Equipment> inventory;
        public Player() 
        { 
            name = "default";
            health = 100;
            inventory = new List<Equipment>();
        }
            
        public void SetName(string playerName)
        {
            name = playerName;
        }

        public string GetName()
        {
            return name;
        }

        public void Damage(int damage) 
        { 
            health -= damage;
        }

        public void Heal(int heal) 
        {
            health += heal;
        }

        public void AddItem (Equipment item) 
        { 
            inventory.Add(item);
        }

        public void RemoveItem (Equipment item)
        {
            if (inventory.Contains(item))
            {
                inventory.Remove(item);
            }
        }
    }
}

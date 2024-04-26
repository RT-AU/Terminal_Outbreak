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
        private int equippedPrimaryWeaponID;
        private int equippedSecondaryWeaponID;
        private int equippedMeleeWeaponID;
        public Player() 
        { 
            name = "default";
            maxHealth = 100;
            health = 100;
            equippedPrimaryWeaponID = -1; // None Equipped
            equippedSecondaryWeaponID = -1;
            equippedMeleeWeaponID = -1;
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

       public void equipPrimaryWeapon(int weaponID)
        {
            equippedPrimaryWeaponID = weaponID;
        }

        public void equipSecondaryWeapon(int weaponID)
        {
            equippedSecondaryWeaponID = weaponID;
        }

        public void equipMeleeWeapon(int weaponID)
        {
            equippedMeleeWeaponID = weaponID;
        }

        public int GetEquippedPrimaryWeaponID()
        {
            return equippedPrimaryWeaponID;
        }

        public int GetEquippedSecondaryWeaponID()
        {
            return equippedSecondaryWeaponID;
        }

        public int GetEquippedMeleeWeaponID()
        {
            return equippedMeleeWeaponID;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Items;
using static System.Net.Mime.MediaTypeNames;

namespace Terminal_Outbreak.Managers
{
    internal class EquipmentManager
    {
        private List<Weapon> equipment;
        public EquipmentManager() 
        {
            equipment = new List<Weapon>(); // Create a list of items (in this case, all items in the list)
            for (int i = 0; i < 9; i++)
            {
                Weapon weapon = new Weapon(i);
                equipment.Add(weapon);
            }
        }


        public List<Weapon> GetEquipmentList() // TO DO // Set this up to be used, and make sure it actually works how I would want it to.
        {
            return equipment;
        }

        public string GetWeaponName(int weaponID)
        {
            string weaponName = string.Empty;
            Weapon? weapon = equipment.Find(r => r.GetWeaponID() == weaponID);
            if (weapon != null)
            {
                weaponName = weapon.GetWeaponName();
            }

            return weaponName;
        }

        public string GetWeaponType(int weaponID)
        {
            string weaponType = string.Empty;
            Weapon? weapon = equipment.Find(r => r.GetWeaponID() == weaponID);
            if (weapon != null)
            {
                weaponType = weapon.GetWeaponType();
            }

            return weaponType;
        }

        public string GetWeaponDescription(int weaponID)
        {
            string description = string.Empty;
            Weapon? weapon = equipment.Find(r => r.GetWeaponID() == weaponID);
            if (weapon != null)
            {
                description = weapon.GetDescription();
            }

            return description;
        }

        public bool IsWeaponOwned(int weaponID)
        {
            bool owned = false;
            Weapon? weapon = equipment.Find(r => r.GetWeaponID() == weaponID);
            if (weapon != null)
            {
                owned = weapon.GetOwned();
            }
            return owned;
        }

        public void SetWeaponOwned(int weaponID, bool ownership)
        {
            Weapon? weapon = equipment.Find(r => r.GetWeaponID() == weaponID);
            if (weapon != null)
            {
                weapon.SetOwned(ownership);
            }
        }

        public int GetWeaponLRDamage(int weaponID)
        {
            int damage = 0;
            Weapon? weapon = equipment.Find(r => r.GetWeaponID() == weaponID);
            if (weapon != null)
            {
                damage = weapon.GetWeaponLongRangeDamage() ;
            }
            return damage;
        }
        public int GetWeaponMRDamage(int weaponID)
        {
            int damage = 0;
            Weapon? weapon = equipment.Find(r => r.GetWeaponID() == weaponID);
            if (weapon != null)
            {
                damage = weapon.GetWeaponMediumRangeDamage();
            }
            return damage;
        }
        public int GetWeaponCQDamage(int weaponID)
        {
            int damage = 0;
            Weapon? weapon = equipment.Find(r => r.GetWeaponID() == weaponID);
            if (weapon != null)
            {
                damage = weapon.GetWeaponCQDamage();
            }
            return damage;
        }

        public int GetWeaponLRMulti(int weaponID)
        {
            int multi = 1;
            Weapon? weapon = equipment.Find(r => r.GetWeaponID() == weaponID);
            if (weapon != null)
            {
                multi = weapon.GetWeaponLongRangeMulti();
            }
            return multi;
        }

        public int GetWeaponMRMulti(int weaponID)
        {
            int multi = 1;
            Weapon? weapon = equipment.Find(r => r.GetWeaponID() == weaponID);
            if (weapon != null)
            {
                multi = weapon.GetWeaponMediumRangeMulti();
            }
            return multi;
        }
        public int GetWeaponCQMulti(int weaponID)
        {
            int multi = 1;
            Weapon? weapon = equipment.Find(r => r.GetWeaponID() == weaponID);
            if (weapon != null)
            {
                multi = weapon.GetWeaponCQMulti();
            }
            return multi;
        }

    }
}

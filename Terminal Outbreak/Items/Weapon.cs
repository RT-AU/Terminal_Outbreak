using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Items
{
    internal class Weapon
    {
        private int weaponID;
        private string weaponName;
        private string weaponType;
        private int weaponLongRangeDamage;
        private int weaponLongRangeMulti;
        private int weaponMediumRangeDamage;
        private int weaponMediumRangeMulti;
        private int weaponCQDamage;
        private int weaponCQMulti;
        private string description;
        private bool owned;

        public Weapon(int ID)
        {
            weaponID = ID;
            weaponName = "default";
            weaponType = "default";

            weaponLongRangeDamage = 0;
            weaponLongRangeMulti = 1; // weapons should always attack at least 1 enemy, unless otherwise specified
            weaponMediumRangeDamage = 0;
            weaponMediumRangeMulti = 1;
            weaponCQDamage = 0;
            weaponCQMulti = 1;
            description = "default";
            owned = false;

            switch (ID)
            {
                case 0:
                    weaponName = "Baseball Bat";
                    weaponType = "Melee";

                    weaponCQDamage = 5;
                    weaponCQMulti = 1;
                    description = Utils.WrapText($"Its a bat and it can only be used in close quarters, so it's pretty last-season. It deals {weaponCQDamage} damage to a single enemy every round.");
                    break;
                case 1:
                    weaponName = "Sword";
                    weaponType = "Melee";
                    weaponCQDamage = 10;
                    weaponCQMulti = 10; 
                    description = Utils.WrapText($"Its a sword that only be used in close quarters...but it's a freakin' sword. It deals {weaponCQDamage} damage to {weaponCQMulti} enemies every round.");
                    break;
                case 2:
                    weaponName = "Chainsaw";
                    weaponType = "Melee";

                    weaponCQDamage = 25;
                    weaponCQMulti = 25; 

                    description = Utils.WrapText($"If it can fell trees, it can fell these! (Zombies, that is). In close quarters it deals {weaponCQDamage} damage to {weaponCQMulti} enemies every round.");
                    break;
                case 3:
                    weaponName = "Varmint Rifle";
                    weaponType = "Primary";
                    weaponLongRangeDamage = 10;
                    weaponLongRangeMulti = 1;

                    weaponMediumRangeDamage = 5;
                    weaponMediumRangeMulti = 1;
                    
                    weaponCQDamage = 3;
                    weaponCQMulti = 1;
                    description = Utils.WrapText($"Pop goes the Rifle. Being built for long range means its practically useless in a close fight. Deals {weaponLongRangeDamage} damage to a single enemy at long range, {weaponMediumRangeDamage} damage at medium range, and {weaponCQDamage} in close quarters.");

                    break;
                case 4:
                    weaponName = "Sniper Rifle";
                    weaponType = "Primary";
                    weaponLongRangeDamage = 25;
                    weaponLongRangeMulti = 5;

                    weaponMediumRangeDamage = 0;
                    weaponMediumRangeMulti = 1;

                    weaponCQDamage = 0;
                    weaponCQMulti = 1;
                    description = Utils.WrapText($"All the better to see you with, my dear. The sniper is the pinnacle of precision in the Long-Range Lethal Lineup, dealing {weaponLongRangeDamage} damage to a single enemy...and piercing through to hit {weaponLongRangeMulti-1} more! Best not to let them get close though, as it's too difficult to aim at anything closer than long range.");
                    break;
                case 5:
                    weaponName = "Heavy Machine Gun";
                    weaponType = "Primary";
                    weaponLongRangeDamage = 5;
                    weaponLongRangeMulti = 10;

                    weaponMediumRangeDamage = 15;
                    weaponMediumRangeMulti = 2;

                    weaponCQDamage = 0;
                    weaponCQMulti = 1;
                    description = Utils.WrapText($"Spray and pray. Who needs high damage if you just keep hitting anything that moves! Deals {weaponLongRangeDamage} damage to {weaponLongRangeMulti} enemies at long range, and {weaponMediumRangeDamage} damage to {weaponMediumRangeMulti} enemies at medium range. There'll be no time to use it in melee range though, so better have a backup.");
                    break;
                case 6:
                    weaponName = "Revolver";
                    weaponType = "Secondary";
                    weaponLongRangeDamage = 3;
                    weaponLongRangeMulti = 6;

                    weaponMediumRangeDamage = 10;
                    weaponMediumRangeMulti = 6;

                    weaponCQDamage = 5;
                    weaponCQMulti = 1;
                    description = Utils.WrapText($"It slow and clunky, but its all about the aesthetic. Bask in that wild-west nostalgia as you deal {weaponLongRangeDamage} damage to {weaponLongRangeMulti} outlaws at long range. When they get closer, unleash a whole {weaponMediumRangeDamage} damage to {weaponMediumRangeMulti} of 'em. Might want to try something else for Melee though, as you aren't going to hit more than {weaponCQMulti} of 'em for {weaponCQDamage} damage.");
                    break;
                case 7:
                    weaponName = "Agent Pistol";
                    weaponType = "Secondary";
                    weaponLongRangeDamage = 5;
                    weaponLongRangeMulti = 2;

                    weaponMediumRangeDamage = 10;
                    weaponMediumRangeMulti = 16;

                    weaponCQDamage = 3;
                    weaponCQMulti = 2;
                    description = Utils.WrapText($"Standard issue secret-agent pistol. Gets the job done, but the really cool spies probably use something better. Deals {weaponLongRangeDamage} damage to {weaponLongRangeMulti} enemies at long range, and {weaponMediumRangeDamage} damage to {weaponMediumRangeMulti} enemies at medium range. Unfortunately it's hard to look cool with zombie breath in your face, so you'll only deal {weaponCQDamage} damage to {weaponCQMulti} enemies in close quarters.");
                    break;
                case 8:
                    weaponName = "Sawn-Off Shotgun";
                    weaponType = "Secondary";
                    weaponLongRangeDamage = 1;
                    weaponLongRangeMulti = 10;

                    weaponMediumRangeDamage = 25;
                    weaponMediumRangeMulti = 8;

                    weaponCQDamage = 15;
                    weaponCQMulti = 1;
                    description = Utils.WrapText($"Short in stature, the sawn-off will do basically nothing at long range, dealing {weaponLongRangeDamage} damage to {weaponLongRangeMulti} enemies. But once they're in medium range you'll hit {weaponMediumRangeMulti} of them for {weaponMediumRangeDamage} damage apiece. If they get closer than that, you're only going to hit {weaponCQMulti} of them, but you'll deal a whopping {weaponCQDamage} damage!");
                    break;

            }
        }

        public int GetWeaponID()
        {
            return weaponID;
        }
        public string GetWeaponName()
        {
            return weaponName;
        }
        public string GetWeaponType()
        {
            return weaponName;
        }

        public string GetDescription()
        {
            return description;
        }

        public bool GetOwned()
        {
            return owned;
        }

        public void SetOwned(bool ownership)
        {
            owned = ownership;
        }

        public int GetWeaponLongRangeDamage()
        {
            return weaponLongRangeDamage;
        }

        public int GetWeaponLongRangeMulti()
        {
            return weaponLongRangeMulti;
        }


        public int GetWeaponMediumRangeDamage()
        {
            return weaponMediumRangeDamage;
        }
        public int GetWeaponMediumRangeMulti()
        {
            return weaponMediumRangeMulti;
        }
        public int GetWeaponCQDamage()
        {
            return weaponCQDamage;
        }
        public int GetWeaponCQMulti()
        {
            return weaponCQMulti;
        }
    }
}

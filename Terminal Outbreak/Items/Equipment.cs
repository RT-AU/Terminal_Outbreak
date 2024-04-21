using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Outbreak.Items
{
    internal class Equipment
    {
        private int equipmentID;
        private string equipmentName;
        private string equipmentType;
        private int weaponLongRangeDamage;
        private int weaponLongRangeMulti;
        private int weaponMidRangeDamage;
        private int weaponMidRangeMulti;
        private int weaponCQDamage;
        private int weaponCQMulti;
        private string requiresResource;

        // private string equipmentDescription; maybe use

        public Equipment(int ID)
        {
            equipmentID = ID;
            equipmentName = "default";
            equipmentType = "default";
            requiresResource = "none";
            weaponLongRangeDamage = 0;
            weaponLongRangeMulti = 0;
            weaponMidRangeDamage = 0;
            weaponMidRangeMulti = 0;
            weaponCQDamage = 0;
            weaponCQMulti = 0;

            switch (ID)
            {
                case 0:
                    equipmentName = "Baseball Bat";
                    equipmentType = "Melee";

                    weaponCQDamage = 5;

                    break;
                case 1:
                    equipmentName = "Sword";
                    equipmentType = "Melee";
                    weaponCQDamage = 10;
                    weaponCQMulti = 2; //can attack 2 enemies
                    break;
                case 2:
                    equipmentName = "Chainsaw";
                    equipmentType = "Melee";

                    weaponCQDamage = 15;
                    weaponCQMulti = 3; //can attack 3 enemies

                    requiresResource = "Fuel";
                    break;
                case 3:
                    equipmentName = "Rifle";
                    equipmentType = "Primary";
                    weaponLongRangeDamage = 10;
                    weaponLongRangeMulti = 0;

                    weaponMidRangeDamage = 5;
                    weaponMidRangeMulti = 0;

                    weaponCQDamage = 3;
                    break;
                case 4:
                    equipmentName = "Sniper Rifle";
                    equipmentType = "Primary";
                    weaponLongRangeDamage = 20;
                    weaponLongRangeMulti = 4; //can pierce 4 (make random chance between 2-4)

                    weaponMidRangeDamage = 1;
                    weaponMidRangeMulti = 0;

                    weaponCQDamage = 1;
                    break;
                case 5:
                    equipmentName = "HMG";
                    equipmentType = "Primary";
                    weaponLongRangeDamage = 5;
                    weaponLongRangeMulti = 3;

                    weaponMidRangeDamage = 8;
                    weaponMidRangeMulti = 0;

                    weaponCQDamage = 0;
                    break;
                case 6:
                    equipmentName = "Revolver";
                    equipmentType = "Secondary";
                    weaponLongRangeDamage = 5;
                    weaponLongRangeMulti = 0;

                    weaponMidRangeDamage = 10;
                    weaponMidRangeMulti = 0;

                    weaponCQDamage = 1;
                    break;
                case 7:
                    equipmentName = "Pistol";
                    equipmentType = "Secondary";
                    weaponLongRangeDamage = 4;
                    weaponLongRangeMulti = 0;

                    weaponMidRangeDamage = 5;
                    weaponMidRangeMulti = 0;

                    weaponCQDamage = 3;
                    break;
                case 8:
                    equipmentName = "Sawn-Off Shotgun";
                    equipmentType = "Secondary";
                    weaponLongRangeDamage = 1;
                    weaponLongRangeMulti = 0;

                    weaponMidRangeDamage = 3;
                    weaponMidRangeMulti = 3; // mid range damage applied to 3 enemies

                    weaponCQDamage = 10;
                    break;

            }
        }

    }
}

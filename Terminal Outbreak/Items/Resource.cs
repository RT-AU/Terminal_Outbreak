using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Outbreak.Items
{
    internal class Resource
    {
        private int resourceID;
        private string resourceName;

        public Resource(int ID)
        {
            resourceID = ID;
            resourceName = "default";

            switch (resourceID)
            {
                case 0:
                    resourceName = "Food Rations";
                    break;
                case 1:
                    resourceName = "Wood";
                    break;
                case 2:
                    resourceName = "Scrap Metal";
                    break;
                case 3:
                    resourceName = "Fuel Canisters";
                    break;
                case 4:
                    resourceName = "Ammunition";
                    break;
                case 5:
                    resourceName = "Pipes";
                    break;
                case 6:
                    resourceName = "Gun Parts";
                    break;
                case 7:
                    resourceName = "Engine Parts";
                    break;
                case 8:
                    resourceName = "Electrical Kits";
                    break;

            }
        }

        public int GetResourceID()
        {
            return resourceID;
        }
        public string GetResourceName()
        {
            return resourceName;
        }
    }
}

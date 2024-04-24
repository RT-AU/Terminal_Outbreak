using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Items;

namespace Terminal_Outbreak.Managers
{
    internal class EquipmentManager
    {
        private List<Equipment> equipment;
        public EquipmentManager() 
        {
            equipment = new List<Equipment>(); // Create a list of items (in this case, all items in the list)
            for (int i = 0; i < 8; i++)
            {
                Equipment weapon = new Equipment(i);
                equipment.Add(weapon);
            }
        }


        public List<Equipment> GetEquipmentList() // TO DO // Set this up to be used, and make sure it actually works how I would want it to.
        {
            return equipment;
        }




    }
}

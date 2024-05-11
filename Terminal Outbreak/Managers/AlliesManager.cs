using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Entities;
using Terminal_Outbreak.Items;

namespace Terminal_Outbreak.Managers
{
    
    internal class AlliesManager
    {
        List<Ally> allies;
        public AlliesManager()
        {
            allies = new List<Ally>();
            for (int i = 0; i < 4; i++) 
            {
                Ally ally = new Ally(i);
                allies.Add(ally);
            }
        }

        public List<Ally> GetAlliesList() 
        {
            return allies;
        }

        public void HireAlly(int allyID)
        {
            allies[allyID].SetIsHired(true);
        }

        public string HireAlliesReadout(bool isabella, bool steven, bool nate, bool maya)
        {
            string display = string.Empty;

            if (!isabella) 
            {
                display += $"{Environment.NewLine}{Environment.NewLine}{allies[0].GetName()}";
                display += $"{Environment.NewLine}{allies[0].GetDiscription()}";
            }
            if (!steven)
            {
                display += $"{Environment.NewLine}{Environment.NewLine}{allies[1].GetName()}";
                display += $"{Environment.NewLine}{allies[1].GetDiscription()}";
            }
            if (!nate)
            {
                display += $"{Environment.NewLine}{Environment.NewLine}{allies[2].GetName()}";
                display += $"{Environment.NewLine}{allies[2].GetDiscription()}";
            }
            if (!maya)
            {
                display += $"{Environment.NewLine}{Environment.NewLine}{allies[3].GetName()}";
                display += $"{Environment.NewLine}{allies[3].GetDiscription()}";
            }

            return display;
        }

        public string GetAllyNames() 
        {
            int allyCounter = 0;
            string display = $"{Environment.NewLine}    ";
            for (int i = 0; i < allies.Count; i++)
            {
                if (allies[i].GetIsHired())
                {
                    allyCounter++;
                    if (allyCounter > 1)
                    {
                        display += ", ";
                    }
                    if (allyCounter == 3)
                    {
                        display += $"{Environment.NewLine}    ";
                    }
                    display += $"{allies[i].GetName()}";   
                }
            }
            if (allyCounter == 0)
            {
                display = "NONE";
            }
            return display;
        }

        public string GetAllyInfo() 
        {
            string display = string.Empty;
            for (int i = 0; i < allies.Count; i++)
            {
                display += $"{Environment.NewLine}{Environment.NewLine}{allies[i].GetName()}";
                display += $"{Environment.NewLine}{allies[i].GetDiscription()}";
            }
            return display;
        }
    }
}

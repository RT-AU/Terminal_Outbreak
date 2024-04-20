using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Outbreak.Defences
{
    internal class BarrierWall
    {

        private int barrierHealth;
        private int barrierMaxHealth;
        private bool isBuilt;

        public BarrierWall() 
        {
            barrierMaxHealth = 20;
            barrierHealth = 20;
            isBuilt = false;
        }

        public void Damage(int damage)
        {
            barrierHealth -= damage;
        }

        public void Repair() // for now it will just completely repair the baricade at a time cost of 2 hours
        {
            barrierHealth = barrierMaxHealth;
        }

        public void Build()
        { 
            isBuilt = true; 
        }

        public bool getIsBuilt()
        {
            return isBuilt;
        }


    }
}

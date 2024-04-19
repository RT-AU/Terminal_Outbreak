using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Outbreak
{
    internal class Enemy(string enemyType)
    {
        private string enemyType = enemyType;
        private int maxHealth;
        private int enemyDamage;
        private int barrierDamage;
        private int currentLongRangeDistance;
        private int currentMidRangeDistance;
        private bool closeQuartersCombat;

        private int currentHealth;



        public void createEnemy()
        {
            if (enemyType == "zombie")
            {
                this.maxHealth = 5;
                this.enemyDamage = 5;
                this.barrierDamage = 1;
                this.currentLongRangeDistance = 5;
            }
            else if (enemyType == "boss")
            {
                this.maxHealth = 30;
                this.enemyDamage = 20;
                this.barrierDamage = 10;
                this.currentLongRangeDistance = 5;
            }
        }

        public void setHealth(int damage)
        {
            this.currentHealth -= damage;
        }



        public int getHealth() { return this.currentHealth;}

       











    }
}

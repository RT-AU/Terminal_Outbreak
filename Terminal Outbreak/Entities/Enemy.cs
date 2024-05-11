using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Outbreak.Entities
{
    internal class Enemy
    {
        private string enemyID = "";
        private int maxHealth;
        private int enemyDamage;
        private int barrierDamage;
        private int currentHealth;

        public Enemy(string enemyType)
        {
            switch (enemyType)
            {
                case "zombie":
                    enemyID = enemyType;
                    maxHealth = 5;
                    currentHealth = maxHealth;
                    enemyDamage = 5;
                    barrierDamage = 1;
                    break;
                
                case "boss":
                    enemyID = enemyType;
                    maxHealth = 75;
                    currentHealth = maxHealth;
                    enemyDamage = 20;
                    barrierDamage = 10;
                    break;
            }
        }
        public string GetEnemyID()
        {
            return enemyID;
        }

        public void DealDamage(int damage)
        {
            currentHealth -= damage;
        }

        public int GetHealth() 
        { 
            return currentHealth; 
        }

        public int GetDamage()
        {
            return enemyDamage;
        }

        public int GetBarrierDamage()
        {
            return barrierDamage;
        }
    }
}

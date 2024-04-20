using Terminal_Outbreak.Defences;
using Terminal_Outbreak.Items;

namespace Terminal_Outbreak.Managers
{
    // Class which handles the base resources
    internal class BaseManager
    {

        private float prepTime;
        private int foodRations;
        private List<Resource> resources;
        private List<Trap> traps;
        private BarrierWall barrier;

        public BaseManager()
        {
            prepTime = 12.0f;
            foodRations = 5;
            resources = new List<Resource>();
            traps = new List<Trap>();
            barrier = new BarrierWall();
        }


        public void reduceTime (float time)
        {
            prepTime -= time;
        }

        public void resetTime ()
        {
            prepTime = 12.0f;
        }

        public int checkFoodRations()
        {
            return foodRations;
        }

        public void increaseFoodRations(int amount)
        {
            foodRations += amount;
        }
        public void decreaseFoodRations(int amount)
        {
            foodRations -= amount;
        }

        public void buildTrap(int trapID)
        {
            Trap trap = new Trap(trapID);
            traps.Add(trap);
        }

        public void getTraps()
        {
            for (int i = 0; i < traps.Count; i++)
            {
                Console.WriteLine(traps[i].getTrapName());
                Console.WriteLine("Health: " + traps[i].getHealth());
                Console.WriteLine("Deals " + traps[i].getDamage() + " damage");
                Console.WriteLine();
            }
        }

        public int getTrapCount()
        {
            return traps.Count;
        }
    }
}
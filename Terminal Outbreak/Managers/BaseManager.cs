using Terminal_Outbreak.Items;

namespace Terminal_Outbreak.Managers
{
    internal class BaseManager
    {

        private float prepTime;
        private int foodRations;
        private List<Resource> resources;

        public BaseManager()
        {
            foodRations = 5;
            resources = new List<Resource>();
        }
    }
}
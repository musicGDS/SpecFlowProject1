namespace SpecFlowProject1
{
    class AnimalHandler
    {
        public string GetDescription(Animal animal)
        {
            return animal.Description;
        }

        public string GetTitle(Animal animal)
        {
            return animal.API;
        }
    }
}

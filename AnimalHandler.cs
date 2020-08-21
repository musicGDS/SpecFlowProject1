using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject1
{
    class AnimalHandler
    {
        public string GetDescription(Animal animal)
        {
            Console.WriteLine(animal.Description);
            return animal.Description;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Models
{
    internal class SourDough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the Sourdough bread (20 minutes).");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for the Sourdough bread.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Models
{
    internal class WholeWheat : Bread
    {
        public override void Bake() 
        {
            Console.WriteLine("Baking the Whole Wheat bread (15 minutes).");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for the Whole Wheat bread.");
        }
    }
}

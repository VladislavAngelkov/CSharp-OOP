using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (bunny.Dyes.Any(d=>!d.IsFinished()) && bunny.Energy>0 && !egg.IsDone())
            {
                IDye dye = bunny.Dyes.FirstOrDefault(d => !d.IsFinished());

                if (dye == null)
                {
                    break;
                }

                bunny.Work();
                dye.Use();
                egg.GetColored();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kertesz
{
     class Gardener
     {
        public Garden garden;
        public Gardener(Garden garden)
        {
            this.garden= garden;
        }

        public void Planting(int i, Plant plant, int date)
        {
            garden[i].Planting(plant, date, i);
        }

        public void Harvest (int i)
        {
            garden[i].Harvest();
        }
     }
}

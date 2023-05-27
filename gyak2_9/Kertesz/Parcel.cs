using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Kertesz
{
    class Parcel
    {
        public int Number { get; private set; }
        public Plant Content { get; private set; }
        public int PlantingDate { get; private set; }

        public Parcel()
        {
            Content = null;
            PlantingDate = 0;
        }
        public void Harvest()
        {
            Content = null;
        }

        public void Planting(Plant plant, int date, int no)
        {
            if (Content ==null)
            {
                Content = plant;
                PlantingDate = date;
                Number= no;
            }
        }
    }
}

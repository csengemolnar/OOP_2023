using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kertesz
{
     class Garden
     {
        public class WrongParcelNumberException : Exception { }
        readonly List<Parcel> parcels;
        public Garden(int n)
        {
            if (n < 1) throw new WrongParcelNumberException();
            parcels = new();
            for (int i = 0; i < n; i++)
            {
                parcels.Add(new Parcel());
            }

        }

        public Parcel this[int i]
        {
            get 
            { 
                if(i >= 0 && i < parcels.Count) return parcels[i];
                else throw new WrongParcelNumberException();
            }
        }

        public List<int> CanHarvest(int date)
        {
            List<int> result = new List<int>();
            foreach (var p in parcels)
            {
                if (p.Content?.isVegetable() == true && date - p.PlantingDate == p.Content.RipeningTime)
                {
                    result.Add(p.Number);
                }
            }
            return result;
        }
     }
}

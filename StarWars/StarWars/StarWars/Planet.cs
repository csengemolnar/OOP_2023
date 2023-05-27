using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars
{
     class Planet
    {

        public readonly string Name;
        private readonly List<Starship> ships;

        public int NumberOfShips => ships.Count;

        public Planet(string name)
        {
            Name = name;
            ships=new List<Starship>();
        }

        public void LeftBy(Starship starship)
        {
            if (ships.Contains(starship)) ships.Remove(starship);
        }

        public void ProtectedBy(Starship starship)
        {
            if(!ships.Contains(starship)) ships.Add(starship);
        }

        public int TotalShield()
        {
            int s = 0;
            foreach (Starship ship in ships)
            {
                s += ship.GetShield(this);

            }
            return s;

        }

        public bool MaxFirePower(out double max, out Starship bestship)
        {
            bool l = false;
            max = 0;
            bestship = null;

            //felt maxker

            foreach (var ship in ships)
            {
                var power = ship.Firepower();
                if (!l)
                {
                    l= true;
                    max= power;
                    bestship= ship;
                }
                else if(max<power)
                {
                    max=power;
                    bestship= ship;
                }
                

            }
            return l;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace StarWars
{
     class Solarsystem
    {
        public List<Planet> Planets { get; private set; }

        public Solarsystem(string fname)
        {
            TextFileReader reader= new TextFileReader(fname);
            Planets = new();

            while (reader.ReadString(out string name))
            {
                Planets.Add(new Planet(name));

            }

        }

        public Planet SearchPlanetByName(string name)
        {
            foreach (var item in Planets)
            {
                if (string.Equals(item.Name, name))
                {
                    return item;
                }
                
            }
            return null;

            //Linq
            //return Planets.SingleOrDefault(p=> p.Name==name);

        }

        public bool MaxFirePower(out Starship bestShip)
        {
            bool l=false;
            double max = 0;
            bestShip = null;

            foreach (var planet in Planets)
            {
                bool ll = planet.MaxFirePower(out double power, out Starship ship);
                if (!ll) continue;
                if (!l)
                {
                    l = true;
                    max= power;
                    bestShip= ship;
                }else if (max<power)
                {
                    max= power;
                    bestShip= ship;

                }
            }
            return l;
        }

        public List<string> Defensless()
        {
            List<string> list = new List<string>();
            foreach (var planet in Planets)
            {
                if (planet.NumberOfShips == 0)
                {
                    list.Add(planet.Name);
                }
            }
            return list;
        }
    }
}

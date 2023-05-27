using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars
{
     abstract class Starship
    {

        public class StarShipInServiceException:Exception { }
        public class StarShipFreeException:Exception { }
        public class NotYourBusinessException:Exception { }

        public readonly string name;
        protected readonly int shield;
        protected readonly int armor;
        protected readonly int guard;

        public Planet planet { get; private set; }

        public int GetShield(Planet p)
        {

            if(this.planet!=p) throw new NotYourBusinessException();
            return shield;
        }

        public Starship(string name, int shield, int armor, int guard)
        {
            this.name = name;
            this.shield = shield;
            this.armor = armor;
            this.guard = guard;
            
        }

        public void Protect(Planet p)
        {
            if (p!=null) throw new StarShipInServiceException();
            this.planet = p;
            p.ProtectedBy(this);

            
        }

        public void Leave()
        {
            if(planet==null) throw new StarShipFreeException();
            planet.LeftBy(this);
            planet = null;
        }

        public abstract int Firepower();

        class Braker : Starship
        {
            public Braker(string name, int shield, int armor, int guard) : base(name, shield, armor, guard)
            {
            }

            public override int Firepower()
            {
                return armor / 2;
            }
        }

        class Lander : Starship
        {
            public Lander(string name, int shield, int armor, int guard) : base(name, shield, armor, guard)
            {
            }

            public override int Firepower()
            {
                return guard;
            }
        }

        class Laser : Starship
        {
            public Laser(string name, int shield, int armor, int guard) : base(name, shield, armor, guard)
            {
            }

            public override int Firepower()
            {
                return shield;
            }
        }
    }
}

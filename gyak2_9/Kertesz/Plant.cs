using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Kertesz
{
    abstract class Plant
    {
        public int RipeningTime { get; }
        protected Plant(int ripeningTime)
        {
            RipeningTime = ripeningTime;
        }
        public virtual bool isVegetable() => false;
        public virtual bool isFlower() => false;
    }
    abstract class Vegetable:Plant
    {
        protected Vegetable(int date):base(date) { }
        public override bool isVegetable() => true;
                
    }

    abstract class Flower : Plant 
    {
        protected Flower(int date):base(date) { }
        public override bool isFlower()
        {
            return true;
        }

    }

    // Pea 3, Potato 5; Onion 4, Tulip 7, Carnation 10, Rose 8

    class Pea : Vegetable
    {
        protected Pea():base(3) { }
        private static Pea instance;

        public static Pea Instance
        {
            get 
            { 
                if(instance ==null) instance= new Pea();
                return instance; 
            }
           
        }

    }

    class Potato : Vegetable
    {
        protected Potato() : base(5) { }
        private static Potato instance;

        public static Potato Instance
        {
            get
            {
                if (instance == null) instance = new Potato();
                return instance;
            }

        }

    }

    class Onion : Vegetable
    {
        protected Onion() : base(4) { }
        private static Onion instance;

        public static Onion Instance
        {
            get
            {
                if (instance == null) instance = new Onion();
                return instance;
            }

        }

    }
    class Tulip : Flower
    {
        protected Tulip() : base(7) { }
        private static Tulip instance;

        public static Tulip Instance
        {
            get
            {
                if (instance == null) instance = new Tulip();
                return instance;
            }

        }

    }
    class Carnation : Vegetable
    {
        protected Carnation() : base(10) { }
        private static Carnation instance;

        public static Carnation Instance
        {
            get
            {
                if (instance == null) instance = new Carnation();
                return instance;
            }

        }

    }
    class Rose : Flower
    {
        protected Rose() : base(8) { }
        private static Rose instance;

        public static Rose Instance
        {
            get
            {
                if (instance == null) instance = new Rose();
                return instance;
            }

        }

    }

}

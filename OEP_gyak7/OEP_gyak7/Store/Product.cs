using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
     class Product
    {
        public int Price { get; private set; }

        public string Name { get; private set; }

        public Product(string str, int i)
        {
            Name= str;
            Price = i;

        }

    }
}

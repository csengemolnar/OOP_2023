using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace Store
{
     class Customer
    {
        private string Name { get; set; }
        readonly List<string> list= new List<string>();
        public List<Product> cart= new List<Product>();

        public Customer(string filename)
        {
            TextFileReader reader = new TextFileReader(filename);
            reader.ReadString(out string str);
            Name = str;
            while(reader.ReadString(out str))
            {
                list.Add(str);
            }
        }

        public void Purchase(Store store)
        {
            Console.WriteLine($"{Name} vásárló megvette az alábbiakat: ");
            foreach (var productname in list)
            {
                if(LinSearch(productname, store.foods, out Product product))
                {
                    Drag(product, ref store.foods);
                    Console.WriteLine($"{productname} - {product}");
                }

            }

            foreach (var productname in list)
            {
                if (MinSearch(productname, store.technical, out Product product))
                {
                    Drag(product, ref store.technical);
                    Console.WriteLine();
                }

            }
        }

        private bool MinSearch(string productname, Department department, out Product product)
        {
            bool l = false;
            product = null;
            int min = 0;
            foreach (var p in department) 
            {
                if (p.Name != productname) continue;
                if (l)
                {
                    if (min > p.Price)
                    {
                        min=p.Price;
                    }


                }
                else
                {
                    l = true;
                    product= p;
                    min= p.Price;


                }
            }

        }

        private void Drag(Product product, ref Department department)
        {
            department.stock.Remove(product);
        }

        private bool LinSearch(string productname, Department department, out Product product)
        {
           // product=department.stock.First(p=>p.Name==productname);
            //return product!= null;
            bool l = false;
            product = null;
            foreach (var p in department.stock)
            {
                if (l = (p.Name == productname))
                {
                    product = p;break;
                }
            }
            return l;
        }
    }
}

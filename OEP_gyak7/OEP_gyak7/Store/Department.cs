using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace Store
{
    internal class Department
    {
        public List<Product> stock=new List<Product>();
        public Department(string filename)
        {
            TextFileReader reader= new TextFileReader(filename);
            reader.ReadString(out string str);

            while (reader.ReadInt(out int i))
            {
                stock.Add(new Product(str, i));
                reader.ReadString(out str);
            }
        }
    }
}

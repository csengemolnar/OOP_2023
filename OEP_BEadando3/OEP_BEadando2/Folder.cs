using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OEP_BEadando3
{
    class Folder : Registration
    {
        private List<Registration> items = new List<Registration>();

        public override int GetSize()
        {
            int sum = 0;
            foreach (var i in items)
            {
               sum += i.GetSize();
            }

            return sum;


             
        }

        public void Add(Registration r)
        {
            items.Add(r);
        }

        public void Remove(Registration r)
        {
            items.Remove(r);
        }
    }
}

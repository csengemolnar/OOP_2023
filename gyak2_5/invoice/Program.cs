using TextFile;
using System.Collections.Generic;
using System.Linq;
namespace invoice
{
     class Program
    {
        struct Product
        {
            public string id;
            public int price;
            public Product(string i, int p)
            {
                id = i;
                price = p;

            }   

        }

        class Invoice
        {
            public string name;
            public List<Product> products;

            public Invoice(string name)
            {
                this.name= name;
                this.products = new();

            }
            public void Add(Product p)
            {
                products.Add(p);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                TextFileReader f = new TextFileReader("Input.txt");
                int income = 0;
                while(ReadInvoice(ref f, out Invoice invoice))
                {
                    income += Sum(invoice.products);
                }
                Console.WriteLine($"Total income: {income}");
            }
            catch (System.IO.FileNotFoundException)
            {

                Console.WriteLine("The file does not exist");
            }
        }

        private static int Sum(List<Product> products)
        {
            int total = 0;
            foreach (Product p in products)
            {
                total += p.price;
            }
            return total;
        }

        private static bool ReadInvoice(ref TextFileReader f, out Invoice invoice)
        {
            invoice = null;
            bool l=f.ReadLine(out string line);
            if (l)
            {
                char[] sep=new char[] { ' ','\t'};
                var tokens=line.Split(sep,StringSplitOptions.RemoveEmptyEntries);
                invoice=new Invoice(tokens[0]);
                for (int i = 1; i < tokens.Length; i+=2)
                {
                    invoice.Add(new Product(tokens[i], int.Parse(tokens[i + 1])));

                }

            }
            return l;
        }
    }
}
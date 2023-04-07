using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrSor
{
    class Menu
    {
        readonly PrQueue pq = new();
        public void Run()
        {
            int v;
            do
            {
                v = GetMenuPoint();
                switch (v)
                {
                    case 1: PutIn();Write();break;
                    case 2: RemoveMax();Write();break;
                    case 3: GetMax();Write();break;
                    case 4: CheckEmpty();Write();break;
                    case 5: Write();break;
                    default:
                        Console.WriteLine("\nWiszont látásra!");
                        break;
                }

            } while (v!=0);
        }

        private void CheckEmpty()
        {
            Console.WriteLine((pq.isEmpty()) ? "A sor üres" : "A sor nem üres");
        }

        private void GetMax()
        {
            Element e;
            try
            {
                e = pq.GetMax();
                Console.WriteLine($"A legnagyobb elem: {e}");
            }
            catch (PrQueue.PrQueueEmpty)
            {

                Console.WriteLine("Lekérdezés hiba, a sor üres!\n");
            }
        }

        private void RemoveMax()
        {
            Element e;
            try
            {
                e = pq.RemMax();
                Console.WriteLine($"A kivett elem: {e}");
            }
            catch (PrQueue.PrQueueEmpty)
            {

                Console.WriteLine("Kivétel hiba, a sor üres!\n");
            }
        }

        private void PutIn()
        {
            Element e = new();
            e.Read();
            pq.Add(e);
        }

        private void Write()
        {
            pq.Write();
        }

        private int GetMenuPoint()
        {

            int v;
            do
            {
                Console.WriteLine("\n0. Kilépés");
                Console.WriteLine("1. Prsorba berak");
                Console.WriteLine("2. Legnagyobbat kivesz");
                Console.WriteLine("3. Legnagyobbat lekérdez");
                Console.WriteLine("4. Üres-e vizsgálat");
                Console.WriteLine("5. Sort kiír");


                try
                {
                    v = int.Parse(Console.ReadLine()!);
                }
                catch (FormatException)
                {

                    v = -1;
                }
            } while (v<0||v>5);
            return v;
        }
    }
}

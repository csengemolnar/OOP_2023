using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace Nagybeadando
{
     class Konyvtar
    {
        public class NincsilyenTag : Exception { }
        public class NincsilyenKonyv : Exception { }
        public class Kolcsonzesilimit : Exception { }
        public class VanIlyenTag : Exception { }
        public class Nincsmegadva : Exception { }
        public class NincsilyenKonyvKikolcsonozve: Exception { }
        public List<Konyv> konyvek { get;  private set; }
        public List<Szemely> tagok { get; private set; }
        private List<Kolcsonzes> kolcsonzesek { get; set; }

       


        public Konyvtar()
        {
            BetoltKonyvek();
            BetoltTagok();
            BetoltKolcsonzesek();



        }

        private void BetoltKonyvek()
        {
            try
            {
                string filename2 = "konyvek.txt";
                this.konyvek = new List<Konyv>();
                char[] sep = new char[] { ',', '\n' };
                TextFileReader reader2 = new TextFileReader(filename2);
                while (reader2.ReadLine(out string line))
                {
                    string[] tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);

                    konyvek.Add(new Konyv
                    (
                        tokens[0],
                        tokens[1],
                        tokens[2],
                        tokens[3],
                        int.Parse(tokens[4]),
                        bool.Parse(tokens[5]),
                        tokens[6]
                    ));

                }
                reader2.CloseReader();
                Console.WriteLine($"A könyvtár betöltötte a könyveket az adatbázisába!");

            }
            catch (System.IO.FileNotFoundException)
            {

                Console.WriteLine("A fájl nem található!");
            }

        }

        private void BetoltTagok()
        {
            try
            {
                string filename1 = "szemelyek.txt";
                this.tagok = new List<Szemely>();
                TextFileReader reader = new TextFileReader(filename1);
                while (reader.ReadLine(out string str))
                {
                    Szemely sz = new Szemely(str);
                    this.tagok.Add(sz);
                }
                reader.CloseReader();
                Console.WriteLine($"A könyvtár betöltötte a tagokat az adatbázisába!");

            }
            catch (System.IO.FileNotFoundException)
            {

                Console.WriteLine("A fájl nem található!");
            }

            

        }

        private void BetoltKolcsonzesek()
        {

            try
            {
                
                string filename3 = "kolcsonzesek.txt";
                char[] sep = new char[] { ',', '\n' };
                this.kolcsonzesek = new List<Kolcsonzes>();
                TextFileReader reader3 = new TextFileReader(filename3);
                while (reader3.ReadLine(out string line2))
                {
                    string[] tokens1 = line2.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    kolcsonzesek.Add(new Kolcsonzes
                    (
                        DateTime.Parse(tokens1[0]),
                        new Szemely(tokens1[1]),
                        new Konyv(tokens1[2],
                                tokens1[3],
                                tokens1[4],
                                tokens1[5],
                                int.Parse(tokens1[6]),
                                bool.Parse(tokens1[7]),
                                tokens1[8])
                    ));
                    
                }
                reader3.CloseReader();
                Console.WriteLine($"A könyvtár betöltötte a kölcsönzéseket az adatbázisába!");

            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("A fájl nem található!");

            }
            

        }

        


        public void Belep(Szemely sz){

            Szemely tag = TKereses(sz.nev);

            if (tag != null)
            {
                throw new VanIlyenTag();
            }
            else
            {
                tagok.Add(sz);
                Console.WriteLine($"{sz.nev} könytári tag lett!");


                

            }
                
        }

        public void Beszerez(Konyv k)
        {
            k.azonosito = Letrehoz();
            konyvek.Add(k);
            Console.WriteLine($"A könyv: {k.cim} bekerült a könyvtárba!");

            string path = "C:\\Users\\Csenge\\Documents\\Egyetem\\Prog Inf\\2. félév\\Objektumorientált programozás\\GY\\OOP_2023\\Nagybeadando\\Nagybeadando\\konyvek.txt";
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine($"{k.cim},{k.szerzo},{k.azonosito},{k.ISBN},{k.oldal.ToString()},{k.ritkasage.ToString()},{k.mufaj}");
            writer.Close();
            
        }

        private string Letrehoz()
        {
            string unique = System.Guid.NewGuid().ToString();
            return unique;
        }
 
        //A tagok listajaban megkeressuk a szemelyt
        private Szemely TKereses(string nev)
        {
            Szemely szemely = null;
            foreach (Szemely sz in tagok)
            {
                if (sz.nev==nev)
                {
                    szemely = sz;

                }


            }
            return szemely;

        }



        public void Kolcsonoz(string n, string[] azon)
        {
            Szemely tag =TKereses(n);
            
            if (tag == null) throw new NincsilyenTag();

            int count = 0;
            for (int s = 0; s < this.kolcsonzesek.Count; s++)
            {
                if (this.kolcsonzesek[s].szemely.nev == tag.nev)
                {
                    count += 1;
                }

            }
            if(count>5) throw new Kolcsonzesilimit();
            if (azon == null) throw new Nincsmegadva();
            for (int i = 0; i < this.konyvek.Count; i++)
            {
                for (int j = 0; j < azon.Length; j++)
                {
                    if (this.konyvek[i].azonosito == azon[j])
                    {
                        Console.WriteLine("---------");
                        Console.WriteLine($"A {this.konyvek[i].cim} ki lett kölcsönözve a könyvtárból {tag.nev} által! ");
                        this.kolcsonzesek.Add(new Kolcsonzes(tag, this.konyvek[i]));
                        this.konyvek.Remove(this.konyvek[i]);

                    }else throw new NincsilyenKonyv();

                }
            }
            
            
            
            

        }

        public void Visszahoz(string[] azon)
        {
            for (int i = 0; i < this.kolcsonzesek.Count; i++)
            {
                for (int j = 0; j < azon.Length; j++)
                {
                    if (this.kolcsonzesek[i].konyv.azonosito == azon[j])
                    {
                        Console.WriteLine("---------");
                        Console.WriteLine($"A kikölcsönzött könyv: {this.kolcsonzesek[i].konyv.cim} vissza lett hozva");
                        this.kolcsonzesek[i].Potdijfizet();
                        this.konyvek.Add(kolcsonzesek[i].konyv);
                        this.kolcsonzesek.Remove(kolcsonzesek[i]);

                    }
                    else throw new NincsilyenKonyvKikolcsonozve();

                }
            }

        }

        


    }
}

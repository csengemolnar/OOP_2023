﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
                char[] sep = new char[] { ',', '\n' };
                TextFileReader reader = new TextFileReader(filename1);
                while (reader.ReadLine(out string line))
                {
                   string[] tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);

                    Szemely sz = new Szemely(int.Parse(tokens[0]), tokens[1]);
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
                        new Szemely(int.Parse(tokens1[1]), tokens1[2]),
                        new Konyv(tokens1[3],
                                tokens1[4],
                                tokens1[5],
                                tokens1[6],
                                int.Parse(tokens1[7]),
                                bool.Parse(tokens1[8]),
                                tokens1[9])
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

            

            string path = "szemelyek.txt";
            StreamWriter writer = new StreamWriter(path, true);
            sz.id = this.tagok.Count();
            writer.WriteLine($"{sz.id},{sz.nev}");
            writer.Close();

            tagok.Add(sz);
            Console.WriteLine($"{sz.nev} könytári tag lett!");

        }

        public void Beszerez(Konyv k)
        {
            k.azonosito = Letrehoz();
            konyvek.Add(k);
            Console.WriteLine($"A könyv: {k.cim} bekerült a könyvtárba!");

            string path = "konyvek.txt";
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine($"{k.cim},{k.szerzo},{k.azonosito},{k.ISBN},{k.oldal.ToString()},{k.ritkasage.ToString()},{k.mufaj}");
            writer.Close();
            
        }

        private string Letrehoz()
        {
            string unique = System.Guid.NewGuid().ToString();
            return unique;
        }
 
        //A tagok listajaban megkeressuk a szemelyt
        private Szemely TKereses(int id)
        {
            Szemely szemely = null;
            foreach (Szemely sz in tagok)
            {
                if (sz.id==id)
                {
                    szemely = sz;

                }


            }
            return szemely;

        }



        public void Kolcsonoz(int id, string[] azon)
        {
            Szemely tag =TKereses(id);
            
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

                        string path2 = "kolcsonzesek.txt";
                        StreamWriter writer2 = new StreamWriter(path2, true);
                        writer2.WriteLine($"{tag.nev},{konyvek[i].cim},{konyvek[i].szerzo},{konyvek[i].azonosito},{konyvek[i].ISBN},{konyvek[i].oldal.ToString()},{konyvek[i].ritkasage.ToString()},{konyvek[i].mufaj}");
                        writer2.Close();
                        
                        
                        this.konyvek.Remove(this.konyvek[i]);

                        string path = "konyvek.txt";
                        StreamWriter writer = new StreamWriter(path);
                        for (int s = 0; s < konyvek.Count; s++)
                        {
                            writer.WriteLine($"{konyvek[i].cim},{konyvek[i].szerzo},{konyvek[i].azonosito},{konyvek[i].ISBN},{konyvek[i].oldal.ToString()},{konyvek[i].ritkasage.ToString()},{konyvek[i].mufaj}");

                        }
                        writer.Close();

                    }
                    else throw new NincsilyenKonyv();

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

                        string path = "konyvek.txt";
                        StreamWriter writer = new StreamWriter(path);
                        for (int s = 0; s < konyvek.Count; s++)
                        {
                            writer.WriteLine($"{konyvek[i].cim},{konyvek[i].szerzo},{konyvek[i].azonosito},{konyvek[i].ISBN},{konyvek[i].oldal.ToString()},{konyvek[i].ritkasage.ToString()},{konyvek[i].mufaj}");

                        }
                        writer.Close();


                        this.kolcsonzesek.Remove(kolcsonzesek[i]);
                        string path2 = "kolcsonzesek.txt";
                        StreamWriter writer2 = new StreamWriter(path2);
                        for (int s = 0; s < kolcsonzesek.Count; s++)
                        {
                            writer2.WriteLine($"{kolcsonzesek[i].datum},{kolcsonzesek[i].szemely.nev},{kolcsonzesek[i].konyv.cim},{kolcsonzesek[i].konyv.szerzo},{kolcsonzesek[i].konyv.azonosito},{kolcsonzesek[i].konyv.ISBN},{kolcsonzesek[i].konyv.oldal.ToString()},{kolcsonzesek[i].konyv.ritkasage.ToString()},{kolcsonzesek[i].konyv.mufaj}");

                        }
                        writer2.Close();

                    }
                    else throw new NincsilyenKonyvKikolcsonozve();

                }
            }

        }

        


    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace KonyvtarBead
{
     public class Konyvtar
    {
        public class NincsilyenTag : Exception { }
        public class NincsilyenKonyv : Exception { }
        public class Kolcsonzesilimit : Exception { }
        public class VanIlyenTag : Exception { }
        public class Nincsmegadva : Exception { }
        public class NincsilyenKonyvKikolcsonozve: Exception { }
        public List<Konyv> konyvek { get;  private set; }
        public List<Szemely> tagok { get; private set; }
        public List<Kolcsonzes> kolcsonzesek { get; private set; }

       


        public Konyvtar()
        {
            BetoltKonyvek(true);
            BetoltTagok(true);
            BetoltKolcsonzesek(true);
        }

        private void BetoltKonyvek(bool flag)
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
                        tokens[6],
                        bool.Parse(tokens[7])
                    ));

                }
                reader2.CloseReader();
                
                if (flag)
                {
                    Console.WriteLine($"A könyvtár betöltötte a könyveket az adatbázisába!");

                }
                

            }
            catch (System.IO.FileNotFoundException)
            {

                Console.WriteLine("A fájl nem található!");
            }

        }

        private void BetoltTagok(bool flag)
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
                if (flag)
                {
                    Console.WriteLine($"A könyvtár betöltötte a tagokat az adatbázisába!");
                }
                

            }
            catch (System.IO.FileNotFoundException)
            {

                Console.WriteLine("A fájl nem található!");
            }

            

        }

        private void BetoltKolcsonzesek(bool flag)
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
                        int.Parse(tokens1[1]),
                        tokens1[2]
                        
                    ));
                    
                }
                reader3.CloseReader();
                if (flag)
                {
                    Console.WriteLine($"A könyvtár betöltötte a kölcsönzéseket az adatbázisába!");
                }
                

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
            BetoltTagok(false);

        }

        public void Beszerez(Konyv k)
        {
            k.azonosito = Letrehoz();
            konyvek.Add(k);
            Console.WriteLine($"A könyv: {k.cim} bekerült a könyvtárba!");

            string path = "konyvek.txt";
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine($"{k.cim},{k.szerzo},{k.azonosito},{k.ISBN},{k.oldal.ToString()},{k.ritkasage.ToString()},{k.mufaj},{k.kolcsonk.ToString()}");
            writer.Close();
            BetoltKonyvek(false);
            
        }

        private string Letrehoz()
        {
            string unique = System.Guid.NewGuid().ToString();
            return unique;
        }
 
        //A tagok listajaban megkeressuk a szemelyt
        public Szemely TKereses(int id)
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

        public Konyv KKeres(string azon)
        {
            Konyv konyv = null;
            foreach(Konyv k in konyvek)
            {
                if (k.azonosito == azon)
                {
                    konyv = k;
                }
            }
            return konyv;
        }



        public void Kolcsonoz(int id, string[] azon)
        {
            Szemely tag =TKereses(id);
            
            if (tag == null) throw new NincsilyenTag();

            int count = 0;
            for (int s = 0; s < this.kolcsonzesek.Count; s++)
            {
                if (this.kolcsonzesek[s].id == tag.id)
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
                    if (this.konyvek[i].azonosito.Equals(azon[j]))
                    {
                        Console.WriteLine("---------");
                        Console.WriteLine($"A {this.konyvek[i].cim} ki lett kölcsönözve a könyvtárból {tag.nev} által! ");
                        Kolcsonzes ujKolcsonzes = new Kolcsonzes(tag.id, this.konyvek[i].azonosito);
                        this.kolcsonzesek.Add(ujKolcsonzes);

                        string path2 = "kolcsonzesek.txt";
                        StreamWriter writer2 = new StreamWriter(path2, true);
                        writer2.WriteLine($"{ujKolcsonzes.datum.ToString("yyyy.MM.dd hh:mm:ss")},{tag.id},{konyvek[i].azonosito}");
                        writer2.Close();
                        
                        
                        this.konyvek[i].kolcsonk=true;

                        string path = "konyvek.txt";
                        StreamWriter writer = new StreamWriter(path);
                        for (int s = 0; s < konyvek.Count; s++)
                        {
                            writer.WriteLine($"{konyvek[s].cim},{konyvek[s].szerzo},{konyvek[s].azonosito},{konyvek[s].ISBN},{konyvek[s].oldal.ToString()},{konyvek[s].ritkasage.ToString()},{konyvek[s].mufaj}, {konyvek[s].kolcsonk}");

                        }
                        writer.Close();

                        this.BetoltKolcsonzesek(false);
                        this.BetoltKonyvek(false);

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
                    if (this.kolcsonzesek[i].azon.Equals(azon[j]))
                    {
                        Szemely sz = this.TKereses(kolcsonzesek[i].id);
                        Konyv k = this.KKeres(kolcsonzesek[i].azon);

                        Console.WriteLine("---------");
                        Console.WriteLine($"A kikölcsönzött könyv: {k.cim} vissza lett hozva");
                        int potdij = PotdijSzamol(kolcsonzesek[i]);
                        Console.WriteLine($"Személy: {sz.nev}\tKönyv: {k.cim}\tFizetendő pótdíj: {potdij.ToString()}");

                        //azon alapján megkeresem a kikölcsönzött könyvet és a kolcsonk-t visszaállítom false-ra
                        int m = 0;
                        while (m < this.konyvek.Count)
                        {
                            if (konyvek[m].azonosito.Equals(k.azonosito))
                            {
                                this.konyvek[m].kolcsonk = false;
                            }
                            m++;
                        }

                        string path = "konyvek.txt";
                        StreamWriter writer = new StreamWriter(path);
                        for (int s = 0; s < konyvek.Count; s++)
                        {
                            writer.WriteLine($"{konyvek[s].cim},{konyvek[s].szerzo},{konyvek[s].azonosito},{konyvek[s].ISBN},{konyvek[s].oldal.ToString()},{konyvek[s].ritkasage.ToString()},{konyvek[s].mufaj}, {konyvek[s].kolcsonk.ToString()}");

                        }
                        writer.Close();


                        this.kolcsonzesek.Remove(kolcsonzesek[i]);
                        string path2 = "kolcsonzesek.txt";
                        StreamWriter writer2 = new StreamWriter(path2);
                        for (int s = 0; s < kolcsonzesek.Count; s++)
                        {
                            writer2.WriteLine($"{kolcsonzesek[s].datum},{kolcsonzesek[s].id},{kolcsonzesek[s].azon}");

                        }
                        writer2.Close();

                        this.BetoltKolcsonzesek(false);
                        this.BetoltKonyvek(false);
                    }
                    

                }
            }

        }

        private int PotdijSzamol(Kolcsonzes kolcs)
        {
            int elteltido=0;
            if (DateTime.Now > kolcs.datum.AddDays(14))
            {
                elteltido = (DateTime.Now - kolcs.datum).Days;
                
            }
            Konyv k = KKeres(kolcs.azon);
            int osszeg = 0;
            if (k.mufaj.Equals("természettudományi") && k.ritkasage)
            {
                osszeg = 100 * elteltido;
            }
            else if (k.mufaj.Equals("természettudományi") && !k.ritkasage)
            {
                osszeg = 20 * elteltido;
            }
            else if (k.mufaj.Equals("szépirodalmi") && k.ritkasage)
            {
                osszeg = 50 * elteltido;
            }
            else if (k.mufaj.Equals("szépirodalmi") && !k.ritkasage)
            {
                osszeg = 10 * elteltido;
            }
            else if (k.mufaj.Equals("ifjúsági") && k.ritkasage)
            {
                osszeg = 30 * elteltido;
            }
            else if (k.mufaj.Equals("ifjúsági") && !k.ritkasage)
            {
                osszeg = 10 * elteltido;
            }

            return osszeg;

        }




    }
}

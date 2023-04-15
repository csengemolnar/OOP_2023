using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace bevetel
{
    public struct Aru
    {
        public string termek;
        public int ar;

    }

    public class Szamla
    {
        public readonly string nev;
        public readonly List<Aru> vasarlas;
        public Szamla(string nev, List<Aru> vasarlas)
        {
            this.nev = nev;
            this.vasarlas = vasarlas;
            
        }


    }

     public class ReadFile
    {
        public readonly TextFileReader reader;
        public ReadFile(string r)
        {
            reader = new TextFileReader(r);
            
        }

        public bool ReadSzamla(out Szamla szamla)
        {
            szamla = null;
            var aru = new List<Aru>();
            char[] sep= new char[] {' ','\t'};
            if(reader.ReadLine(out string line))
            {
                var tokens=line.Split(sep,StringSplitOptions.RemoveEmptyEntries);

                for (int i = 1; i < tokens.Length; i+=2)
                {
                    aru.Add(new Aru {
                        termek = tokens[i],
                        ar = int.Parse(tokens[i+1]),
                    });


                }
                szamla = new Szamla(tokens[0], aru);
                return true;
            }
            else
            {
                return false;
            }
        }
    }




}



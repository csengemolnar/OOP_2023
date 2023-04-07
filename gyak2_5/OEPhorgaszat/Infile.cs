using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace OEPhorgaszat
{
    public struct Fogás
    {
        public string time;
        public string fish;
        public double weight;
        public double height;
    }
    public class Fisher
    {
        public readonly string name;
        public readonly List<Fogás> Fogások;

        public Fisher(string name, List<Fogás> fogások)
        {
            this.name = name;
            this.Fogások = fogások;
        }
    }
     public class Infile
    {
        readonly TextFileReader reader;
        public Infile(string fname)
        {
            reader = new TextFileReader(fname);

        }

        public bool ReadFisher(out Fisher fisher)
        {
            fisher = null;
            var t = new List<Fogás>();
            char[] sep = new char[] { ' ','\t'};
            if (reader.ReadLine(out string line))
            {
                var tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 1; i < tokens.Length; i+=4)
                {
                    t.Add(new Fogás
                    {
                        time = tokens[i],
                        fish = tokens[i + 1],
                        weight = double.Parse(tokens[i + 2]),
                        height = double.Parse(tokens[i + 3]),
                    });

                }
                fisher = new Fisher(tokens[0], t);
                return true;
            }
            else return false;
        }

    }
}

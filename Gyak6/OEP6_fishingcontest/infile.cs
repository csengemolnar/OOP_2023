using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEP6_fishingcontest
{
    public class infile
    {
        readonly TextReader reader;
        public infile(string fname)
        {
            this.reader= new StreamReader(fname);

        }

        public bool ReadFisher(out fisher fisher)
        {
            fisher = null;
            string line = reader.ReadLine();
            if (!String.IsNullOrEmpty(line)) 
            {
                string[] tokens=line.Split(new char[] { ' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
                fisher = new fisher { Name = tokens[0], OK = Ok(tokens) };
                return true;
            }
            else return false;
        }
         
        private bool Ok(string[] tokens)
        {
            int i;
            for ( i = 1; i < tokens.Length && !(tokens[i+1]=="ponty" && double.Parse(tokens[i+2])>=1); i+=4)
            {

            }
            int db = 0;
            for (; i < tokens.Length; i+=4)
            {
                if (tokens[i+1]=="harcsa" && double.Parse(tokens[i + 3] ) >= 1)
                {
                    ++db;
                }

            }
            return db >= 4;
        }
    }
}

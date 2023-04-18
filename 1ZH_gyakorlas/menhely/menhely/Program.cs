using TextFile;

namespace menhely
{
    public class Kutyak
    {
        //Tipus;Kor;Suly;Gazda

        public string Tipus;
        public int Kor;
        public int Suly;
        public string Gazda;
        public Kutyak(string t, int k, int s,string g)
        {
            this.Tipus = t;
            this.Kor = k;
            this.Suly = s;
            this.Gazda = g;
            
        }
    }
      class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TextFileReader reader = new TextFileReader("input.txt");
                
                int db = 0;
                int dba = 0;
                int min = int.MaxValue;
                string minfaj = "";
                int gazdatlankor = 0;
                int gazdaskor = 0;
                int gazdasdb = 0;
                int i = 0;
                

                while (ReadMenhely(ref reader, out Kutyak kutyak))
                {
                   
                    
                    if (kutyak.Kor < min && kutyak.Gazda!=null)
                    {
                        min = kutyak.Kor;
                        minfaj = kutyak.Tipus;

                    }
                    if (kutyak.Gazda == null)
                    {
                        db++;
                        gazdatlankor += kutyak.Kor;
                    }
                    if (kutyak.Gazda != null)
                    {
                        gazdasdb++;
                        gazdaskor += kutyak.Kor;
                    }

                    if (kutyak.Tipus=="Akita" && kutyak.Kor > 10)
                    {
                        dba++;
                    }

                   

                }
                int gazdasatlag = gazdaskor / gazdasdb;
                int gazdatlanatlag = gazdatlankor / db;
                if (gazdasatlag < gazdatlanatlag)
                {
                    Console.WriteLine("A fiatalabb kutyákat előbb fogadják örökbe!");
                }
                else
                {
                    Console.WriteLine("Az idősebb kutyákat előbb fogadják örökbe!");
                }

                
                
                Console.WriteLine($"A kutyák száma, akiket nem fogadtak örökbe:{db}");
                Console.WriteLine($"10 évnél idősebb Akiták száma:{dba}");
                Console.WriteLine($"A legfiatalabb örökbefogadott kutya fajtaja: {minfaj}");
                Console.WriteLine($"A legfiatalabb örökbefogadott kutya fajtaja: {minfaj}");

            }
            catch (System.IO.FileNotFoundException)
            {

                Console.WriteLine("A file nem található!");
            }
            
        }

        private static bool ReadMenhely(ref TextFileReader reader, out Kutyak kutyak)
        {
            kutyak = null;
            char[] sep = new char[] {';'};
            while (reader.ReadLine(out string line))
            {
                
                var tokens = line.Split(sep,StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 4)
                {
                    kutyak = new Kutyak(tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2]), tokens[3]) ;
                    
                }
                else
                {
                    kutyak = new Kutyak(tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2]), null);
    

                }
                
                
               
                return true;

            }
            
            return false;
            
            
            

        }

    }
}
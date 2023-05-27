using TextFile;

namespace StarWars
{
     class Program
    {

        class NonExistingPlanetException : Exception { }
        static void Main(string[] args)
        {
            Solarsystem ss = new("Solarsystem.txt");

            try
            {
                TextFileReader reader = new TextFileReader("input.txt");
                reader.ReadInt(out int n);
                for (int i = 0; i < n; i++)
                {
                    reader.ReadString(out string pname);
                    var planet=ss.SearchPlanetByName(pname);
                    if(planet==null) throw new NonExistingPlanetException();
                    reader.ReadInt(out int m);
                    for (int j = 0; j < m; j++)
                    {
                        Starship ship = null;
                        reader.ReadString(out string sname);
                        reader.ReadString(out string type);
                        reader.ReadInt(out int s);
                        reader.ReadInt(out int a);
                        reader.ReadInt(out int g);

                        switch (type)
                        {
                            case "Breaker":ship= new Braker(sname,s,a,g); break;
                            case "Lander": ship = new Lander(sname, s, a, g); break;
                            case "Laser": ship = new Laser(sname, s, a, g); break;

                        }
                        ship.Protect(planet);
                       

                    }

                }

                Console.WriteLine(ss.MaxFirePower(out Starship starship) ? $"Best firepower: {starship.name}");
            }
            catch (System.IO.FileNotFoundException)
            {

                Console.WriteLine("File does not exist!");
            }
            catch (Starship.StarShipInServiceException)
            {

                Console.WriteLine("Starship in Service!");
            }
            catch (Starship.NotYourBusinessException)
            {

                Console.WriteLine("FIle does not exist!");
            }
        }
    }
}
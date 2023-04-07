namespace Kör
{
     class Program
    {
        static Random rand = new Random(DateTime.Now.Millisecond);
        static List<point> points = new List<point>(); 
        static void Main(string[] args)
        {
            int n = 3;
            for(int i =0; i<n; i++)
            {
                var a = -30+60 *rand.NextDouble();
                var b = -30+60 *rand.NextDouble();
                points.Add(new point(a, b));
            }

            circle k = new circle(new point(),15);

            //a pontok kiíratása a listából
            foreach(point p in points)
            {
                Console.WriteLine(p);
            }


            int db = 0;
            for(int i =0; i<points.Count; i++)
            {
                if (k.contains(points[i])) 
                    db++;
            }

            

            Console.WriteLine($"{db} db pont található a kör lemezén");
            
            
        }
    }
}
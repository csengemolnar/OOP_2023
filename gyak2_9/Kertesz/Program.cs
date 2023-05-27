namespace Kertesz
{
     class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gardener's, World!");
            Garden garden = new(5);
            Gardener gardener = new Gardener(garden);

            int date = DateTime.Now.Month;
            gardener.Planting(1, Potato.Instance, date);
            gardener.Planting(2, Pea.Instance, date);
            gardener.Planting(4,Pea.Instance, date);

            Console.WriteLine("Betakarítható parcellák");

            foreach (var item in gardener.garden.CanHarvest(7))
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
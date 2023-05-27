namespace Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
				Customer vásárló = new Customer("Customer.txt");
				Store Üzlet = new Store("Food.txt", "Technical.txt");
				vásárló.Purchase(Üzlet);
			}
			catch (Exception)
			{

				Console.WriteLine("Hibás file"); 
			}
        }
    }
}
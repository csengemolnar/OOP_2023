namespace Nagybeadando
{
     class Program
    {
        static void Main(string[] args)
        {
            Konyvtar k1 = new Konyvtar();
            Szemely sz1 = new Szemely("Nagy Dóra");
            Konyv konyv = new Konyv("Éjjeli Árnyak","Csonka Ágnes", "9789636041403",359,false,"ifjúsági");
            k1.Belep(sz1);

            //k1.Kolcsonoz("Nagy Dóra", new string[] { "2b16c911-169c-49cd-95f0-b3a124995819" });
            //k1.Visszahoz(new string[] { "2b16c911-169c-49cd-95f0-b3a124995819" });
            //k1.Visszahoz(new string[] { "7f5ed1b9-954f-439e-9d12-5f95d331e296" });
            //k1.Beszerez(konyv);
            //k1.Kolcsonoz("Novák Lilla",new string[] { })
            
            


        }
    }
}
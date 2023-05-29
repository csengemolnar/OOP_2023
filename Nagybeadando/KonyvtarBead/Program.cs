namespace KonyvtarBead
{
     class Program
    {
        static void Main(string[] args)
        {
            Konyvtar k1 = new Konyvtar();
            //Szemely sz1 = new Szemely("Varga Mária");
            //Konyv konyv = new Konyv("Éjjeli Árnyak","Csonka Ágnes", "9789636041403",359,false,"ifjúsági");
           //k1.Belep(sz1);
            //k1.Beszerez(konyv);

            //k1.Kolcsonoz(3, new string[] { "07f4676a-00b6-475d-8a55-5b298a290530" });
            k1.Visszahoz(new string[] { "f5b713ef-7ed6-41c1-93c6-e13940134f0c" });
            //k1.Visszahoz(new string[] { "7f5ed1b9-954f-439e-9d12-5f95d331e296" });
            //k1.Beszerez(konyv);
            //k1.Kolcsonoz("Novák Lilla",new string[] { })
            
            


        }
    }
}
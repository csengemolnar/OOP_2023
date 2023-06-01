namespace KonyvtarBead
{
     class Program
    {
        static void Main(string[] args)
        {
            Konyvtar k1 = new Konyvtar();
            Szemely sz=new Szemely("Móricz Diána");
            k1.Belep(sz);
            Konyv k = new Konyv("Nagy Lajos III.", "Benko Laszlo", "9789632675756", 416, true, "szépirodalmi");
            k1.Beszerez(k);
            k1.Visszahoz(new string[] { "7f5ed1b9-954f-439e-9d12-5f95d331e296" });
            k1.Kolcsonoz(0, new string[] { "7f5ed1b9-954f-439e-9d12-5f95d331e296", "d082409d-cacf-412d-bd6c-85c18dade4fe" });
            k1.Visszahoz(new string[]{ "d082409d-cacf-412d-bd6c-85c18dade4fe" });
        }
    }
}
using KonyvtarBead;
namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod, TestCategory ("UresKonyvtar test")]
        public void UresKonyvtar()
        {
            Konyvtar k = new Konyvtar();
            Assert.IsNotNull(k);
        }

        [TestMethod, TestCategory("KonyvtarTag test")]
        public void KonyvtarTag()
        {
            
            Konyvtar k = new Konyvtar();
            int hossz = k.tagok.Count+1;
            Szemely sz = new Szemely("Kiss Panna");
            k.Belep(sz);
            int hossz2 = k.tagok.Count;

            Assert.AreEqual(hossz, hossz2);
            

        }

        [TestMethod, TestCategory("KonyvtarKonyv test")]
        public void KonyvtarKonyv()
        {

            Konyvtar k = new Konyvtar();
            int h = k.konyvek.Count + 1;
            Konyv konyv1 = new Konyv("Nagy Lajos III.", "Benko Laszlo", "9789632675756",416,true,"szépirodalmi");
            k.Beszerez(konyv1);
            int h2 = k.konyvek.Count;

            Assert.AreEqual(h, h2);

        }

        [TestMethod, TestCategory("Kolcson test")]
        public void Kolcson()
        {

            Konyvtar k = new Konyvtar();
            int khossz = k.kolcsonzesek.Count+1;
            
            k.Kolcsonoz(3, new string[] { "3f21acf7-0cf9-424e-949f-f23d4f33dfc3" });
            int khossz2 = k.kolcsonzesek.Count;

            Assert.AreEqual(khossz, khossz2);

        }

        [TestMethod, TestCategory("Visszahozas test")]
        public void Visszahozas()
        {

            Konyvtar k = new Konyvtar();

            int hossz = k.kolcsonzesek.Count-1;
            k.Visszahoz(new string[] { "f5b713ef-7ed6-41c1-93c6-e13940134f0c"});
            int hossz2 = k.kolcsonzesek.Count;
            Assert.AreEqual (hossz, hossz2);
            

        }

    }
}
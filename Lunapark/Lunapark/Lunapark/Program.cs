namespace Lunapark
{
     class Program
    {
        static void Main(string[] args)
        {
            Cellovolde c1 = new Cellovolde("fo bejarat");
            Cellovolde c2 = new Cellovolde("bazarsor");

            Ajandek a1 = new Labda(S.Instance);c1.Kiallit(a1);

            Ajandek a2 = new Plüss(S.Instance); c1.Kiallit(a2);

            Ajandek a3 = new Plüss(M.Instance); c1.Kiallit(a3);

            Ajandek a4 = new Figura(XL.Instance); c2.Kiallit(a4);

            Ajandek a5 = new Figura(M.Instance); c2.Kiallit(a5);

            Ajandek a6 = new Labda(M.Instance); c2.Kiallit(a6);


            Vendeg v1 = new("Pistike");
            Vendeg v2 = new("Jakab");
            v1.Nyer(a1);
            v1.Nyer(a2);
            v1.Nyer(a3);
            v2.Nyer(a4);
            v2.Nyer(a5);
            v2.Nyer(a6);

            Console.WriteLine($"a {c1.hely}cellovoldeben{c1.Legjobb()} a legugyesebb vendeg");
        }
    }
}
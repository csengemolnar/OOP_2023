using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OEP_Beadando1
{
     class Menu
    {
        private Complex complex1 { get; set; }
        private Complex complex2 { get; set; }

        public Menu()
        {
            this.complex1 = new Complex();
            this.complex2 = new Complex();
        }

        public void Run()
        {
            int n;
            do
            {
                Writemenu();
                try
                {
                    n = int.Parse(Console.ReadLine()!);
                }
                catch (FormatException)
                {
                    n = -1;
                }

                switch (n)
                {
                    case 1: GetElements(complex1);break;
                    case 2: GetElements(complex2);break;
                    case 3: SetElements(complex1);break;
                    case 4: SetElements(complex2);break;
                    case 5: AddElements();break;
                    case 6: SubElements();break;
                    case 7: MulElements();break;
                    case 8: DivElements();break;

                }
            } while (n!=0);
        }

        private void DivElements()
        {
            try
            {
                Console.WriteLine(complex1 / complex2);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Can't divide by zero!");
            }
            
        }

        private void MulElements()
        {

            Console.WriteLine(complex1 * complex2);
        }

        private void SubElements()
        {
            Console.WriteLine(complex1 - complex2);
        }

        private void AddElements()
        {
            Console.WriteLine(complex1 + complex2);

        }



        private void SetElements(Complex complex)
        {
            Console.WriteLine("Set the real part of the number");
            double x = double.Parse(Console.ReadLine()!);
            Console.WriteLine("Set the imaginary  part of the number");
            double y = double.Parse(Console.ReadLine()!);
            complex.setx(x);
            complex.sety(y);
            Console.WriteLine(complex);

        }

        private void GetElements(Complex complex)
        {
            Console.WriteLine(complex);


        }

        


        private void Writemenu()
        {
            Console.WriteLine("\n\n 0. - Quit");
            Console.WriteLine(" 1. - get  c1 elements ");
            Console.WriteLine(" 2. - get c2 elements");
            Console.WriteLine(" 3. - set c1 elements");
            Console.WriteLine(" 4. - set c2 elemets");
            Console.WriteLine(" 5. - add c1 and c2");
            Console.WriteLine(" 6. - sub c1 and c2");
            Console.WriteLine(" 7. - mul c1 and c2");
            Console.WriteLine(" 8. - div c1 and c2");
        }
    }
}

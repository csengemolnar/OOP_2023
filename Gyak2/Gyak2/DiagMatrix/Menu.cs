namespace DiagMatrix
{
    class Menu
    {
        readonly Diag[] matrix=new Diag[2];
        const int size = 3;
        public Menu()
        {
            matrix[0] = new Diag(size);
            matrix[1] = new Diag(size);
        }

        public void Run()
        {
            int n;
            do
            {
                MenuWrite();
                try
                {
                    n=int.Parse(Console.ReadLine()!);
                }
                catch (FormatException)
                {

                    n = -1;
                }
                switch (n)
                {
                    case 1:GetElement(0);break;
                    case 2:GetElement(1);break;
                    case 3:SetElement(0);break;
                    case 4:SetElement(1);break;
                    case 5:Writematrix(0);break;
                    case 6:Writematrix(1);break;
                    case 7:Sum();break;
                    case 8:Mul();break;
                    
                }

            } while (n!=0);
        }

        private void Mul()
        {
            try
            {
                Console.WriteLine(matrix[0] * matrix[1]);
            }
            catch (Diag.DifferentSizeException)
            {

                Console.WriteLine("matrices must be a same size");
            }
        }

        private void Sum()
        {
            try
            {
                Console.WriteLine(matrix[0] + matrix[1]);
            }
            catch (Diag.DifferentSizeException)
            {

                Console.WriteLine("matrices must be a same size");
            }
        }

        private void Writematrix(int v)
        {
            Console.WriteLine(matrix[v]);
        }

        private void SetElement(int v)
        {
            bool ok;
            do
            {
                ok = false;
                try
                {
                    Console.WriteLine("Give the index of row");
                    int i = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Give the index of column");
                    int j = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("give the value");
                    int e = int.Parse(Console.ReadLine()!);
                    matrix[v][i, j] = e;
                    ok = true;
                }
                catch (FormatException)
                {

                    Console.WriteLine($"index must be between 0 and {size - 1}");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"index must be between 0 and {size - 1}");
                }
                catch(Diag.ReferenceToNullPartException)
                {
                    Console.WriteLine("Only the elements in the diagonal may be rewritten");
                }

            } while (!ok);
        }

        private void GetElement(int v)
        {
            bool ok;
            do
            {
                ok = false;
                try
                {
                    Console.WriteLine("Give the index of row");
                    int i=int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Give the index of column");
                    int j=int.Parse(Console.ReadLine()!);
                    Console.WriteLine($"a[{i},{j}]={matrix[v][i,j]}");
                    ok=true;
                }
                catch (FormatException)
                {

                    Console.WriteLine($"index must be between 0 and {size-1}");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"index must be between 0 and {size - 1}");
                }

            } while (!ok);
        }

        private void MenuWrite()
        {
            Console.WriteLine("\n\n 0. - Quit");
            Console.WriteLine(" 1. - get an element of matrix A");
            Console.WriteLine(" 2. - get an element of matrix B");
            Console.WriteLine(" 3. - set an element of matrix A");
            Console.WriteLine(" 4. - set an element of matrix B");
            Console.WriteLine(" 5. - write matrix A");
            Console.WriteLine(" 6. - write matrix B");
            Console.WriteLine(" 7. - add matrices");
            Console.WriteLine(" 8. - multiply matrices");
        }
    }
}
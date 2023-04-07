using DiagMatrix;

namespace Diagtest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateTest()
        {
            Diag c = new Diag(3);

            Assert.AreEqual(0, c[0, 1]);
            Assert.AreEqual(0, c[1, 1]);
        }
        [TestMethod]
        public void ChangeTest()
        {
            var c = new Diag(3);
            c[0, 0] = 1;
            c[1, 1] = 2;                
            c[2, 2] = 3;

            Assert.ThrowsException<Diag.ReferenceToNullPartException>(() => c[1, 0] = 3);
            Assert.AreEqual(c[0, 0], 1);
            Assert.AreEqual(c[0, 1], 0);
        }
        [TestMethod]
        public void Addtest()
        {
            Diag a = new(3);
            Diag b = new(3);
            Diag d=new (2);
            Diag c;

            a[0,0]= 1;
            a[1,1]= 1;
            a[2,2]= 1;

            b[0,0]= 42;

            c = a + b;

            Assert.AreEqual(c[0, 0], 43);
            Assert.AreEqual(c[1, 1], 1);
            Assert.ThrowsException<Diag.DifferentSizeException>(() => a+d);
        }
    }
}
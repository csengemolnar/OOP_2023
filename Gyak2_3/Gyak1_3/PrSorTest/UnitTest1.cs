using PrSor;
namespace PrSorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestCategory ("IsEmpty test")]
        [TestMethod]
        public void IsEmpty()
        {
            PrQueue pq=new PrQueue();

            Assert.IsTrue(pq.isEmpty());
        }
        
        [TestMethod, TestCategory ("IsEmpty test")]
        public void IsNotEmpty()
        {
            PrQueue pq=new PrQueue();
            Element e = new Element { pr = 1, data = "alma" };
            pq.Add(e);
            Assert.IsFalse(pq.isEmpty());
        }

        [TestMethod]
        public void GetMaxtest1()
        {
            PrQueue q=new PrQueue();
            q.Add(new Element { pr = 1, data = "alma" });
            q.Add(new Element { pr = 1, data = "körte" });
            q.Add(new Element { pr = 1, data = "szilva" });
            Element e = new Element() { pr = 1, data = "alma" };
            Assert.AreEqual(e, q.GetMax());


        }
    }
}
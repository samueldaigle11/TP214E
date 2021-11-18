using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class UstensileTests
    {
        [TestMethod()]
        public void Ustensile_ToString_retourne_bonne_string()
        {
            Ustensile ustensile = new Ustensile("fourchette", 100);

            string chaineRetournee = ustensile.ToString();

            Assert.AreEqual(chaineRetournee, "fourchette quantité: 100");
        }
    }
}
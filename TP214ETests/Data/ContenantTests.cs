using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class ContenantTests
    {
        [TestMethod()]
        public void Contenant_test_accesseur_Id()
        {
            Contenant contenant = new Contenant("bol", 100);
            ObjectId id = ObjectId.GenerateNewId();

            contenant.Id = id;

            Assert.AreEqual(contenant.Id, id);
        }

        [TestMethod()]
        public void Contenant_ToString_retourne_bonne_string()
        {
            Contenant contenant = new Contenant("bol", 100);

            string chaineRetournee = contenant.ToString();

            Assert.AreEqual(chaineRetournee, "bol quantité: 100");
        }
    }
}
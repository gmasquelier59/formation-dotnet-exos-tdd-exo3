namespace Exo03RechercheVille.MSTest
{
    [TestClass]
    public class RechercheVilleTests
    {
        private RechercheVille _rechercheVille;

        public RechercheVilleTests()
        {
            Setup();
        }

        private void Setup()
        {
            _rechercheVille = new RechercheVille();
        }

        [TestMethod]
        public void When_SearchTextLength_LessThan2_Then_ThrowNotFoundException()
        {
            throw new NotImplementedException();
        }
    }
}
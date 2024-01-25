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
            List<string> villesTest = new List<string>() { "Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver", "Amsterdam", "Vienne", "Sydney", "New York", "Londres", "Bangkok", "Hong Kong", "Duba�", "Rome", "Istanbul" };

            _rechercheVille = new RechercheVille(villesTest);
        }

        /// <summary>
        /// Si le texte de la recherche contient moins de 2 caract�res, ***Une exception est lev�e de type NotFoundException***
        /// </summary>
        [TestMethod]
        public void When_SearchTextLength_LessThan2_Then_ThrowNotFoundException()
        {
            Assert.ThrowsException<NotFoundException>(() => _rechercheVille.Rechercher("A"));
        }

        /// Si le texte de recherche est �gal ou sup�rieur � 2 caract�res, il doit renvoyer tous les noms de ville commen�ant par le texte de recherche exact.
        [TestMethod]
        public void When_SearchTextLength_GreaterThanOrEquals2_Then_ReturnCitiesStartingWithSearchText()
        {
            List<string> resultat = _rechercheVille.Rechercher("Pa");

            CollectionAssert.AreEquivalent(new List<string>() { "Paris" }, resultat);
        }
    }
}
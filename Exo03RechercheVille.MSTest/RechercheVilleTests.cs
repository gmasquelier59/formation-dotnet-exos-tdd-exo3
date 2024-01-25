namespace Exo03RechercheVille.MSTest
{
    [TestClass]
    public class RechercheVilleTests
    {
        private RechercheVille _rechercheVille;

        private List<string> _villesTest;

        public RechercheVilleTests()
        {
            Setup();
        }

        private void Setup()
        {
            //  Villes de test pour être certain des résultats de test
            _villesTest = new List<string>() { "Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver", "Amsterdam", "Vienne", "Sydney", "New York", "Londres", "Bangkok", "Hong Kong", "Dubaï", "Rome", "Istanbul" };

            _rechercheVille = new RechercheVille(_villesTest);
        }

        /// <summary>
        /// Si le texte de la recherche contient moins de 2 caractères, ***Une exception est levée de type NotFoundException***
        /// </summary>
        [TestMethod]
        public void When_SearchTextLength_LessThan2_Then_ThrowNotFoundException()
        {
            Assert.ThrowsException<NotFoundException>(() => _rechercheVille.Rechercher("A"));
        }

        /// <summary>
        /// Si le texte de recherche est égal ou supérieur à 2 caractères, il doit renvoyer tous les noms de ville commençant par le texte de recherche exact.
        /// </summary>
        [TestMethod]
        public void When_SearchTextLength_GreaterThanOrEquals2_Then_ReturnCitiesStartingWithSearchText()
        {
            List<string> resultat = _rechercheVille.Rechercher("Pa");

            CollectionAssert.AreEquivalent(new List<string>() { "Paris" }, resultat);
        }

        /// <summary>
        /// La fonctionnalité de recherche doit être insensible à la casse
        /// </summary>
        [TestMethod]
        public void ShouldBe_CaseInsensitive()
        {
            List<string> resultat = _rechercheVille.Rechercher("va");

            CollectionAssert.AreEquivalent(new List<string>() { "Valence", "Vancouver" }, resultat);
        }

        /// <summary>
        /// La fonctionnalité de recherche devrait également fonctionner lorsque le texte de recherche n'est qu'une partie d'un nom de ville
        /// </summary>
        [TestMethod]
        public void When_SearchTextLength_GreaterThanOrEquals2_Then_ReturnCitiesContainingSearchText()
        {
            List<string> resultat = _rechercheVille.Rechercher("ape");

            CollectionAssert.AreEquivalent(new List<string>() { "Budapest" }, resultat);
        }

        /// <summary>
        /// Si le texte de recherche est un « * » (astérisque), il doit renvoyer tous les noms de ville.
        /// </summary>
        [TestMethod]
        public void When_SearchText_IsStar_Then_ReturnAllCities()
        {
            List<string> resultat = _rechercheVille.Rechercher("*");

            CollectionAssert.AreEquivalent(_villesTest, resultat);
        }

        /// <summary>
        /// Si le texte de recherche est un « * » (astérisque), il doit renvoyer tous les noms de ville.
        /// </summary>
        [TestMethod]
        public void When_NotCitiesFound_Then_ThrowNotFoundException()
        {
            Assert.ThrowsException<NotFoundException>(() => _rechercheVille.Rechercher("dertcfgvybuhjnik"));
        }
    }
}
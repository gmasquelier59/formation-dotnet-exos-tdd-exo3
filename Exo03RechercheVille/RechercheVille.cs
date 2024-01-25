using static System.Formats.Asn1.AsnWriter;

namespace Exo03RechercheVille
{
    public class RechercheVille
    {
        private List<String> _villes;

        public RechercheVille(List<string> villes)
        {
            _villes = villes;
        }

        public List<String> Rechercher(String mot)
        {
            if (mot == "*")
                return _villes;

            if (mot.Length < 2)
                throw new NotFoundException();

            List<string> resultat = _villes.FindAll(s => s.ToLower().Contains(mot.ToLower())).ToList();

            if (resultat.Count == 0)
                throw new NotFoundException();

            return resultat;
        }
    }
}

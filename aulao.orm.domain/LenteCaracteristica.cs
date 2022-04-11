namespace aulao.orm.domain
{
    public class LenteCaracteristica : Entity
    {
        public LenteCaracteristica(string caracteristica)
        {
            Caracteristica = caracteristica;
        }
        public string Caracteristica { get; set; }
    }
}

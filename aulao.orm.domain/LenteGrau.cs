namespace aulao.orm.domain
{
    public class LenteGrau : Entity
    {
        public LenteGrau(string esquerdo,string direito)
        {
            Esquerdo = esquerdo;
            Direito = direito;
        }
        public string Esquerdo { get; set; }
        public string Direito { get; set; }
    }
}

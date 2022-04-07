namespace aulao.orm.domain
{
    public class Armacao : Entity
    {
        public string Marca { get; set; }
        public TipoMaterial Material { get; set; }
        public Cor Cor { get; set; }
    }
}

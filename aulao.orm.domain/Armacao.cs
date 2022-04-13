namespace aulao.orm.domain
{
    public class Armacao : Entity
    {
        public Armacao()
        {

        }

        public Armacao(string marca, TipoMaterial material, Cor cor)
        {
            Marca = marca;
            Material = material;
            Cor = cor;
        }
        public string Marca { get; set; }
        public TipoMaterial Material { get; set; }
        public Cor Cor { get; set; }
    }
}

namespace aulao.orm.domain
{
    public class Oculos : Entity
    {
        public Lente Lente { get; set; }
        public Armacao Armacao { get; set; }
    }
}

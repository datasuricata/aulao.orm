namespace aulao.orm.domain
{
    public class Cor : Entity
    {
        public Cor()
        {
        }

        public Cor(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
    }
}

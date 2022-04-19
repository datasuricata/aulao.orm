namespace aulao.orm.service.Notificacoes
{


    public class Notificacao
    {
        public Notificacao()
        {

        }
        public Notificacao(string property, string mensagem)
        {
            Property = property;
            Mensagem = mensagem;
        }

        public string Property { get; set; }
        public string Mensagem { get; set; }
    }
}

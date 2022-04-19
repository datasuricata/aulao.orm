using System.Collections.Generic;
using System.Linq;

namespace aulao.orm.service.Notificacoes
{
    public class Notificador
    {
        public List<Notificacao> Notificacoes { get; set; }
        public bool Validado => !Notificacoes.Any();

        public Notificador()
        {
            Notificacoes = new List<Notificacao>();
        }
    }
}

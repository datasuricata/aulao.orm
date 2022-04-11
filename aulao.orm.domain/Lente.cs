using System.Collections.Generic;

namespace aulao.orm.domain
{
    public class Lente : Entity
    {
        public Lente()
        {
            

        }
        public string Nome { get; set; }
        public LenteGrau Grau { get; set; }
        public List<LenteCaracteristica> Caracteristicas { get; set; }
    }
}

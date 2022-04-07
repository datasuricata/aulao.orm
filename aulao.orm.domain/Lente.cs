using System.Collections.Generic;

namespace aulao.orm.domain
{
    public class Lente : Entity
    {
        public LenteGrau Grau { get; set; }
        public List<LenteCaracteristica> Caracteristicas { get; set; }
    }
}

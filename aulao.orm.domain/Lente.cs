using System.Collections.Generic;

namespace aulao.orm.domain
{
    public class Lente
    {
        public LenteGrau Grau { get; set; }
        public List<LenteCaracteristica> Caracteristicas { get; set; }
    }
}

using aulao.orm.domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace aulao.orm.infra
{
    public class AppDbContext : DbContext
    {
        //dados de conexao e tipo de servidor
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        //nossas tabelas
        //todas tem uma PK (Primary Key)
        public DbSet<Armacao> Armacao { get; set; }
        public DbSet<Cor> Cor { get; set; }
        public DbSet<Lente> Lente { get; set; }
        public DbSet<LenteCaracteristica> LenteCaracteristica { get; set; }
        public DbSet<LenteGrau> LenteGrau { get; set; }
        public DbSet<Oculos> Oculos { get; set; }
    }
}
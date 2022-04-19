using System;
using System.Collections.Generic;
using System.Text;
using aulao.orm.domain;
using FluentValidation;

namespace aulao.orm.service.Validacoes
{
    public class LenteValidator : AbstractValidator<Lente>
    {
        public LenteValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().NotNull();
            RuleFor(x => x.Grau).NotEmpty().NotNull();
            RuleFor(x => x.Caracteristicas).NotEmpty().NotNull();
        }

    }
}

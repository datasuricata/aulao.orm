using aulao.orm.domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace aulao.orm.service.Validacoes
{
    public class LenteCaracteristicaValidator : AbstractValidator<LenteCaracteristica>
    {
        public LenteCaracteristicaValidator()
        {
            RuleFor(x => x.Caracteristica).NotEmpty().NotNull();
        }

    }
}

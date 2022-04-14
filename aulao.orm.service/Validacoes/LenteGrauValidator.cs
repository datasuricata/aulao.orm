using aulao.orm.domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace aulao.orm.service.Validacoes
{
    public class LenteGrauValidator : AbstractValidator<LenteGrau>
    {
        public LenteGrauValidator()
        {
            RuleFor(x => x.Esquerdo).NotEmpty().NotNull();
            RuleFor(x => x.Direito).NotEmpty().NotNull();
        }
    }
}

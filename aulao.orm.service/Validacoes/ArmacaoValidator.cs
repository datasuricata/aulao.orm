using aulao.orm.domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace aulao.orm.service.Validacoes
{
    public class ArmacaoValidator : AbstractValidator<Armacao>
    {
        public ArmacaoValidator()
        {
            RuleFor(x => x.Cor).NotEmpty().NotNull();
            RuleFor(x => x.Material).NotEmpty().NotNull();
            RuleFor(x => x.Marca).NotEmpty().NotNull();
        }
    }
}

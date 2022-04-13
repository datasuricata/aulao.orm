using aulao.orm.domain;
using FluentValidation;


namespace aulao.orm.service.Validacoes
{
    public class CorValidator : AbstractValidator<Cor>
    {
        public CorValidator()
        {
            RuleFor(propriedade => propriedade.Nome).NotNull().NotEmpty();
        }
    }
}

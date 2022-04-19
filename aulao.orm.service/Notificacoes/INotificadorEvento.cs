using FluentValidation;
using System.Collections.Generic;

namespace aulao.orm.service.Notificacoes
{
    public interface INotificadorEvento
    {
        bool Validado { get; }
        IEnumerable<Notificacao> Notificacoes { get; }
        void Validar<T>(T entity, AbstractValidator<T> validador);
    }
}

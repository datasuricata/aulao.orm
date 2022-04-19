using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aulao.orm.service.Notificacoes
{
    public class NotificadorEvento : INotificadorEvento, IDisposable
    {
        private Notificador _notificador = new Notificador();
        private bool disposed = false;

        public bool Validado => _notificador.Validado;

        public IEnumerable<Notificacao> Notificacoes => _notificador.Notificacoes;

        public void Validar<T>(T entity, AbstractValidator<T> validador)
        {
            if (entity is null)
            {
                _notificador.Notificacoes.Add(new Notificacao("objeto", "objeto não encontrado"));
                return;
            }

            validador.Validate(entity)
                .Errors?
                .Where(erro => erro != null)
                .ToList()
                .ForEach(erro =>
                {
                    _notificador.Notificacoes.Add(new Notificacao(erro.PropertyName, erro.ErrorMessage));
                });
        }

        private void ClearNotifications(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _notificador.Notificacoes.Clear();
                }
            }
        }

        /// <summary>
        /// to clear GBC
        /// </summary>
        public void Dispose()
        {
            ClearNotifications(true);

            GC.SuppressFinalize(this);
        }
    }
}

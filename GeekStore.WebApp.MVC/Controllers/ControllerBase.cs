using System;
using System.Collections.Generic;
using System.Linq;
using GeekStore.Core.Communication.Mediator;
using GeekStore.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GeekStore.WebApp.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private readonly DomainNotificationHandler _domainNotificationHandler;
        private readonly IMediatorHandler _mediatorHandler;

        protected ControllerBase(INotificationHandler<DomainNotification> domainNotificationHandler, 
                                 IMediatorHandler mediatorHandler)
        {
            _domainNotificationHandler = (DomainNotificationHandler) domainNotificationHandler;
            _mediatorHandler = mediatorHandler;
        }

        protected bool OperacaoValida()
        {
            return (!_domainNotificationHandler.TemNotificacao());
        }

        protected IEnumerable<string> ObterMensagensErro()
        {
            return _domainNotificationHandler.ObterNotificacoes().Select(c => c.Value).ToList();
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediatorHandler.PublishNotification(new DomainNotification(codigo, mensagem));
        }

        protected Guid ClienteId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");
    }
}
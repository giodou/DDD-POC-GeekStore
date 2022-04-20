using System.Threading.Tasks;
using GeekStore.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GeekStore.WebApp.MVC.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly DomainNotificationHandler _domainNotification;

        public SummaryViewComponent(INotificationHandler<DomainNotification> domainNotification)
        {
            _domainNotification = (DomainNotificationHandler)domainNotification;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult((_domainNotification.ObterNotificacoes()));
            notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Value));

            return View();
        }
    }
}
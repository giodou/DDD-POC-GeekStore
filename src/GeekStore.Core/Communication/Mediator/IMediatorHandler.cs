using System.Threading.Tasks;
using GeekStore.Core.Messages;
using GeekStore.Core.Messages.CommonMessages.Notifications;

namespace GeekStore.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T evento) where T: Event;
        Task<bool> SendCommand<T>(T command) where T : Command;
        Task PublishNotification<T>(T notification) where T : DomainNotification;
    }
}
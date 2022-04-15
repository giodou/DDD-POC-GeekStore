using System.Threading.Tasks;
using GeekStore.Core.Messages;

namespace GeekStore.Core.Bus
{
    public interface IMediatrHandler
    {
        Task PublishEvent<T>(T evento) where T: Event;
    }
}
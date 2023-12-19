using System.Threading.Tasks;

namespace Flower_app.Web.SignalR
{
    public interface IPublishDomainEvents
    {
        Task Publish(object evnt);
    }
}

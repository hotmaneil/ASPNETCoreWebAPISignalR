using ASPNETCoreWebAPISignalR.Model;

namespace ASPNETCoreWebAPISignalR.Hubs
{
    public interface IContactHub
    {
        Task SendData(Device data);
    }
}

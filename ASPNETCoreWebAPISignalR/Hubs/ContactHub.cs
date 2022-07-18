using ASPNETCoreWebAPISignalR.Model;
using Microsoft.AspNetCore.SignalR;

namespace ASPNETCoreWebAPISignalR.Hubs
{
    public class ContactHub: Hub<IContactHub>
    {
        public async Task SendData(Device data)
        {
            await Clients.All.SendData(data);
        }
    }
}

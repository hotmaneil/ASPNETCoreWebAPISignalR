using ASPNETCoreWebAPISignalR.Model;

namespace ASPNETCoreWebAPISignalR.ServiceInterface
{
    public interface IDeviceManager
    {
        Device GetDeviceById(string Id);
    }
}

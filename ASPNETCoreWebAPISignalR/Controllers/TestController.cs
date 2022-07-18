using ASPNETCoreWebAPISignalR.Hubs;
using ASPNETCoreWebAPISignalR.Model;
using ASPNETCoreWebAPISignalR.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ASPNETCoreWebAPISignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IHubContext<ContactHub, IContactHub> _hubContext;
        private readonly IDeviceManager _deviceManager;

        public TestController(
            IHubContext<ContactHub, IContactHub> hubContext,
            IDeviceManager deviceManager)
        {
            _hubContext = hubContext;
            _deviceManager = deviceManager;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetData(string id)
        {
            try
            {
                Device data = _deviceManager.GetDeviceById(id);
                await _hubContext.Clients.All.SendData(data);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

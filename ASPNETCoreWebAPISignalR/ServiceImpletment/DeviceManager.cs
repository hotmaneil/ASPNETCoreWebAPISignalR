using ASPNETCoreWebAPISignalR.Model;
using ASPNETCoreWebAPISignalR.ServiceInterface;
using Dapper;
using MySql.Data.MySqlClient;

namespace ASPNETCoreWebAPISignalR.ServiceImpletment
{
    public class DeviceManager: IDeviceManager
    {
        internal readonly string ConnectionString;

        public DeviceManager(IConfiguration configuration)
        {
            ConnectionString = configuration.GetSection("ConnectionStrings")["MySQL"];
        }

        public Device GetDeviceById(string Id)
        {
            Device data = new Device();
            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    string sql = "select * from device_info where 1=1";
                    if (!string.IsNullOrEmpty(Id))
                        sql += string.Format(" and id='{0}'", Id);

                    var query = connection.Query<Device>(sql);
                    if (query.Any())
                        data = query.First();
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

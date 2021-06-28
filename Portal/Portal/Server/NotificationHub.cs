using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Portal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portal.Server
{
    [Authorize]
    public class NotificationHub : Hub
    {
        static Dictionary<string, string> hubClients = new Dictionary<string, string>();
        private string AddOrUpdateClient(string key, string value)
        {
            bool IsConnected = false;
            string result = "Exeption!";
            foreach (KeyValuePair<string, string> keyValue in hubClients)
            {
                if (keyValue.Key.Equals(key))
                {
                    IsConnected = true;
                    hubClients[keyValue.Key] = value;
                    result = "ConnectionString was update!";
                }
            }
            if (!IsConnected)
            {
                hubClients.Add(key, value);
                result = "New Connection!";
            }

            return result;
        }
        public override Task OnConnectedAsync()
        {
            var clientLogin = Context.User.Identity.Name;
            var connectionId = Context.ConnectionId;
            var result = AddOrUpdateClient(clientLogin, connectionId);

            return Clients.Client(connectionId).SendAsync("WasConnected", result);
        }
        public static string FindConnectionString(string userName)
        {
            foreach (KeyValuePair<string, string> keyValue in hubClients)
                if (keyValue.Key.Equals(userName))
                    return keyValue.Value;
            return "";
        }
    }
}

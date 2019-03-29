using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Http;

namespace DemoApp.Handlers
{
    public abstract class WebSocketHandler : System.Collections.Concurrent.ConcurrentDictionary<WebSocket, object>
    {
        protected abstract Task OnReceiveTextAsync(string text, WebSocket sender);

        protected async Task SendTextAsync(object source, WebSocket receiver = null)
        {
            var buffer = Encoding.UTF8.GetBytes(source.ToString());
            var message = new ArraySegment<byte>(buffer);
            if(receiver == null)
            {
                foreach(var remote in Keys)
                    await remote.SendAsync(message, WebSocketMessageType.Text, true, CancellationToken.None);
            }
            else
                await receiver.SendAsync(message, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        public async Task Communicate(HttpContext context)
        {
            if(context.WebSockets.IsWebSocketRequest)
            {
                var client = await context.WebSockets.AcceptWebSocketAsync();
                TryAdd(client, null);
                byte[] buffer = new byte[4096];
                WebSocketReceiveResult result;
                for(;;)
                {
                    result = await client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    if(result.CloseStatus.HasValue) break;
                    string text = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    await OnReceiveTextAsync(text, client);
                }
                TryRemove(client, out _);
                await client.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
            }
            else
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}


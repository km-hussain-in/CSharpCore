using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebSocketsTest
{
    public class Startup
    {

        public void Configure(IApplicationBuilder app)
        {

            app.UseWebSockets();

            /*
            var webSocketOptions = new WebSocketOptions()
            {
                KeepAliveInterval = TimeSpan.FromMinutes(2),
                ReceiveBufferSize = 4096
            }
            app.UseWebSockets(webSocketOptions);
            */

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/reverse")
                {
                    if (context.WebSockets.IsWebSocketRequest)
                    {
                        WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                        await Reverse(context, webSocket);
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                    }
                }
                else
                {
                    await next();
                }

            });
            app.UseFileServer();
        }

        private async Task Reverse(HttpContext context, WebSocket webSocket)
        {
            byte[] buffer = new byte[80];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {
                for(int i = 0, j = result.Count - 1; i < j; ++i, j--)
                {
                    byte ib = buffer[i];
                    byte jb = buffer[j];
                    buffer[i] = jb;
                    buffer[j] = ib;
                }

                await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
    }
}

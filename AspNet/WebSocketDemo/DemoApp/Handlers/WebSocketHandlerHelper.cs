using Microsoft.AspNetCore.Builder;

namespace DemoApp.Handlers
{
    public static class WebSocketHandlerHelper
    {
        public static IApplicationBuilder MapWebSocketHandler(this IApplicationBuilder builder, string path, WebSocketHandler handler)
        {
            return builder.Map(path, action => builder.Run(handler.Communicate));
        }
    }

}
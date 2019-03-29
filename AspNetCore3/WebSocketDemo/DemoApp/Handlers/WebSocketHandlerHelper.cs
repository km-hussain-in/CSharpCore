using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;

namespace DemoApp.Handlers
{
    public static class WebSocketHandlerHelper
    {
        public static IEndpointConventionBuilder MapWebSocketHandler(this IEndpointRouteBuilder builder, string path, WebSocketHandler handler)
        {
            return builder.MapGet(path, handler.Communicate);
        }
    }

}

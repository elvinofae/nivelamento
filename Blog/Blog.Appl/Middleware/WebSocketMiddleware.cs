using Blog.Appl.Service;
using Microsoft.AspNetCore.Http;
using System.Net.WebSockets;

namespace Blog.Appl.Middleware
{
    public class WebSocketMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly NotificationService _notificationService;

        public WebSocketMiddleware(RequestDelegate next, NotificationService notificationService)
        {
            _next = next;
            _notificationService = notificationService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/ws" && context.WebSockets.IsWebSocketRequest)
            {
                WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                await _notificationService.HandleWebSocket(webSocket); 
                return;
            }

            await _next(context);
        }
    }
}

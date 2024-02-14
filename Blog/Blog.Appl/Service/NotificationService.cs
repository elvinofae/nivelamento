using Blog.Appl.Interfaces.Services;
using System.Net.WebSockets;
using System.Text;

namespace Blog.Appl.Service
{
    public class NotificationService
    {
        private readonly IPostService _post;

        public NotificationService(IPostService post)
        {
            _post = post;
        }

        public async Task HandleWebSocket(WebSocket webSocket)
        {
            while (webSocket.State == WebSocketState.Open)
            {
                var newPost = await _post.GetDateTodayAsync();

                if (newPost != null)
                {
                    var notificationMessage = $"Nova postagem publicada: {newPost}";
                    var notificationBuffer = Encoding.UTF8.GetBytes(notificationMessage);
                    await webSocket.SendAsync(new ArraySegment<byte>(notificationBuffer),
                                              WebSocketMessageType.Text, true, CancellationToken.None);
                }

                await Task.Delay(TimeSpan.FromMinutes(30));
            }
        }
    }
}

using System.Net.WebSockets;
using ITControl.Application.Notifications.Interfaces;
using ITControl.Application.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Notification.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
public class WebSocketController(
    IWebSocketService webSocketService,
    INotificationsService notificationsService) : ControllerBase
{
    [Route("/ws")]
    public async Task Get()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            await Echo(webSocket);
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
    
    private async Task Echo(WebSocket webSocket)
    {
        var buffer = new byte[1024 * 4];
        var receiveResult = await webSocket.ReceiveAsync(
            new ArraySegment<byte>(buffer), CancellationToken.None);

        while (!receiveResult.CloseStatus.HasValue)
        {
            byte[] bytes = [];
            string message = System.Text.Encoding.UTF8.GetString(buffer, 0, receiveResult.Count);
            if (message != "")
            {
                if (!webSocketService.ContainsKey(message)) 
                    webSocketService.AddWebSocket(message, webSocket);
                var count = await notificationsService.CountUnreadAsync(Guid.Parse(message));
                bytes = System.Text.Encoding.UTF8.GetBytes(count.ToString());
            }
            await webSocket.SendAsync(
                new ArraySegment<byte>(bytes, 0, bytes.Length),
                receiveResult.MessageType,
                receiveResult.EndOfMessage,
                CancellationToken.None);

            receiveResult = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);
        }

        await webSocket.CloseAsync(
            receiveResult.CloseStatus.Value,
            receiveResult.CloseStatusDescription,
            CancellationToken.None);
    }
}
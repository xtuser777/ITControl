using ITControl.Application.Interfaces;
using System.Net.WebSockets;

namespace ITControl.Application.Services;

public class WebSocketService : IWebSocketService
{
    private readonly Dictionary<string, WebSocket> _webSocketDict = [];

    public void AddWebSocket(string id, WebSocket webSocket)
    {
        _webSocketDict.Add(id.ToLower(), webSocket);
    }

    public async Task EchoAsync(string id, string message)
    {
        if (_webSocketDict.Count == 0)
        {
            throw new InvalidOperationException("WebSocket is not set.");
        }
        await _webSocketDict[id].SendAsync(
            new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes(message)),
            WebSocketMessageType.Text,
            true,
            CancellationToken.None);
    }

    public bool ContainsKey(string id) => _webSocketDict.ContainsKey(id.ToLower());
}

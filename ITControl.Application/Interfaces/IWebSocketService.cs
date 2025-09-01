using System.Net.WebSockets;

namespace ITControl.Application.Interfaces;

public interface IWebSocketService
{
    void AddWebSocket(string id, WebSocket webSocket);
    Task EchoAsync(string id, string message);
    bool ContainsKey(string id);
}

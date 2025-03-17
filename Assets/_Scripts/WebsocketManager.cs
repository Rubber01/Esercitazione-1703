using NativeWebSocket;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class WebsocketManager : Singleton<WebsocketManager>
{
    internal WebSocket ws;

    [SerializeField]
    private string url = "ws://localhost:8080";

    internal Action<string> onMessageReceived;

    // Start is called before the first frame update
    async void Start()
    {
        await StartConnection();
    }

    private void Update()
    {
#if UNITY_EDITOR
        ws.DispatchMessageQueue();
#endif
    }

    async Task StartConnection()
    {
        ws = new WebSocket(url);

        ws.OnOpen += () =>
        {
            Debug.Log("Connection open!");
        };

        ws.OnMessage += (bytes) =>
        {
            Debug.Log("Message Received");
            var msg = System.Text.Encoding.UTF8.GetString(bytes);
            Debug.Log($"Received: {msg}");
            OnMessageReceived(msg);
        };

        ws.OnError += (e) =>
        {
            Debug.LogError($"Error {e}");
        };

        ws.OnClose += (e) =>
        {
            Debug.Log("Connection closed");
        };

        await ws.Connect();
    }

    public async void SendRequest(string text)
    {
        if (ws.State == WebSocketState.Open)
        {
            await ws.SendText(text);
        }
    }

    void OnMessageReceived(string msg)
    {
        onMessageReceived.Invoke(msg);
    }
}
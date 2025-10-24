using System.Net.Sockets;
using System.Text;

namespace UdpServerDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int port = 11000;
            using var udpServer = new UdpClient(port);

            Console.WriteLine($"✅ UDP Server started on port {port}...");
            Console.WriteLine("Waiting for messages...\n");

            while (true)
            {
                try
                {

                    UdpReceiveResult received = await udpServer.ReceiveAsync();
                    string message = Encoding.UTF8.GetString(received.Buffer);

                    Console.WriteLine($"📩 Received from {received.RemoteEndPoint}: {message}");

                    string response = $"Server received your message at {DateTime.Now}";
                    byte[] responseData = Encoding.UTF8.GetBytes(response);
                    await udpServer.SendAsync(responseData, responseData.Length, received.RemoteEndPoint);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error: {ex.Message}");
                }
            }
        }
    }
}

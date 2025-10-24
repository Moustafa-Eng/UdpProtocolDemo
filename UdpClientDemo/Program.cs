using System.Net.Sockets;
using System.Text;

namespace UdpClientDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var client = new UdpClient();

            string message = "Hello from client!";
            byte[] data = Encoding.UTF8.GetBytes(message);

            await client.SendAsync(data, data.Length, "127.0.0.1", 11000);
            Console.WriteLine("📤 Message sent!");

            var result = await client.ReceiveAsync();
            Console.WriteLine($"📩 Response: {Encoding.UTF8.GetString(result.Buffer)}");

            Console.ReadKey();
        }
    }
}

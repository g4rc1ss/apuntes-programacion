using System.Net;
using System.Net.Sockets;

namespace Sockets.ConexionSocket;

public class ConsultarPuertosAbiertos
{
    public static void EscanerPuertos()
    {
        int port = 80;

        try
        {
            using Socket? socket = new(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
            );
            IPHostEntry? host = Dns.GetHostEntry("google.es");
            string? ip = host.AddressList[0]?.ToString();
            if (ip == null)
            {
                return;
            }

            socket.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
            Console.WriteLine($"[+] puerto {port} abierto");
        }
        catch (Exception)
        {
            Console.WriteLine($"[-] puerto {port} cerrado");
        }
    }
}

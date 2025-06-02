using System.Net;
using System.Net.Mail;

namespace SimpleMailTransferProtocol.Email;

public class EnviarEmail
{
    public void EnvioMail()
    {
        string? servidorDeEnvio = "smtp.gmail.com";

        //Enviamos el mensaje
        Console.WriteLine("Usuario");
        string? emisor = Console.ReadLine();

        Console.WriteLine("Constraseña");
        string? contraseña = Console.ReadLine();

        Console.WriteLine("A quien quieres mandar el mensaje?");
        string? receptor = Console.ReadLine();

        Console.WriteLine("Asunto");
        string? asunto = Console.ReadLine();

        Console.WriteLine("Cuerpo");
        string? cuerpo = Console.ReadLine();

        MailMessage? mensaje = new(emisor, receptor, asunto, cuerpo);

        using (SmtpClient? cliente = new(servidorDeEnvio))
        {
            cliente.EnableSsl = true;
            cliente.Credentials = new NetworkCredential(emisor, contraseña);
            cliente.Send(mensaje);
        }
        Console.WriteLine();
    }
}

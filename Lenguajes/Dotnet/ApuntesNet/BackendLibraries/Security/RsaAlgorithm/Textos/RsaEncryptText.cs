using System.Security.Cryptography;
using System.Text;

namespace RsaAlgorithm.Textos;

public class RsaEncryptText
{
    public void CifrarRsa()
    {
        try
        {
            Console.WriteLine("Escribe el texto a cifrar");
            //Obtenemos un array de bytes del texto a cifrar
            byte[]? textoCifrarBytes = Encoding.UTF8.GetBytes(Console.ReadLine());

            // Instanciamos el algorimo asimétrico RSA
            using RSA? rsaCrypt = RSA.Create();
            // Establecemos la longitud de la clave que queremos usar
            rsaCrypt.KeySize = 4096;
            File.WriteAllBytes("public.key", rsaCrypt.ExportRSAPublicKey());
            File.WriteAllBytes("private.key", rsaCrypt.ExportRSAPrivateKey());

            byte[]? mensajeCifrado = rsaCrypt.Encrypt(textoCifrarBytes, RSAEncryptionPadding.Pkcs1);

            Console.WriteLine("----------------------------------- \n Mensaje encriptado:");
            Console.WriteLine(Encoding.UTF8.GetString(mensajeCifrado));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

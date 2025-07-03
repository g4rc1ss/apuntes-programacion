using System.Security.Cryptography;
using System.Text;

namespace RsaAlgorithm.Archivos;

public class RsaEncryptFile
{
    private readonly string _archivoRsaTxt = "archivoRSA.txt";
    private readonly string _archivoRsaCrypt = "archivoRSA.crypt";

    public void CifrarRsa()
    {
        try
        {
            if (!File.Exists(_archivoRsaTxt))
            {
                using StreamWriter? archivoEscrituraRsa = File.CreateText(_archivoRsaTxt);
                archivoEscrituraRsa.Write(
                    "Esto es una prueba de escritura en un archivo de "
                        + "texto. \n"
                        + "Siguiente Linea jajajaja"
                );
                archivoEscrituraRsa.Close(); //guardamos y cerramos el archivo
            }

            //Obtenemos un array de bytes del texto a cifrar
            byte[]? textoCifrarBytes = File.ReadAllBytes(_archivoRsaTxt);

            // Instanciamos el algorimo asimétrico RSA
            using RSA? rsaCrypt = RSA.Create();
            // Establecemos la longitud de la clave que queremos usar
            rsaCrypt.KeySize = 4096;
            File.WriteAllBytes("public.key", rsaCrypt.ExportRSAPublicKey());
            File.WriteAllBytes("private.key", rsaCrypt.ExportRSAPrivateKey());

            byte[]? mensajeCifrado = rsaCrypt.Encrypt(textoCifrarBytes, RSAEncryptionPadding.Pkcs1);

            // Escribir en un fichero el mensaje cifrado
            File.WriteAllBytes(_archivoRsaCrypt, mensajeCifrado);
            File.Delete(_archivoRsaTxt);

            Console.WriteLine("----------------------------------- \n Mensaje encriptado:");
            Console.WriteLine(Encoding.UTF8.GetString(File.ReadAllBytes(_archivoRsaCrypt)));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

using System.Security.Cryptography;
using System.Text;

namespace RsaAlgorithm.Archivos;

public class RsaEncryptFile
{
    private readonly string _archivoRSA_TXT = "archivoRSA.txt";
    private readonly string _archivoRSA_CRYPT = "archivoRSA.crypt";

    public void CifrarRSA()
    {
        try
        {
            if (!File.Exists(_archivoRSA_TXT))
            {
                StreamWriter? archivoEscrituraRSA = File.CreateText(_archivoRSA_TXT);
                archivoEscrituraRSA.Write(
                    "Esto es una prueba de escritura en un archivo de "
                        + "texto. \n"
                        + "Siguiente Linea jajajaja"
                );
                archivoEscrituraRSA.Close(); //guardamos y cerramos el archivo
            }

            //Obtenemos un array de bytes del texto a cifrar
            byte[]? textoCifrarBytes = File.ReadAllBytes(_archivoRSA_TXT);

            // Instanciamos el algorimo asimétrico RSA
            using RSA? rsaCrypt = RSA.Create();
            // Establecemos la longitud de la clave que queremos usar
            rsaCrypt.KeySize = 4096;
            File.WriteAllBytes("public.key", rsaCrypt.ExportRSAPublicKey());
            File.WriteAllBytes("private.key", rsaCrypt.ExportRSAPrivateKey());

            byte[]? mensajeCifrado = rsaCrypt.Encrypt(textoCifrarBytes, RSAEncryptionPadding.Pkcs1);

            // Escribir en un fichero el mensaje cifrado
            File.WriteAllBytes(_archivoRSA_CRYPT, mensajeCifrado);
            File.Delete(_archivoRSA_TXT);

            Console.WriteLine("----------------------------------- \n Mensaje encriptado:");
            Console.WriteLine(Encoding.UTF8.GetString(File.ReadAllBytes(_archivoRSA_CRYPT)));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

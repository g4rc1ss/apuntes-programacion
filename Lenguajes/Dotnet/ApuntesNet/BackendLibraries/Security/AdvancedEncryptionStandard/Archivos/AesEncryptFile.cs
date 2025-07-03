using System.Security.Cryptography;
using System.Text;

namespace AdvancedEncryptionStandard.Archivos;

public class AesEncryptFile
{
    private readonly string _archivoAesTxt = "archivo.txt";
    private readonly string _archivoAesTxtCifrado = "archivo.txt.crypt";

    public void CifrarAes()
    {
        try
        {
            if (!File.Exists(_archivoAesTxt))
            {
                using StreamWriter? archivoEscritura = File.CreateText(_archivoAesTxt);
                archivoEscritura.Write(
                    "Esto es una prueba de escritura en un archivo de "
                        + "texto. \n"
                        + "Siguiente Linea jajajaja"
                );
                archivoEscritura.Close(); //guardamos y cerramos el archivo
            }

            Console.WriteLine("Escribe la contraseña");
            string? contraseña = Console.ReadLine();

            using (HashAlgorithm hash = SHA256.Create())
            {
                using Aes? aesAlg = Aes.Create();
                aesAlg.Key = hash.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

                using ICryptoTransform? encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using FileStream? fileStreamOutput = new(
                    _archivoAesTxtCifrado,
                    FileMode.OpenOrCreate,
                    FileAccess.Write
                );
                using CryptoStream? cryptStream = new(
                    fileStreamOutput,
                    encryptor,
                    CryptoStreamMode.Write
                );
                using FileStream? fileStreamInput = new(
                    _archivoAesTxt,
                    FileMode.Open,
                    FileAccess.Read
                );
                for (int data; (data = fileStreamInput.ReadByte()) != -1; )
                {
                    cryptStream.WriteByte((byte)data);
                }
            }

            File.Delete(_archivoAesTxt);
            Console.WriteLine(File.ReadAllText(_archivoAesTxtCifrado));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }
}

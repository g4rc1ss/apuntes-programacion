using MySql.Data.MySqlClient;

namespace MySqlDatabase.MySQL;

internal class InsertMysql
{
    public InsertMysql(string connectionString)
    {
        using MySqlConnection? connection = new(connectionString);
        try
        {
            connection.Open();
            string? insert =
                "INSERT INTO Empleado (Nombre, Apellidos, Salario) VALUES ('nombre','apellido', 20000.00)";

            using MySqlCommand? comandoInsert = new(insert, connection);
            int numeroCambios = comandoInsert.ExecuteNonQuery();
            Console.WriteLine($"Rows cambiadas: {numeroCambios}");
        }
        finally
        {
            connection.Close();
        }
    }
}

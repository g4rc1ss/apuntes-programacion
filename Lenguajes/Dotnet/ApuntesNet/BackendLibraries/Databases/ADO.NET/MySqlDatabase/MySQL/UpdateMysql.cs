using MySql.Data.MySqlClient;

namespace MySqlDatabase.MySQL;

internal class UpdateMysql
{
    public UpdateMysql(string connectionString)
    {
        using MySqlConnection? connection = new(connectionString);
        try
        {
            connection.Open();
            string? update = "UPDATE Empleado set Salario = 4500.00 where ID = 1";

            using MySqlCommand? comandoUpdate = new(update, connection);
            int numeroCambios = comandoUpdate.ExecuteNonQuery();
            Console.WriteLine($"Rows cambiadas: {numeroCambios}");
        }
        finally
        {
            connection.Close();
        }
    }
}

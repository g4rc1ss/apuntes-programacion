using MySql.Data.MySqlClient;

namespace MySqlDatabase.MySQL;

internal class DeleteMysql
{
    public DeleteMysql(string connectionString)
    {
        using MySqlConnection? connection = new(connectionString);
        try
        {
            connection.Open();
            string? delete = "DELETE FROM `AdoNetMySqlDatabase`.`Empleado` WHERE (`ID` = '2')";
            using MySqlCommand? comandoDelete = new(delete, connection);
            int numeroCambios = comandoDelete.ExecuteNonQuery();
            Console.WriteLine($"Rows cambiadas: {numeroCambios}");
        }
        finally
        {
            connection.Close();
        }
    }
}

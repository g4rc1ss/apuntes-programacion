using System.Data;
using System.Data.Common;

namespace DbConnectionExtensions.Extensions;

public static class ExecuteCommandExtension
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="connection"></param>
    /// <param name="sql"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public static int ExecuteCommand<T>(
        this DbConnection connection,
        string sql,
        IEnumerable<DbParameter> parameters
    )
    {
        return connection.ExecuteCommandAsync(sql, parameters).GetAwaiter().GetResult();
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="connection"></param>
    /// <param name="sql"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public static Task<int> ExecuteCommandAsync(
        this DbConnection connection,
        string sql,
        IEnumerable<DbParameter> parameters
    )
    {
        return ExecuteNonQueryAsync(connection, sql, parameters, CommandType.Text);
    }

    private static async Task<int> ExecuteNonQueryAsync(
        DbConnection dbConnection,
        string sql,
        IEnumerable<DbParameter> parameters,
        CommandType typeOfCommand
    )
    {
        using (dbConnection)
        {
            using DbCommand? connect = dbConnection.CreateCommand();
            connect.CommandText = sql;
            connect.CommandType = typeOfCommand;

            foreach (DbParameter? parameter in parameters)
            {
                connect.Parameters.Add(parameter);
            }
            await dbConnection.OpenAsync();

            return await connect.ExecuteNonQueryAsync();
        }
    }
}

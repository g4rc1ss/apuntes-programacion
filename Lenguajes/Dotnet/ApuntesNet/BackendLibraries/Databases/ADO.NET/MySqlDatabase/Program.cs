using MySqlDatabase.MySQL;

const string CONNECTION_STRING =
    "server=localhost;user=root;database=AdoNetMySqlDatabase;port=3306;password=123456";

_ = new CreateDatabaseAndTables(CONNECTION_STRING);
_ = new InsertMysql(CONNECTION_STRING);
_ = new UpdateMysql(CONNECTION_STRING);
_ = new DeleteMysql(CONNECTION_STRING);
_ = new SelectMysql(CONNECTION_STRING);

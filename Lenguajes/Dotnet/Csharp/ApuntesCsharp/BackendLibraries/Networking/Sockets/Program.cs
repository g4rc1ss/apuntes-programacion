using Sockets.ConexionSocket;
using Sockets.ConexionSocket.ClienteServidor;

// -------- Peticion de conexion tipo cliente -------- \\
ConsultarPuertosAbiertos.EscanerPuertos();

// -------- Conexion cliente-servidor -------- \\
new Thread(Servidor.Conectar).Start();
Thread.Sleep(new TimeSpan(0, 0, 5));
Cliente.Conectar();

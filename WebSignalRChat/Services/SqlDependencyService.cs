using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebSignalRChat.Interfaces;

namespace WebSignalRChat.Services
{
    public class SqlDependencyService : IDataCambioUsuario
    {
        private readonly IConfiguration configuration;
        private readonly IHubContext<ChatHub> chatHub;

        public SqlDependencyService(IConfiguration configuration, IHubContext<ChatHub> chatHub)
        {
            this.configuration = configuration;
            this.chatHub = chatHub;
        }
        public void Configuracion()
        {
            SuscripcionNuevoUsuario();
        }

        private void SuscripcionNuevoUsuario()
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            using (var connection = new SqlConnection(connectionString))
            {

                
                using (var command = new SqlCommand(@"SELECT [Id], [NombreUsuario] FROM [dbo].Usuario", connection)) 
                {

                    command.Notification = null;
                    connection.Open();
                    SqlDependency sqlDependency = new SqlDependency(command);  
                    sqlDependency.OnChange += new OnChangeEventHandler( Usuario_Nuevo);
                    SqlDependency.Start(connectionString);
                    command.ExecuteReader();
                }
            }
        }

        private void Usuario_Nuevo(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                string mensaje = Mensaje(e);
                chatHub.Clients.All.SendAsync("ReceiveMessage", "Administrador", mensaje);
            }
            SuscripcionNuevoUsuario();
        }

        private string Mensaje(SqlNotificationEventArgs e)
        {
            switch (e.Info)
            {               
                case SqlNotificationInfo.Delete:
                    return "Un usuario ha sido dado de baja";
                case SqlNotificationInfo.Insert:
                    return "Un usuario nuevo se ha registrado";
                case SqlNotificationInfo.Update:
                    return "Un usuario ha actualizado su perfil";
                default:
                    return "Un cambio ocurrio en la BD";
            }
        }
    }
}

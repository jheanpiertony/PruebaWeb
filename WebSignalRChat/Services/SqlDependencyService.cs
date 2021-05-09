using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;
using WebSignalRChat.Interfaces;
using WebSignalRChat.Models;

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
                connection.Open();
                using (var command = new SqlCommand(@"SELECT NombreUsuario FROM dbo.Usuario", connection)) 
                {
                    var usuarioChange = new SqlTableDependency<Usuario>(configuration.GetConnectionString("DefaultConnection"), "Usuario");                    
                    command.Notification = null;                    
                    SqlDependency sqlDependency = new SqlDependency(command);
                    sqlDependency.OnChange += SqlDependency_OnChange;
                    usuarioChange.OnChanged += UsuarioChange_OnChanged;
                    SqlDependency.Start(connectionString);
                    usuarioChange.Start();
                    usuarioChange.Stop();
                    
                    command.ExecuteReader();
                }
            }
        }

        private void UsuarioChange_OnChanged(object sender, RecordChangedEventArgs<Usuario> e)
        {
            string mensaje = MensajeTable(e);
            chatHub.Clients.All.SendAsync("ReceiveMessage", "Administrador", mensaje);
            SuscripcionNuevoUsuario();
        }

        private void SqlDependency_OnChange(object sender, SqlNotificationEventArgs e)
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
        private string MensajeTable(RecordChangedEventArgs<Usuario> e)
        {
            string usuario = $"El usuario {e.Entity.NombreUsuario}";
            switch (e.ChangeType)
            {
                case TableDependency.SqlClient.Base.Enums.ChangeType.Delete:
                    return $"{usuario} ha sido dado de baja";
                case TableDependency.SqlClient.Base.Enums.ChangeType.Insert:
                    return $"{usuario} se ha registrado";
                case TableDependency.SqlClient.Base.Enums.ChangeType.Update:
                    return $"{usuario} ha actualizado su perfil";
                default:
                    return "Un cambio ocurrio en la BD";
            }
        }
    }
}

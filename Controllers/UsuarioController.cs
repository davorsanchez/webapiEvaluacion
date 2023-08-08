using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly string _connectionString; // Cadena de conexión
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            // Configura tu cadena de conexión aquí
            _connectionString = "Server=localhost\\MSSQLSERVER03;Database=evaluacion;Trusted_Connection=True;TrustServerCertificate=True";
            _logger = logger;
        }

        [HttpGet(Name = "GetUsuario")]
        public IEnumerable<Usuario> Get()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM MAE_USUARIOS";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        COD_USUARIO = reader.GetInt32(reader.GetOrdinal("COD_USUARIO")),
                        TIP_DOCUMENTO = reader.GetString(reader.GetOrdinal("TIP_DOCUMENTO")),
                        VAR_DOC_IDENTIDAD = reader.GetString(reader.GetOrdinal("VAR_DOC_IDENTIDAD")),
                        VAR_APELLIDOS = reader.GetString(reader.GetOrdinal("VAR_APELLIDOS")),
                        VAR_PASSWORD = reader.GetString(reader.GetOrdinal("VAR_PASSWORD")),
                        VAR_NUM_TELEFONO = reader.GetString(reader.GetOrdinal("VAR_NUM_TELEFONO")),
                        INT_FLG_ELIMINADO = reader.GetInt32(reader.GetOrdinal("INT_FLG_ELIMINADO")),
                        FEC_REGISTRO = reader.GetDateTime(reader.GetOrdinal("FEC_REGISTRO")),
                        FEC_MODIFICACION = reader.GetDateTime(reader.GetOrdinal("FEC_MODIFICACION"))
                    };
                    usuarios.Add(usuario);
                }

                reader.Close();
            }

            return usuarios;
        }
    }
}

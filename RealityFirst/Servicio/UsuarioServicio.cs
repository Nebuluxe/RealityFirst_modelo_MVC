using RealityFirst.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace RealityFirst.Servicio
{
    public class UsuarioServicio
    { 
        private string Connection;

        public UsuarioServicio(string ConectionString)
        {
            this.Connection = ConectionString;
        }

        public UsuarioModel Get(int id)
        {
            UsuarioModel Usuario = new UsuarioModel();

            using (SqlConnection server = new SqlConnection(this.Connection))
            {
                server.Open();

                string query = string.Format("SELECT IdUsuario, Correo, Clave FROM USUARIO");
                using (SqlCommand cmd = new SqlCommand(query, server))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Usuario = new UsuarioModel()
                            {
                                IdUsuario = reader.GetInt32(0),
                                Correo = reader.GetString(1),
                                Clave = reader.GetString(2)
                            };
                        }
                    }
                }
                server.Close();
            }
            return Usuario;
        }

        public IList<UsuarioModel> GetAll()
        {
            IList<UsuarioModel> listaUsuario = new List<UsuarioModel>();

            using (SqlConnection server = new SqlConnection(this.Connection))
            {
                server.Open();

                string query = string.Format("SELECT IdUsuario, Correo, Clave FROM USUARIO");
                using (SqlCommand cmd = new SqlCommand(query, server))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaUsuario.Add(new UsuarioModel()
                            {
                                IdUsuario = reader.GetInt32(0),
                                Correo = reader.GetString(1),
                                Clave = reader.GetString(2)
                            });
                        }
                    }
                }
                server.Close();
            }
            return listaUsuario;
        }
    }
}

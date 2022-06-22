using RealityFirst.Models;
using RealityFirst.Servicio.ServicioEstructura;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;


namespace RealityFirst.Servicio
{
    public class ArtistaServicio : IServicio<Artista>
    {
        private string Connection;

        public ArtistaServicio(string ConectionString)
        {
            this.Connection = ConectionString;
        }

        public IList<Artista> GetAll()
        {
            IList<Artista> lista = new List<Artista>();

            using (SqlConnection server = new SqlConnection(this.Connection))
            {
                server.Open();

                string query = string.Format("select id_artista, nombre, edad, genero_musical, foto, fecha_nac from Artista;");
                using (SqlCommand cmd = new SqlCommand(query, server))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Artista()
                            {
                                id = reader.GetInt32(0),
                                nombre = reader.GetString(1),
                                edad = reader.GetInt32(2),
                                genero = reader.GetString(3),
                                foto = reader.GetString(4),
                                fecha_nacimiento = reader.GetString(5)
                            });
                        }
                    }
                }
                server.Close();
            }
            return lista;
        }

        public Artista Get(int id)
        {
            Artista artista = new Artista();

            using (SqlConnection server = new SqlConnection(this.Connection))
            {
                server.Open();

                string query = string.Format("select id_artista, nombre, edad, genero_musical, foto, fecha_nac from Artista;");
                using (SqlCommand cmd = new SqlCommand(query, server))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            artista = new Artista()
                            {
                                id = reader.GetInt32(0),
                                nombre = reader.GetString(1),
                                edad = reader.GetInt32(2),
                                genero = reader.GetString(3),
                                foto = reader.GetString(4),
                                fecha_nacimiento = reader.GetString(5)
                            };
                        }
                    }
                }
                server.Close();
            }
            return artista;
        } 

        public void Create(Artista obj)
        {

        }

        public void Update(Artista obj)
        {

        }

        public void Delete(int id)
        {

        }

    }


}

using RealityFirst.Models;
using RealityFirst.Servicio.ServicioEstructura;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;


namespace RealityFirst.Servicio
{
    public class NoticiaServicio : IServicio<NoticiaModel>
    {
        private string Connection;

        public NoticiaServicio(string ConectionString)
        {
            this.Connection = ConectionString;
        }

        public IList<NoticiaModel> GetAll()
        {
            IList<NoticiaModel> lista = new List<NoticiaModel>();

            using (SqlConnection server = new SqlConnection(this.Connection))
            {
                server.Open();

                string query = string.Format("select id_noticia, titulo, contenido, fecha_not, escritor, editor, imagen_not, id_artista from noticia_artista;");
                using (SqlCommand cmd = new SqlCommand(query, server))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new NoticiaModel()
                            {
                                id_noticia = reader.GetInt32(0),
                                titulo = reader.GetString(1),
                                contenido = reader.GetString(2),
                                fecha_noticia = reader.GetString(3),
                                escritor = reader.GetString(4),
                                editor = reader.GetString(5),
                                foto_noticia = reader.GetString(6),
                                id_artista = reader.GetInt32(7)
                            });
                        }
                    }
                }
                server.Close();
            }
            return lista;
        }

        public NoticiaModel Get(int id)
        {
            NoticiaModel artista = new NoticiaModel();

            using (SqlConnection server = new SqlConnection(this.Connection))
            {
                server.Open();

                string query = string.Format("select id_noticia, titulo, contenido, fecha_not, escritor, editor, imagen_not, id_artista from noticia_artista;");
                using (SqlCommand cmd = new SqlCommand(query, server))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            artista = new NoticiaModel()
                            {
                                id_noticia = reader.GetInt32(0),
                                titulo = reader.GetString(1),
                                contenido = reader.GetString(2),
                                fecha_noticia = reader.GetString(3),
                                escritor = reader.GetString(4),
                                editor = reader.GetString(5),
                                foto_noticia = reader.GetString(6),
                                id_artista = reader.GetInt32(7)
                            };
                        }
                    }
                }
                server.Close();
            }
            return artista;
        }

        public void Create(NoticiaModel obj)
        {

        }

        public void Update(NoticiaModel obj)
        {

        }

        public void Delete(int id)
        {

        }

    }
}

using RealityFirst.Models;
using RealityFirst.Servicio.ServicioEstructura;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;


namespace RealityFirst.Servicio
{
    public class ArtistaServicio : IServicio<ArtistaModel>
    {
        private string Connection;

        public ArtistaServicio(string ConectionString)
        {
            this.Connection = ConectionString;
        }

        public ArtistaModel Get(int id)
        {
            ArtistaModel artista = new ArtistaModel();

            using (SqlConnection server = new SqlConnection(this.Connection))
            {
                server.Open();

                string query = string.Format("select ar.id_artista, ar.nombre, ar.edad, ar.genero_musical, ar.foto, ar.fecha_nac, nt.id_noticia, nt.titulo, nt.contenido, nt.fecha_not, nt.escritor, nt.editor, nt.imagen_not from Artista AS ar JOIN noticia_artista AS nt ON(ar.id_artista = nt.id_artista) where ar.id_artista = {0};", id);
                using (SqlCommand cmd = new SqlCommand(query, server))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {   
                        
                        while (reader.Read())
                        {
                            artista = new ArtistaModel()
                            {
                                id = reader.GetInt32(0),
                                nombre = reader.GetString(1),
                                edad = reader.GetInt32(2),
                                genero = reader.GetString(3),
                                foto = reader.GetString(4),
                                fecha_nacimiento = reader.GetString(5),
                                id_noticia = reader.GetInt32(6),
                                titulo = reader.GetString(7),
                                contenido = reader.GetString(8),
                                fecha_noticia = reader.GetString(9),
                                escritor = reader.GetString(10),
                                editor = reader.GetString(11),
                                foto_noticia = reader.GetString(12)

                            };
                        }
                    }
                }
                server.Close();
            }
            return artista;
        }

        public IList<ArtistaModel> GetAll()
        {
            IList<ArtistaModel> lista = new List<ArtistaModel>();

            using (SqlConnection server = new SqlConnection(this.Connection))
            {
                server.Open();

                string query = string.Format("select ar.id_artista, ar.nombre, ar.edad, ar.genero_musical, ar.foto, ar.fecha_nac, nt.id_noticia, nt.titulo, nt.contenido, nt.fecha_not, nt.escritor, nt.editor, nt.imagen_not from Artista AS ar JOIN noticia_artista AS nt ON(ar.id_artista = nt.id_artista);");
                using (SqlCommand cmd = new SqlCommand(query, server))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ArtistaModel()
                            {
                                id = reader.GetInt32(0),
                                nombre = reader.GetString(1),
                                edad = reader.GetInt32(2),
                                genero = reader.GetString(3),
                                foto = reader.GetString(4),
                                fecha_nacimiento = reader.GetString(5),
                                id_noticia = reader.GetInt32(6),
                                titulo = reader.GetString(7),
                                contenido = reader.GetString(8),
                                fecha_noticia = reader.GetString(9),
                                escritor = reader.GetString(10),
                                editor = reader.GetString(11),
                                foto_noticia = reader.GetString(12)
                            });
                        }
                    }
                }
                server.Close();
            }
            return lista;
        }

        public void Create(ArtistaModel obj)
        {

        }

        public void Update(ArtistaModel obj)
        {

        }

        public void Delete(int id)
        {

        }

        public IList<ArtistaModel> FiltrarArtista(int id)
        {
            IList<ArtistaModel> lista = this.GetAll();
            return lista.Where(x => x.id == id).ToList();
        }

    }


}
